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
            MainWindow mainWindow = new MainWindow();
            mainWindow.Content = mainWindow.Content;
        }

        private void RadioButton_ControlsChecked(object sender, RoutedEventArgs e)
        {
            ControlWindow controlWindow = new ControlWindow();
            MainContentControl.Content = controlWindow.Content;
        }

        private void RadioButton_ArchiveChecked(object sender, RoutedEventArgs e)
        {
            ArchiveWindow controlWindow = new ArchiveWindow();
            MainContentControl.Content = controlWindow.Content;
        }

        private void RadioButton_SettingsChecked(object sender, RoutedEventArgs e)
        {
            SettingsWindow controlWindow = new SettingsWindow();
            MainContentControl.Content = controlWindow.Content;
        }
    }
}
