using System.Windows;
using WFP_Project.Classes;

namespace WFP_Project.UserControls
{
    public partial class SignUp : Window
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SettingsManager.ApplySelectedTheme();
        }

        private void RadioButtonLogin_Checked(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            if (mainWindow != null)
            {
                var login = new Login();
                LoginMenu.ReturnToLoginMenu(login, mainWindow);
            }
        }

        //Sign in

        private void TextBoxNewLogin_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void TextBoxNewPassword_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void TextBoxNewRepeatPassword_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void TextBoxNewEmail_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonSignIn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
