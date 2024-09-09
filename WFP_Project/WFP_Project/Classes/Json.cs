using System.IO;
using System.Text.Json;
using System.Windows;

namespace WFP_Project.Classes
{
    public static class SettingsManager
    {
        private static readonly string SettingsFilePath = "settings.json";
        private static readonly string UserDataFilePath = "userdata.json";
        private static readonly JsonSerializerOptions jsonOptions = new JsonSerializerOptions { WriteIndented = true };

        public static string UserLogin { get; set; } = string.Empty;
        public static string Role { get; set; } = string.Empty;

        public static AppSettings LoadSettings()
        {
            if (File.Exists(SettingsFilePath))
            {
                try
                {
                    var json = File.ReadAllText(SettingsFilePath);
                    var settings = JsonSerializer.Deserialize<AppSettings>(json);
                    return settings ?? new AppSettings();
                }
                catch (JsonException ex)
                {
                    MessageBox.Show($"Failed to load settings: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            var defaultSettings = new AppSettings();
            SaveSettings(defaultSettings);
            return defaultSettings;
        }

        public static void SaveSettings(AppSettings settings)
        {
            var json = JsonSerializer.Serialize(settings, jsonOptions);
            File.WriteAllText(SettingsFilePath, json);
        }

        public static UserData LoadUserData()
        {
            if (File.Exists(UserDataFilePath))
            {
                try
                {
                    var json = File.ReadAllText(UserDataFilePath);
                    var userData = JsonSerializer.Deserialize<UserData>(json);
                    return userData ?? new UserData();
                }
                catch (JsonException ex)
                {
                    MessageBox.Show($"Failed to load user data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            return new UserData();
        }

        public static void SaveUserData(UserData userData)
        {
            var json = JsonSerializer.Serialize(userData, jsonOptions);
            File.WriteAllText(UserDataFilePath, json);
        }

        public static void ApplySelectedTheme()
        {
            var settings = LoadSettings();
            ApplyThemes.ApplyTheme(settings.SelectedTheme ?? "DefaultTheme");
        }
    }

    public static class ApplyThemes
    {
        public static void ApplyTheme(string theme)
        {
            var newTheme = new ResourceDictionary();

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

    public class UserData
    {
        public string UserLogin { get; set; }
        public string Role { get; set; }
    }

    public class AppSettings
    {
        public string SelectedTheme { get; set; } = "Light";
    }
}
