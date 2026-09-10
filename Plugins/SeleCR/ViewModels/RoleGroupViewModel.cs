namespace CarbuncleTech.Plugins.SeleCR.ViewModels
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    public class RoleGroupViewModel
    {
        public string Title { get; }
        public ObservableCollection<RoutineSlotViewModel> Slots { get; }

        public RoleGroupViewModel(string title, IEnumerable<RoutineSlotViewModel> slots)
        {
            Title = title;
            Slots = new ObservableCollection<RoutineSlotViewModel>(slots);
        }
    }
}
