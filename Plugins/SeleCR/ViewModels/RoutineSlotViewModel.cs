namespace CarbuncleTech.Plugins.SeleCR.ViewModels
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;

    public class RoutineSlotViewModel : INotifyPropertyChanged
    {
        private readonly Func<string> _getRoutine;
        private readonly Action<string> _setRoutine;

        public string DisplayName { get; }
        public string IconPath { get; }
        public ObservableCollection<string> AvailableRoutines { get; }

        public RoutineSlotViewModel(string displayName, string iconPath, ObservableCollection<string> availableRoutines,
            Func<string> getRoutine, Action<string> setRoutine)
        {
            DisplayName = displayName;
            IconPath = iconPath;
            AvailableRoutines = availableRoutines;
            _getRoutine = getRoutine;
            _setRoutine = setRoutine;
        }

        public string Routine
        {
            get => _getRoutine();
            set
            {
                var normalized = value ?? string.Empty;
                if (_getRoutine() == normalized)
                    return;

                _setRoutine(normalized);
                Settings.Instance.Save();
                OnPropertyChanged(nameof(Routine));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
