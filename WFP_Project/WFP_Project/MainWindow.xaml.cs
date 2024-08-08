using System.Windows;

namespace WFP_Project
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void SettingsMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var form2 = new SettingsWindow();
            form2.Show();

            if (form2 != null)
            {
                settingsMenuItem.IsEnabled = false;

                form2.Closed += (s, args) =>
                {
                    settingsMenuItem.IsEnabled = true;
                };
            }
        }

        private void ControlMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var form3 = new ControlWindow();
            form3.Show();

            if (form3 != null)
            {
                controlMenuItem.IsEnabled = false;

                form3.Closed += (s, args) =>
                {
                    controlMenuItem.IsEnabled = true;
                };
            }
        }

        private void ArchiveMenuItem_Click(object sender, RoutedEventArgs e)
        {
            var form4 = new ArchiveWindow();
            form4.Show();

            if (form4 != null)
            {
                archiveMenuItem.IsEnabled = false;

                form4.Closed += (s, args) =>
                {
                    archiveMenuItem.IsEnabled = true;
                };
            }
        }
    }
}
