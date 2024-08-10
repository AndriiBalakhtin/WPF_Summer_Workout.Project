using System.Windows;
using WFP_Project.Enums;
using WFP_Project.Pages;
using WFP_Project.Classes;

namespace WFP_Project;

public partial class MainWindow : Window
{
    private AppSettings appSettings;

    public MainWindow()
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

    private void SettingsMenuItem_Click(object sender, RoutedEventArgs e)
    {
        var form2 = new SettingsWindow();
        form2.Show();

        if (form2 != null)
        {
            settingsMenuItem.IsEnabled = false;

            form2.Closed += (s, args) =>
            {
                settingsMenuItem.IsEnabled = true;

                appSettings = SettingsManager.LoadSettings();
                ApplyTheme(appSettings.SelectedTheme);
            };
        }
    }

    private void ControlMenuItem_Click(object sender, RoutedEventArgs e)
    {
        var form3 = new ControlWindow();
        form3.Show();

        if (form3 != null)
        {
            controlMenuItem.IsEnabled = false;

            form3.Closed += (s, args) =>
            {
                controlMenuItem.IsEnabled = true;
            };
        }
    }

    private void ArchiveMenuItem_Click(object sender, RoutedEventArgs e)
    {
        var form4 = new ArchiveWindow();
        form4.Show();

        if (form4 != null)
        {
            archiveMenuItem.IsEnabled = false;

            form4.Closed += (s, args) =>
            {
                archiveMenuItem.IsEnabled = true;
            };
        }
    }
}
