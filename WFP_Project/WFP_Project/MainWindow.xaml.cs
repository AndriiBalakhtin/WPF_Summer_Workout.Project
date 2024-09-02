using System.Windows;
using System.Windows.Media;
using WFP_Project.Classes;
using WFP_Project.Pages;

namespace WFP_Project
{
    public partial class MainWindow : Window
    {
        private UserManagement _userManagement;

        public MainWindow()
        {
            InitializeComponent();
            _userManagement = new UserManagement();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SettingsManager.ApplySelectedTheme();
            this.ResizeMode = ResizeMode.NoResize;
        }

        private void Button_Login_Click(object sender, RoutedEventArgs e)
        {
            string login = TextBoxLogin.Text.Trim();
            string password = TextBoxPassword.Text.Trim();
            string role = ComboBoxRoleType.Text.Trim();

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(role))
            {
                MessageBox.Show("Please fill in all fields.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            bool isAuthenticated;
            try
            {
                isAuthenticated = _userManagement.VerifyUser(login, password, role);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during authentication: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            if (isAuthenticated)
            {
                this.ResizeMode = ResizeMode.CanResize;
                this.Height = 600;
                this.Width = 1140;
                this.MinHeight = 600;
                this.MinWidth = 1140;

                BlockUserControl.Visibility = Visibility.Collapsed;
                LabelLogin.Visibility = Visibility.Collapsed;
                LabelPassword.Visibility = Visibility.Collapsed;
                LabelRole.Visibility = Visibility.Collapsed;
                TextBoxLogin.Visibility = Visibility.Collapsed;
                TextBoxPassword.Visibility = Visibility.Collapsed;
                ComboBoxRoleType.Visibility = Visibility.Collapsed;
                ButtonLogin.Visibility = Visibility.Collapsed;
                LockIcon.Visibility = Visibility.Collapsed;
            }
            else
            {
                SecureLogin secureLogin = new SecureLogin();
                secureLogin.ShowDialog();
            }
        }

        private void TextBoxLogin_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxLogin.Text == "Enter login")
            {
                TextBoxLogin.Text = "";
                TextBoxLogin.Foreground = Brushes.Black;
            }
        }

        private void TextBoxPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxPassword.Text == "Enter password")
            {
                TextBoxPassword.Text = "";
                TextBoxPassword.Foreground = Brushes.Black;
            }
        }

        private void RadioButton_HomeChecked(object sender, RoutedEventArgs e)
        {
            Home homeWindow = new Home();
            MainContentControl.Content = homeWindow.Content;
        }

        private void RadioButton_ControlsChecked(object sender, RoutedEventArgs e)
        {
            ControlWindow controlsWindow = new ControlWindow();
            MainContentControl.Content = controlsWindow.Content;
        }

        private void RadioButton_ArchiveChecked(object sender, RoutedEventArgs e)
        {
            ArchiveWindow archiveWindow = new ArchiveWindow();
            MainContentControl.Content = archiveWindow.Content;
        }

        private void RadioButton_SettingsChecked(object sender, RoutedEventArgs e)
        {
            SettingsWindow settingsWindow = new SettingsWindow();
            MainContentControl.Content = settingsWindow.Content;
        }
    }
}
