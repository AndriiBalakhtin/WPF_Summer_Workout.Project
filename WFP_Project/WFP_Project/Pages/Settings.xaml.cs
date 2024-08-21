using System.Windows;
using System.Windows.Controls;
using WFP_Project.Classes;
using WFP_Project.Enums;

namespace WFP_Project.Pages
{
    public partial class SettingsWindow : Window
    {
        private AppSettings appSettings;
        private ApplyThemes applyThemes;

        public SettingsWindow()
        {
            InitializeComponent();

            appSettings = SettingsManager.LoadSettings();
            applyThemes = new ApplyThemes();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SettingsManager.ApplySelectedTheme();

            var defaultItem = ThemeModeComboBox.Items.OfType<ComboBoxItem>()
                .FirstOrDefault(item => item.Content.ToString() == appSettings.SelectedTheme);
        }

        private void ThemeModeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ThemeModeComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                string selectedTheme = selectedItem.Content.ToString();

                appSettings.SelectedTheme = selectedTheme;
                SettingsManager.SaveSettings(appSettings);
                applyThemes.ApplyTheme(selectedTheme);
            }
        }
    }
}
