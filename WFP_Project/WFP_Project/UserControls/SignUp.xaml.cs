using MaterialDesignThemes.Wpf;
using System.Net;
using System.Net.Mail;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using WFP_Project.Classes;

namespace WFP_Project.UserControls
{
    public partial class SignUp : Window
    {
        private string _confirmationCode;
        private string _email;
        private string _login;
        private string _password;
        private string _role;

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

        private void ButtonSignIn_Click(object sender, RoutedEventArgs e)
        {
            _login = TextBoxNewLogin.Text;
            _password = PasswordBoxNewPassword.Password; 
            string repeatPassword = PasswordBoxNewRepeatPassword.Password;
            _email = TextBoxNewEmail.Text;

            ShowPasswordToggleIcon.Kind             = PackIconKind.EyeOff;
            ShowRepeatPasswordToggleIcon.Kind       = PackIconKind.EyeOff;
            PasswordBoxNewRepeatPassword.Foreground = Brushes.Black;
            PasswordBoxNewPassword.Foreground       = Brushes.Black;
            TextBoxNewRepeatPassword.Foreground     = Brushes.Black;
            TextBoxNewPassword.Foreground           = Brushes.Black;
            PasswordBoxNewRepeatPassword.Visibility = Visibility.Visible;
            PasswordBoxNewPassword.Visibility       = Visibility.Visible;
            TextBoxNewRepeatPassword.Visibility     = Visibility.Collapsed;
            TextBoxNewPassword.Visibility           = Visibility.Collapsed;

            if (ComboBoxNewRoleType.SelectedItem is ComboBoxItem selectedRole)
            {
                _role = selectedRole.Content.ToString();
            }

            if (_login.Length < 5 || _login == "Enter new login")
            {
                MessageBox.Show("Minimum 5 characters required in login!");
                return;
            }

            if (_password.Length < 8 || _password == "Enter new pass...")
            {
                MessageBox.Show("Minimum 8 characters required in password!");
                return;
            }

            if (_password != repeatPassword)
            {
                MessageBox.Show("Passwords do not match!");
                return;
            }

            if (_password == "12345678" || _password == "87654321" ||
                _password == "11223344" || _password == "44332211")
            {
                MessageBox.Show("we ask for strong passwords");
                return;
            }

            UserManagement userManagement = new UserManagement();
            bool emailExists = userManagement.EmailExists(_email);

            if (emailExists)
            {
                MessageBox.Show("This email is already registered. Please use a different email.", 
                                "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            _confirmationCode = GenerateConfirmationCode();

            try
            {
                SendConfirmationEmail(_email, _confirmationCode);

                var email = GetEmail();
                var confirmEmail = new ConfirmEmail(_confirmationCode, _login, _password, _role, _email);
                var mainWindow = Application.Current.MainWindow as MainWindow;
                if (mainWindow != null)
                {
                    ConfirmEmailMenu.ConfirmEmail(confirmEmail, mainWindow);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        public string GetEmail()
        {
            return TextBoxNewEmail.Text;
        }

        private string GenerateConfirmationCode()
        {
            Random RandomCode = new Random();
            return RandomCode.Next(100000, 999999).ToString();
        }

        private void SendConfirmationEmail(string toEmail, string code)
        {
            string fromEmail = "wfpworkoutregestration@gmail.com";
            string fromPassword = "ajrx djws crji xhym";

            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress(fromEmail);
                mail.To.Add(toEmail);
                mail.IsBodyHtml = true;
                mail.Subject = $"Email Confirmation Code, This is {code}";
                mail.Body = $"Hello!!!, <b>{_login}</b> <br><br>" +
                            $"Your role this is, <b>[ {_role} ]</b> <br><br>" +
                            $"Thank you for registering. Your confirmation code is: <b>{code}</b>";

                SmtpServer.EnableSsl = true; 
                SmtpServer.Port = 587; // 587 - TLS, 465 - SSL [Google]
                SmtpServer.Credentials = new NetworkCredential(fromEmail, fromPassword);
                SmtpServer.Send(mail);
            }
            catch
            {
                throw new Exception($"Incorrect email address");
            }
        }

        private void ButtonToggleShowPassword_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxNewPassword.Text == "Enter new pass...")
            {
                TextBoxNewPassword.Text = "";
                TextBoxNewPassword.Foreground     = Brushes.Black;
                PasswordBoxNewPassword.Foreground = Brushes.Black;
                TextBoxNewPassword.Visibility     = Visibility.Collapsed;
                PasswordBoxNewPassword.Visibility = Visibility.Visible;
                PasswordBoxNewPassword.Focus();
            }
            if (PasswordBoxNewPassword.Visibility == Visibility.Visible)
            {
                ShowPasswordToggleIcon.Kind       = PackIconKind.Eye;
                TextBoxNewPassword.Text           = PasswordBoxNewPassword.Password;
                TextBoxNewPassword.Visibility     = Visibility.Visible;
                PasswordBoxNewPassword.Visibility = Visibility.Collapsed;
            }
            else
            {
                ShowPasswordToggleIcon.Kind       = PackIconKind.EyeOff;
                PasswordBoxNewPassword.Password   = TextBoxNewPassword.Text;
                PasswordBoxNewPassword.Visibility = Visibility.Visible;
                TextBoxNewPassword.Visibility     = Visibility.Collapsed;
            }
        }

        private void ButtonToggleShowRepeatPassword_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxNewRepeatPassword.Text == "Repeat pass...")
            {
                TextBoxNewRepeatPassword.Text = "";
                TextBoxNewRepeatPassword.Foreground     = Brushes.Black;
                PasswordBoxNewRepeatPassword.Foreground = Brushes.Black;
                TextBoxNewRepeatPassword.Visibility     = Visibility.Collapsed;
                PasswordBoxNewRepeatPassword.Visibility = Visibility.Visible;
                PasswordBoxNewRepeatPassword.Focus();
            }
            if (PasswordBoxNewRepeatPassword.Visibility == Visibility.Visible)
            {
                ShowRepeatPasswordToggleIcon.Kind       = PackIconKind.Eye;
                TextBoxNewRepeatPassword.Text           = PasswordBoxNewRepeatPassword.Password;
                TextBoxNewRepeatPassword.Visibility     = Visibility.Visible;
                PasswordBoxNewRepeatPassword.Visibility = Visibility.Collapsed;
            }
            else
            {
                ShowRepeatPasswordToggleIcon.Kind       = PackIconKind.EyeOff;
                PasswordBoxNewRepeatPassword.Password   = TextBoxNewRepeatPassword.Text;
                PasswordBoxNewRepeatPassword.Visibility = Visibility.Visible;
                TextBoxNewRepeatPassword.Visibility     = Visibility.Collapsed;
            }
        }

