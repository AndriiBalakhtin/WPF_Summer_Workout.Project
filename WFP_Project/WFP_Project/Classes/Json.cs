using System.IO;
using System.Text.Json;
using System.Windows;
using WFP_Project.Enums;

namespace WFP_Project.Classes
{
    public static class SettingsManager
    {
        private static readonly string SettingsFilePath = "settings.json";
        private static readonly string UserDataFilePath = "userdata.json";
        private static readonly JsonSerializerOptions jsonOptions = new JsonSerializerOptions { WriteIndented = true };

        public static string UserLogin { get; set; } = string.Empty;
        public static string Role { get; set; } = string.Empty;

        public static AppSettingsEnums LoadSettings()
        {
            if (File.Exists(SettingsFilePath))
            {
                try
                {
                    var json = File.ReadAllText(SettingsFilePath);
                    var settings = JsonSerializer.Deserialize<AppSettingsEnums>(json);
                    return settings ?? new AppSettingsEnums();
                }
                catch (JsonException ex)
                {
                    MessageBox.Show($"Failed to load settings: {ex.Message}", 
                                     "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }

            var defaultSettings = new AppSettingsEnums();
            SaveSettings(defaultSettings);
            return defaultSettings;
        }

        public static void SaveSettings(AppSettingsEnums settings)
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
                    MessageBox.Show($"Failed to load user data: {ex.Message}", 
                                     "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
}
