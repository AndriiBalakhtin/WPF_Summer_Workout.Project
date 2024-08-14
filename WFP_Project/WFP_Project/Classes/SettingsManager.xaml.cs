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
                var json = File.ReadAllText(SettingsFilePath);
                return JsonSerializer.Deserialize<AppSettings>(json);
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
                MessageBox.Show("No theme selected in settings.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
