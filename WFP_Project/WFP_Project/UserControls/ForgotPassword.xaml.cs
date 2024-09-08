using System.Net;
using System.Net.Mail;
using System.Windows;
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
        private bool _isBlocked = false;

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
                    ButtonConfirmEmail.IsEnabled = true;
                    _countdownComplete = true;
                    _timer.Stop();
                }
            }
        }

        private void BlockApplicationFor30Seconds()
        {
            _isBlocked = true;

            ButtonConfirmEmail.IsEnabled = false;
            ButtonSendAgainEmail.IsEnabled = false;
            ButtonConfirmCodeFromEmail.IsEnabled = false;
            TextBoxEnterOldEmail.IsEnabled = false;
            TextBoxConfirmCodeFromEmail.IsEnabled = false;

            _countdownTime = 30;
            _timer.Tick -= Timer_Tick;
            _timer.Tick += BlockTimer_Tick;
            _timer.Start();
        }

        private void BlockTimer_Tick(object sender, EventArgs e)
        {
            if (_countdownTime > 0)
            {
                _countdownTime--;
                ButtonConfirmCodeFromEmail.Content = $"{_countdownTime} seconds remaining";
            }
            else
            {
                ButtonConfirmEmail.IsEnabled = true;
                ButtonSendAgainEmail.IsEnabled = true;
                ButtonConfirmCodeFromEmail.IsEnabled = true;
                TextBoxEnterOldEmail.IsEnabled = true;
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
            return random.Next(100000, 999999).ToString();
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
                MessageBox.Show("Code confirmed, you can now reset your password.");
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
    }
}
