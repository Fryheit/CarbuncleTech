namespace CarbuncleTech.Plugins.SeleCR
{
    using System.Windows;
    using Common;
    using ViewModels;

    /// <summary>
    /// Singleton holder for the SeleCR settings window. The window itself is plain XAML parsed at
    /// runtime (see XamlLoader) and wired up entirely through SettingsViewModel data binding.
    /// </summary>
    public static class SettingsWindow
    {
        private static Window _instance;

        public static void Show()
        {
            if (_instance != null)
            {
                _instance.Show();
                _instance.Activate();
                return;
            }

            var window = XamlLoader.Load<Window>("SeleCR", "SettingsWindow.xaml");
            window.DataContext = new SettingsViewModel();
            window.Closed += (s, e) => _instance = null;

            _instance = window;
            window.Show();
        }
    }
}
