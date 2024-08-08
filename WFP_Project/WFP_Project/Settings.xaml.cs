
using System.Windows;
using System.Windows.Controls;

namespace WFP_Project
{
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var defaultItem = ThemeModeComboBox.Items.OfType<ComboBoxItem>()
                .FirstOrDefault(item => item.Content.ToString() == "White");

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
                ApplyTheme(selectedTheme);
            }
        }

        private void ApplyTheme(string theme)
        {
            ResourceDictionary newTheme = new ResourceDictionary();

            try
            {
                switch (theme)
                {
                    case "White":
                        newTheme.Source = new Uri("pack://application:,,,/Themes/WhiteTheme.xaml", UriKind.Absolute);
                        break;
                    case "Dark":
                        newTheme.Source = new Uri("pack://application:,,,/Themes/DarkTheme.xaml", UriKind.Absolute);
                        break;
                    default:
                        MessageBox.Show("Unknown theme selected.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                }

                Application.Current.Resources.MergedDictionaries.Clear();
                Application.Current.Resources.MergedDictionaries.Add(newTheme);

                foreach (Window window in Application.Current.Windows)
                {
                    window.Background = (System.Windows.Media.Brush)newTheme["WindowBackgroundBrush"];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading theme: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
