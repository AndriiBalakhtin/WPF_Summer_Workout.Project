using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using WFP_Project.Classes;
using WFP_Project.Enums;

namespace WFP_Project.Pages
{
    public partial class SettingsWindow : Window
    {
        private AppSettingsEnums appSettings;

        public SettingsWindow()
        {
            InitializeComponent();
            appSettings = SettingsManager.LoadSettings();

            var selectedTheme = appSettings.SelectedTheme;

            if (string.IsNullOrEmpty(selectedTheme) || (selectedTheme != "Light" && selectedTheme != "Dark"))
            {
                selectedTheme = "Light";
            }
            ApplyThemes.ApplyTheme(selectedTheme);

            var defaultItem = ThemeModeComboBox.Items.OfType<ComboBoxItem>()
                .FirstOrDefault(item => item.Content.ToString() == selectedTheme);
            if (defaultItem != null)
            {
                ThemeModeComboBox.SelectedItem = defaultItem;
            }

            UpdateThemeImage(selectedTheme);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SettingsManager.ApplySelectedTheme();
        }

        private void ThemeModeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ThemeModeComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                string selectedTheme = selectedItem.Content.ToString();
                appSettings.SelectedTheme = selectedTheme;
                SettingsManager.SaveSettings(appSettings);
                ApplyThemes.ApplyTheme(selectedTheme);

                UpdateThemeImage(selectedTheme);
            }
        }

        private void UpdateThemeImage(string theme)
        {
            string imagePath = theme == "Dark" ? "/Materials/DarkTheme.png" : "/Materials/LightTheme.png";
            ThemeImage.Source = new BitmapImage(new Uri(imagePath, UriKind.Relative));
        }
    }
}
