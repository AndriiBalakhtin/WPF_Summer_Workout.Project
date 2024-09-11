using MaterialDesignThemes.Wpf;
using System.Net;
using System.Net.Mail;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using WFP_Project.Classes;

namespace WFP_Project.UserControls
{
    public partial class ForgotPassword : Window
    {
        private string _login;
        private string _role;
        private string _confirmationCode;
        private string _emailToConfirm;
        private DispatcherTimer _timer;
        private int _countdownTime;
        private bool _countdownComplete = false;
        private bool _isBlocked         = false;

        public ForgotPassword()
        {
            InitializeComponent();
            _timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            _timer.Tick += Timer_Tick;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SettingsManager.ApplySelectedTheme();
        }

        private void StartCountdown()
        {
            _countdownTime = 31;
            _countdownComplete = false;
            _timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (!_countdownComplete && !_isBlocked)
            {
                _countdownTime--;
                ButtonSendAgainEmail.Content = $"{_countdownTime} seconds remaining";

                if (_countdownTime <= 0)
                {
                    ButtonSendAgainEmail.Content = "Send again";
                    ButtonSendAgainEmail.IsEnabled = true;
                    ButtonConfirmEmail.IsEnabled   = true;
                    _countdownComplete             = true;
                    _timer.Stop();
                }
            }
        }

        private void BlockApplicationFor30Seconds()
        {
            _isBlocked = true;

            ButtonConfirmEmail.IsEnabled          = false;
            ButtonSendAgainEmail.IsEnabled        = false;
            ButtonConfirmCodeFromEmail.IsEnabled  = false;
            TextBoxEnterOldEmail.IsEnabled        = false;
            TextBoxConfirmCodeFromEmail.IsEnabled = false;

            _countdownTime = 31;
            _timer.Tick -= Timer_Tick;
            _timer.Tick += BlockTimer_Tick;
            _timer.Start();
        }

        private void BlockTimer_Tick(object sender, EventArgs e)
        {
            if (_countdownTime > 0)
            {
                _countdownTime--;
                ButtonConfirmCodeFromEmail.Content = $"{_countdownTime} seconds";
            }
            else
            {
                ButtonConfirmEmail.IsEnabled          = true;
                ButtonSendAgainEmail.IsEnabled        = true;
                ButtonConfirmCodeFromEmail.IsEnabled  = true;
                TextBoxEnterOldEmail.IsEnabled        = true;
                TextBoxConfirmCodeFromEmail.IsEnabled = true;

                ButtonConfirmCodeFromEmail.Content = "Confirm Code";
                _isBlocked = false;
                _timer.Stop();
                _timer.Tick -= BlockTimer_Tick;
                _timer.Tick += Timer_Tick;
                StartCountdown();
            }
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

        private void ButtonConfirmEmail_Click(object sender, RoutedEventArgs e)
        {
            _emailToConfirm = TextBoxEnterOldEmail.Text;

            if (string.IsNullOrWhiteSpace(_emailToConfirm))
            {
                MessageBox.Show("Please enter a valid email address.");
                return;
            }

            try
            {
                UserManagement userManagement = new UserManagement();
                if (!userManagement.EmailExists(_emailToConfirm))
                {
                    MessageBox.Show("Email not found.");
                    return;
                }

                var userData = userManagement.GetUserLoginAndRoleByEmail(_emailToConfirm);
                _login = userData.Login;
                _role = userData.Role;

                _confirmationCode = GenerateConfirmationCode();
                SendConfirmationEmail(_emailToConfirm, _confirmationCode);

                ButtonSendAgainEmail.IsEnabled        = true;
                ButtonConfirmEmail.IsEnabled          = true;
                ButtonConfirmCodeFromEmail.IsEnabled  = true;
                TextBoxConfirmCodeFromEmail.IsEnabled = true;
                StartCountdown();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            ButtonSendAgainEmail.IsEnabled = false;
            ButtonConfirmEmail.IsEnabled   = false;
        }

        private string GenerateConfirmationCode()
        {
            Random random = new Random();
            return random.Next(000000000, 999999999).ToString();
        }

        private void SendConfirmationEmail(string toEmail, string code)
        {
            string fromEmail = "wfpworkoutregestration@gmail.com";
            string fromPassword = "ajrx djws crji xhym";

            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress(fromEmail);
                mail.To.Add(toEmail);
                mail.IsBodyHtml = true;
                mail.Subject = $"Password Reset Confirmation Code: {code}";
                mail.Body = $"Welcome back! <b>{_login}</b> <br><br>" +
                            $"Your role is, <b>[ {_role} ]</b> <br><br>" +
                            $"Your password reset confirmation code is: <b>{code}</b>";

                smtpServer.EnableSsl = true;
                smtpServer.Port = 587;
                smtpServer.Credentials = new NetworkCredential(fromEmail, fromPassword);
                smtpServer.Send(mail);
            }
            catch
            {
                throw new Exception("Failed to send email. Please check the email address.");
            }
        }

        private void ButtonSendAgainEmail_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_emailToConfirm))
            {
                MessageBox.Show("Please enter and confirm an email first.");
                return;
            }

