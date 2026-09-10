namespace CarbuncleTech.Common
{
    using System;
    using System.IO;
    using System.Windows;
    using System.Windows.Markup;

    /// <summary>
    /// Loads plain .xaml files from disk via XamlReader.Parse. RebornBuddy's plugin loader compiles
    /// this assembly's .cs files from source at runtime (there is no MSBuild step in that path), so a
    /// normal x:Class/InitializeComponent code-behind would never get its generated partial class —
    /// windows are parsed at runtime instead and wired up entirely through data binding.
    /// </summary>
    public static class XamlLoader
    {
        public static T Load<T>(string pluginFolderName, string relativeXamlPath) where T : class
        {
            if (Application.Current == null)
                new Application { ShutdownMode = ShutdownMode.OnExplicitShutdown };

            var path = Path.Combine(
                Environment.CurrentDirectory,
                "Plugins", "CarbuncleTech", "Plugins", pluginFolderName, "Xaml", relativeXamlPath);

            if (!File.Exists(path))
                throw new FileNotFoundException($"WPF XAML file not found: {path}", path);

            if (XamlReader.Parse(File.ReadAllText(path)) is not T element)
                throw new InvalidOperationException($"'{relativeXamlPath}' did not parse to a {typeof(T).Name}.");

            return element;
        }
    }
}
