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

        private void RadioButton_HomeChecked(object sender, RoutedEventArgs e)
        {
            //Nothing
        }

        private void RadioButton_ControlsChecked(object sender, RoutedEventArgs e)
        {
            var controlWindow = new ControlWindow();
            controlWindow.Show();

            if (controlWindow != null)
            {
                IsEnabled = false;

                controlWindow.Closed += (s, args) =>
                {
                    IsEnabled = true;
                };
            }
        }

        private void RadioButton_ArchiveChecked(object sender, RoutedEventArgs e)
        {
            var archiveWindow = new ArchiveWindow();
            archiveWindow.Show();

            if (archiveWindow != null)
            {
                IsEnabled = false;

                archiveWindow.Closed += (s, args) =>
                {
                    IsEnabled = true;
                };
            }
        }

        private void RadioButton_SettingsChecked(object sender, RoutedEventArgs e)
        {
            var settingsWindow = new SettingsWindow();
            settingsWindow.Show();

            if (settingsWindow != null)
            {
                IsEnabled = false;

                settingsWindow.Closed += (s, args) =>
                {
                    IsEnabled = true;

                    appSettings = SettingsManager.LoadSettings();
                    applyThemes.ApplyTheme(appSettings.SelectedTheme);
                };
            }
        }

        private void RadioButton_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            
        }
    }
}
