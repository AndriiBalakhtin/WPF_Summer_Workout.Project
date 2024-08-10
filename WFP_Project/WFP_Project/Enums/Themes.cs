using System.Windows;

namespace WFP_Project.Enums
{
    public class AppSettings
    {
        public string SelectedTheme { get; set; } = "Light";
    }
  
    public partial class DarkTheme : Window
    {
        public DarkTheme()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            var uri = new Uri("Themes/DarkTheme.xaml", UriKind.Relative);
            Application.LoadComponent(this, uri);
        }
    }

}
