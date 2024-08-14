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
            Home homeWindow = new Home();
            MainContentControl.Content = homeWindow.Content;
        }
        private void RadioButton_ControlsChecked(object sender, RoutedEventArgs e)
        {
            ControlWindow controlsWindow = new ControlWindow();
            MainContentControl.Content = controlsWindow.Content;
        }

        private void RadioButton_ArchiveChecked(object sender, RoutedEventArgs e)
        {
            ArchiveWindow archiveWindow = new ArchiveWindow();
            MainContentControl.Content = archiveWindow.Content;
        }

        private void RadioButton_SettingsChecked(object sender, RoutedEventArgs e)
        {
            SettingsWindow settingsWindow = new SettingsWindow();
            MainContentControl.Content = settingsWindow.Content;
        }
    }
}
