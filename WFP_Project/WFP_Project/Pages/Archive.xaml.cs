using System.Windows;
using WFP_Project.Enums;
using WFP_Project.Classes;

namespace WFP_Project.Pages;

public partial class ArchiveWindow : Window
{
    private AppSettings appSettings;

    public ArchiveWindow()
    {
        InitializeComponent();
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        appSettings = SettingsManager.LoadSettings();
        ApplyTheme(appSettings.SelectedTheme);
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
