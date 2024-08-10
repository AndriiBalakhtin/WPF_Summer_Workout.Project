using System.Windows;
using WFP_Project.Classes;
using WFP_Project.Enums;
using WFP_Project.Pages;

namespace WFP_Project
{
    public partial class MainWindow : Window
    {
        private AppSettings appSettings;
        private ApplyThemes applyThemes;

        public MainWindow()
        {
            InitializeComponent();

            appSettings = SettingsManager.LoadSettings();
            applyThemes = new ApplyThemes();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            applyThemes.ApplyTheme(appSettings.SelectedTheme);
        }

        private void SettingsMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var settingsWindow = new SettingsWindow();
            settingsWindow.Show();

            if (settingsWindow != null)
            {
                settingsMenuItem.IsEnabled = false;

                settingsWindow.Closed += (s, args) =>
                {
                    settingsMenuItem.IsEnabled = true;

                    appSettings = SettingsManager.LoadSettings();
                    applyThemes.ApplyTheme(appSettings.SelectedTheme);
                };
            }
        }

        private void ControlMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var controlWindow = new ControlWindow();
            controlWindow.Show();

            if (controlWindow != null)
            {
                controlMenuItem.IsEnabled = false;

                controlWindow.Closed += (s, args) =>
                {
                    controlMenuItem.IsEnabled = true;
                };
            }
        }

        private void ArchiveMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var archiveWindow = new ArchiveWindow();
            archiveWindow.Show();

            if (archiveWindow != null)
            {
                archiveMenuItem.IsEnabled = false;

                archiveWindow.Closed += (s, args) =>
                {
                    archiveMenuItem.IsEnabled = true;
                };
            }
        }
    }
}
