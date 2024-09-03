using System.Windows;
using System.Windows.Media;
using WFP_Project.Classes;
using WFP_Project.Windows;

namespace WFP_Project.UserControls
{
    public partial class Login : Window
    {
        private UserManagement _userManagement;

        public Login()
        {
            InitializeComponent();

            _userManagement = new UserManagement();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SettingsManager.ApplySelectedTheme();
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
                this.Height = 600; this.Width = 1140; this.MinHeight = 600; this.MinWidth = 1140;

                MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
                LoginSuccess.HideBlockUserControl(mainWindow);

                TextBlockLogin.Visibility = Visibility.Collapsed;
                TextBlockPassword.Visibility = Visibility.Collapsed;
                TextBlockRole.Visibility = Visibility.Collapsed;
                TextBoxLogin.Visibility = Visibility.Collapsed;
                TextBoxPassword.Visibility = Visibility.Collapsed;
                ComboBoxRoleType.Visibility = Visibility.Collapsed;
                ButtonLogin.Visibility = Visibility.Collapsed;
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

        private void RadioButtonSignUp_Checked(object sender, RoutedEventArgs e)
        {
            FirstStep firstStep = new FirstStep();
            this.Content = firstStep.Content;
        }
    }
}
