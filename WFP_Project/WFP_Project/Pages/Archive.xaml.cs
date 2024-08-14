using System.Windows;
using WFP_Project.Classes;

namespace WFP_Project.Pages
{
    public partial class ArchiveWindow : Window
    {
        public ArchiveWindow()
        {
            InitializeComponent();
        }

        private void Windows_Load(object sender, RoutedEventArgs e)
        {
            SettingsManager.ApplySelectedTheme();

            
        }
    }
}
