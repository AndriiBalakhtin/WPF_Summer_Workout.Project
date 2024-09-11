using System.Windows;
using WFP_Project.Classes;

namespace WFP_Project.Pages
{
    public partial class Notice : Window
    {
        public Notice()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SettingsManager.ApplySelectedTheme();
        }
    }
}
