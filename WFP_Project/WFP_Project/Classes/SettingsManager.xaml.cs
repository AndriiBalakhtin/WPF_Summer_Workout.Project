using System.IO;
using System.Text.Json;
using System.Windows;
using WFP_Project.Enums;

namespace WFP_Project.Classes
{
    public static class SettingsManager
    {
        private static readonly string SettingsFilePath = "settings.json";

        public static AppSettings LoadSettings()
        {
            if (File.Exists(SettingsFilePath))
            {
                try
                {
                    var json = File.ReadAllText(SettingsFilePath);
                    var settings = JsonSerializer.Deserialize<AppSettings>(json);
                    if (settings != null)
                    {
                        return settings;
                    }
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
            var json = JsonSerializer.Serialize(settings, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(SettingsFilePath, json);
        }

        public static void ApplySelectedTheme()
        {
            var settings = LoadSettings();
            var applyThemes = new ApplyThemes();

            if (!string.IsNullOrEmpty(settings.SelectedTheme))
            {
                applyThemes.ApplyTheme(settings.SelectedTheme);
            }
            else
            {
                applyThemes.ApplyTheme("DefaultTheme");
                MessageBox.Show("No theme selected in settings. Applying default theme.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
