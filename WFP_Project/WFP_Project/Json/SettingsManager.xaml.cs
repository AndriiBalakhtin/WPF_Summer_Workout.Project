using System.IO;
using System.Text.Json;

namespace WFP_Project
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
    }
}
