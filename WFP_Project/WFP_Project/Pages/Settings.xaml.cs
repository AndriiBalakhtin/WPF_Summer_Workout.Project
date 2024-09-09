using System.Windows;
using System.Windows.Controls;
using WFP_Project.Classes; 


namespace WFP_Project.Pages
{
    public partial class SettingsWindow : Window
    {
        private WFP_Project.Classes.AppSettings appSettings;

        public SettingsWindow()
        {
            InitializeComponent();
            appSettings = SettingsManager.LoadSettings();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SettingsManager.ApplySelectedTheme();

            var defaultItem = ThemeModeComboBox.Items.OfType<ComboBoxItem>()
                .FirstOrDefault(item => item.Content.ToString() == appSettings.SelectedTheme);
            if (defaultItem != null)
            {
                ThemeModeComboBox.SelectedItem = defaultItem;
            }
        }

        private void ThemeModeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ThemeModeComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                string selectedTheme = selectedItem.Content.ToString();
                appSettings.SelectedTheme = selectedTheme;
                SettingsManager.SaveSettings(appSettings);

                ApplyThemes.ApplyTheme(selectedTheme);
            }
        }
    }
}
