namespace CarbuncleTech.Plugins.SeleCR.ViewModels
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using ff14bot.Managers;
    using Models;

    public class SettingsViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<RoleGroupViewModel> PveGroups { get; }
        public ObservableCollection<RoleGroupViewModel> PvpGroups { get; }
        public ObservableCollection<string> AvailableRoutines { get; }

        public SettingsViewModel()
        {
            AvailableRoutines = new ObservableCollection<string>(PopulateRoutines());
            PveGroups = BuildGroups(isPvp: false, AvailableRoutines);
            PvpGroups = BuildGroups(isPvp: true, AvailableRoutines);
        }

        public bool AutoSelectPve
        {
            get => Settings.Instance.AutoSelectPve;
            set
            {
                Settings.Instance.AutoSelectPve = value;
                Settings.Instance.Save();
                OnPropertyChanged(nameof(AutoSelectPve));
            }
        }

        public bool AutoSelectPvp
        {
            get => Settings.Instance.AutoSelectPvp;
            set
            {
                Settings.Instance.AutoSelectPvp = value;
                Settings.Instance.Save();
                OnPropertyChanged(nameof(AutoSelectPvp));
            }
        }

        private static IEnumerable<string> PopulateRoutines()
        {
            var routines = new HashSet<string>(RoutineManager.AllRoutines.Select(r => r.Name.Split(' ')[0]));
            routines.Add(string.Empty);
            return routines.OrderBy(r => r);
        }

        private static ObservableCollection<RoleGroupViewModel> BuildGroups(bool isPvp, ObservableCollection<string> availableRoutines)
        {
            var scenario = isPvp ? Settings.Instance.Pvp : Settings.Instance.Pve;
            var jobs = JobDefinition.All.Where(j => !isPvp || j.HasPvp);

            var groups = jobs
                .GroupBy(j => j.Role)
                .OrderBy(g => (int)g.Key)
                .Select(g => new RoleGroupViewModel(
                    RoleTitle(g.Key),
                    g.Select(j => new RoutineSlotViewModel(
                        j.DisplayName,
                        JobDefinition.IconPath(j.IconFileName),
                        availableRoutines,
                        () => j.Getter(scenario),
                        v => j.Setter(scenario, v)))))
                .ToList();

            if (!isPvp)
            {
                groups.Add(new RoleGroupViewModel("Hand and Land", new[]
                {
                    new RoutineSlotViewModel(
                        "Disciples of the Hand/Land",
                        JobDefinition.IconPath("Miner.png"),
                        availableRoutines,
                        () => Settings.Instance.HandRoutine,
                        v => Settings.Instance.HandRoutine = v)
                }));
            }

            return new ObservableCollection<RoleGroupViewModel>(groups);
        }

        private static string RoleTitle(JobRole role)
        {
            return role switch
            {
                JobRole.Tank => "Tanks",
                JobRole.Healer => "Healers",
                JobRole.MeleeDps => "Melee DPS",
                JobRole.PhysicalRangedDps => "Physical Ranged DPS",
                JobRole.MagicalRangedDps => "Magical Ranged DPS",
                JobRole.Limited => "Limited Jobs",
                _ => role.ToString()
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
