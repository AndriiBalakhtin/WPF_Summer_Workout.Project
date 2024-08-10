using System.Windows;
using WFP_Project.Classes;
using WFP_Project.Enums;

namespace WFP_Project.Pages
{
    public partial class ArchiveWindow : Window
    {
        private readonly AppSettings appSettings;
        private readonly ApplyThemes applyThemes;

        public ArchiveWindow()
        {
            InitializeComponent();

            appSettings = SettingsManager.LoadSettings();
            applyThemes = new ApplyThemes();
        }

        private void Windows_Load(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(appSettings.SelectedTheme))
            {
                applyThemes.ApplyTheme(appSettings.SelectedTheme);
            }
            else
            {
                MessageBox.Show("No theme selected in settings.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