            _confirmationCode = GenerateConfirmationCode();

            try
            {
                SendConfirmationEmail(_emailToConfirm, _confirmationCode);
                ButtonSendAgainEmail.IsEnabled = false;
                StartCountdown();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ButtonConfirmCodeFromEmail_Click(object sender, RoutedEventArgs e)
        {
            string enteredCode = TextBoxConfirmCodeFromEmail.Text;

            if (enteredCode == _confirmationCode)
            {
                ForgotPasswordRectangleUI.Visibility        = Visibility.Hidden;
                TextBlockOldEmail.Visibility                = Visibility.Hidden;
                TextBoxEnterOldEmail.Visibility             = Visibility.Hidden;
                ButtonConfirmEmail.Visibility               = Visibility.Hidden;
                TextBlockCheckEmail.Visibility              = Visibility.Hidden;
                TextBoxConfirmCodeFromEmail.Visibility      = Visibility.Hidden;
                ButtonConfirmCodeFromEmail.Visibility       = Visibility.Hidden;
                ButtonSendAgainEmail.Visibility             = Visibility.Hidden;
                ButtonSendAgainEmailRectangleUI.Visibility  = Visibility.Hidden;

                ButtonConfirmPasswordRectangleUI.Visibility = Visibility.Visible;
                TextBlockPassword.Visibility                = Visibility.Visible;
                TextBoxNewPassword.Visibility               = Visibility.Visible;
                ShowPasswordToggleIcon.Visibility           = Visibility.Visible;
                ButtonToggleShowPassword.Visibility         = Visibility.Visible;
                TextBlockRepeatPassword.Visibility          = Visibility.Visible;
                TextBoxNewRepeatPassword.Visibility         = Visibility.Visible;
                ShowRepeatPasswordToggleIcon.Visibility     = Visibility.Visible;
                ButtonToggleShowRepeatPassword.Visibility   = Visibility.Visible;
                ButtonConfirmNewPassword.Visibility         = Visibility.Visible;
            }
            else
            {
                BlockApplicationFor30Seconds();
            }
        }

        private void TextBoxEnterOldEmail_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxEnterOldEmail.Text == "Enter your old email")
            {
                TextBoxEnterOldEmail.Text = "";
                TextBoxEnterOldEmail.Foreground = Brushes.Black;
            }
        }

        private void TextBoxConfirmCodeFromEmail_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxConfirmCodeFromEmail.Text == "Enter the digital code")
            {
                TextBoxConfirmCodeFromEmail.Text = "";
                TextBoxConfirmCodeFromEmail.Foreground = Brushes.Black;
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

        private void ButtonConfirmNewPassword_Click(object sender, RoutedEventArgs e)
        {
            string newPassword    = PasswordBoxNewPassword.Password;
            string repeatPassword = PasswordBoxNewRepeatPassword.Password;

            if (string.IsNullOrWhiteSpace(newPassword) || string.IsNullOrWhiteSpace(repeatPassword))
            {
                MessageBox.Show("Please enter and confirm your new password.");
                return;
            }

            if (newPassword.Length < 8 || newPassword == "Enter new pass...")
            {
                MessageBox.Show("Minimum 8 characters required in password!");
                return;
            }

            if (newPassword != repeatPassword)
            {
                MessageBox.Show("Passwords do not match!");
                return;
            }

            if (newPassword == "12345678" || newPassword == "87654321" ||
                newPassword == "11223344" || newPassword == "44332211")
            {
                MessageBox.Show("we ask for strong passwords");
                return;
            }

            try
            {
                UserManagement userManagement = new UserManagement();
                userManagement.UpdateUserPassword(_login, newPassword);

                var mainWindow = Application.Current.MainWindow as MainWindow;
                if (mainWindow != null)
                {
                    var login = new Login();
                    LoginMenu.ReturnToLoginMenu(login, mainWindow);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while updating the password: {ex.Message}");
            }
        }

    }
}
