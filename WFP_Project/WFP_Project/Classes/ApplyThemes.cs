using System.Windows;

namespace WFP_Project.Classes
{
    public class ApplyThemes
    {
        public void ApplyTheme(string theme)
        {
            ResourceDictionary newTheme = new ResourceDictionary();

            try
            {
                switch (theme)
                {
                    case "Light":
                        newTheme.Source = new Uri("pack://application:,,,/Themes/LightTheme.xaml", UriKind.Absolute);
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