        private void PasswordBoxNewPassword_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            TextBoxNewPassword.Text = PasswordBoxNewPassword.Password;
            if ((Keyboard.Modifiers == ModifierKeys.Control) && (e.Key == Key.C || e.Key == Key.V))
            {
                e.Handled = true;
            }
        }

        private void TextBoxNewPassword_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PasswordBoxNewPassword.Password = TextBoxNewPassword.Text;
            if ((Keyboard.Modifiers == ModifierKeys.Control) && (e.Key == Key.C || e.Key == Key.V))
            {
                e.Handled = true;
            }
        }

        private void PasswordBoxNewRepeatPassword_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            TextBoxNewRepeatPassword.Text = PasswordBoxNewRepeatPassword.Password;
            if ((Keyboard.Modifiers == ModifierKeys.Control) && (e.Key == Key.C || e.Key == Key.V))
            {
                e.Handled = true;
            }
        }

        private void TextBoxNewRepeatPassword_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PasswordBoxNewRepeatPassword.Password = TextBoxNewRepeatPassword.Text;
            if ((Keyboard.Modifiers == ModifierKeys.Control) && (e.Key == Key.C || e.Key == Key.V))
            {
                e.Handled = true;
            }
        }

        private void TextBoxNewLogin_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxNewLogin.Text == "Enter new login")
            {
                TextBoxNewLogin.Text = "";
                TextBoxNewLogin.Foreground = Brushes.Black;
            }
        }

        private void TextBoxNewPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxNewPassword.Text == "Enter new pass...")
            {
                TextBoxNewPassword.Text = "";
                TextBoxNewPassword.Foreground     = Brushes.Black;
                PasswordBoxNewPassword.Foreground = Brushes.Black;
                TextBoxNewPassword.Visibility     = Visibility.Collapsed;
                PasswordBoxNewPassword.Visibility = Visibility.Visible;
                PasswordBoxNewPassword.Focus();
            }
        }

        private void TextBoxNewPassword_MouseLeave(object sender, MouseEventArgs e)
        {
            if (TextBoxNewPassword.Text == "Enter new pass...")
            {
                TextBoxNewPassword.Text = "";
                TextBoxNewPassword.Foreground     = Brushes.Black;
                PasswordBoxNewPassword.Foreground = Brushes.Black;
                TextBoxNewPassword.Visibility     = Visibility.Collapsed;
                PasswordBoxNewPassword.Visibility = Visibility.Visible;
            }
            ShowPasswordToggleIcon.Kind       = PackIconKind.EyeOff;
            PasswordBoxNewPassword.Password   = TextBoxNewPassword.Text;
            PasswordBoxNewPassword.Visibility = Visibility.Visible;
            TextBoxNewPassword.Visibility     = Visibility.Collapsed;
        }

        private void TextBoxNewRepeatPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxNewRepeatPassword.Text == "Repeat pass...")
            {
                TextBoxNewRepeatPassword.Text = "";
                TextBoxNewRepeatPassword.Foreground     = Brushes.Black;
                PasswordBoxNewRepeatPassword.Foreground = Brushes.Black;
                TextBoxNewRepeatPassword.Visibility     = Visibility.Collapsed;
                PasswordBoxNewRepeatPassword.Visibility = Visibility.Visible;
                PasswordBoxNewRepeatPassword.Focus();
            }
        }


        private void TextBoxNewRepeatPassword_MouseLeave(object sender, MouseEventArgs e)
        {
            if (TextBoxNewRepeatPassword.Text == "Repeat pass...")
            {
                TextBoxNewRepeatPassword.Text = "";
                TextBoxNewRepeatPassword.Foreground     = Brushes.Black;
                PasswordBoxNewRepeatPassword.Foreground = Brushes.Black;
                TextBoxNewRepeatPassword.Visibility     = Visibility.Collapsed;
                PasswordBoxNewRepeatPassword.Visibility = Visibility.Visible;
            }
            ShowRepeatPasswordToggleIcon.Kind       = PackIconKind.EyeOff;
            PasswordBoxNewRepeatPassword.Password   = TextBoxNewRepeatPassword.Text;
            PasswordBoxNewRepeatPassword.Visibility = Visibility.Visible;
            TextBoxNewRepeatPassword.Visibility     = Visibility.Collapsed;
        }

        private void TextBoxNewEmail_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxNewEmail.Text == "Enter new email")
            {
                TextBoxNewEmail.Text = "";
                TextBoxNewEmail.Foreground = Brushes.Black;
            }
        }
    }
}
