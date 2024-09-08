using System.Windows;
using WFP_Project.Classes;

namespace WFP_Project.UserControls
{

    public partial class ForgotPassword : Window
    {
        public ForgotPassword()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SettingsManager.ApplySelectedTheme();
        }

        private void RadioButtonReturnBackToLogin_Checked(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            if (mainWindow != null)
            {
                var login = new Login();
                LoginMenu.ReturnToLoginMenu(login, mainWindow);
            }
        }

        private void TextBoxEnterOldEmail_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonConfirmEmail_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextBoxConfirmCodeFromEmail_Click_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void TextBoxConfirmCodeFromEmail_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonConfirmCodeFromEmail_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonSendAgainEmail_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
