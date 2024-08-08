using System.Windows;

namespace WFP_Project
{
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
