using System.Windows;
using WFP_Project.Pages;
using WFP_Project.UserControls;

namespace WFP_Project.Classes
{
    public static class LoginSuccess
    {
        public static void HideBlockUserControl(MainWindow mainWindow)
        {
            if (mainWindow != null)
            {
                mainWindow.RadioButton_Home.IsChecked     = true;
                mainWindow.BlockUserControl.Visibility    = Visibility.Hidden;
                mainWindow.LockIcon.Visibility            = Visibility.Hidden;
                mainWindow.RadioButton_Admin.Visibility   = Visibility.Visible;
                mainWindow.RadioButton_Notice.Visibility  = Visibility.Visible;
                mainWindow.RadioButton_Session.Visibility = Visibility.Visible;
                mainWindow.StackPanelRadioButtonsMainWindow.Height = 450;
                mainWindow.RowDefinitionRadioButtons.Height        = new GridLength(1000);
                mainWindow.StackPanelRadioButtonsMainWindow.Margin = new Thickness(15,6,0,600);
                mainWindow.MainContentControl.Margin               = new Thickness(15,6,0,0);
                mainWindow.ResizeMode                              = ResizeMode.CanResize;
                mainWindow.Height = 600; mainWindow.Width = 1140; mainWindow.MinHeight = 600; mainWindow.MinWidth = 1140;
            }
        }
    }

    public static class HomeMenu
    {
        public static void Home(Home home, MainWindow mainWindow)
        {
            if (home != null && mainWindow != null)
            {
                mainWindow.MainContentControl.Content = home.Content;
            }
        }
    }

    public static class LoginMenu
    {
        public static void ReturnToLoginMenu(Login login, MainWindow mainWindow)
        {
            if (login != null && mainWindow != null)
            {
                mainWindow.MainContentControl.Content = login.Content;
            }
        }
    }

    public static class SignUpMenu
    {
        public static void ReturnToSignUpMenu(SignUp signUp, MainWindow mainWindow)
        {
            if (signUp != null && mainWindow != null)
            {
                mainWindow.MainContentControl.Content = signUp.Content;
            }
        }
    }

    public static class ConfirmEmailMenu
    {
        public static void ConfirmEmail(ConfirmEmail confirmEmail, MainWindow mainWindow)
        {
            if (confirmEmail != null && mainWindow != null)
            {
                mainWindow.MainContentControl.Content = confirmEmail.Content;
            }
        }
    }

    public static class ForgotPasswordMenu
    {
        public static void ForgotPassword(ForgotPassword forgotPassword, MainWindow mainWindow)
        {
            if(forgotPassword != null && mainWindow != null)
            {
                mainWindow.MainContentControl.Content = forgotPassword.Content;
            }   
        }
    }
}