using System.Net.Mail;
using System.Net;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using WFP_Project.Classes;
using WFP_Project.Pages;

namespace WFP_Project.UserControls
{
    public partial class ConfirmEmail : Window
    {
        private string _confirmationCode;
        private string _login;
        private string _password;
        private string _role;
        private string _emailToConfirm;

        private DispatcherTimer _timer;
        private int _countdownTime;
        private bool _countdownComplete = false;

        public ConfirmEmail(string confirmationCode, string login, string password, string role, string emailToConfirm)
        {
            InitializeComponent();
            _confirmationCode = confirmationCode;
            _login = login;
            _password = password;
            _role = role;
            _emailToConfirm = emailToConfirm;

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
            ButtonSendAgainEmail.IsEnabled = false;
            _timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (!_countdownComplete)
            {
                _countdownTime--;
                ButtonSendAgainEmail.Content = $"{_countdownTime} seconds remaining";

                if (_countdownTime <= 0)
                {
                    ButtonSendAgainEmail.Content = "Send again";
                    ButtonSendAgainEmail.IsEnabled = true;
                    _countdownComplete = true;
                    _timer.Stop();
                }
            }
        }

        private void RadioButtonReturnBackToSignUp_Checked(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            if (mainWindow != null)
            {
                var signUp = new SignUp();
                SignUpMenu.ReturnToSignUpMenu(signUp, mainWindow);
            }
        }

        private void ButtonConfirmEmail_Click(object sender, RoutedEventArgs e)
        {
            string enteredCode = TextBoxConfirmationCode.Text;

            if (enteredCode == _confirmationCode)
            {
                if (_role == "Athlete" || _role == "Instructor")
                {
                    UserManagement userManagement = new UserManagement();
                    userManagement.SaveUserConfirmationData(_login, _password, _role, _emailToConfirm, _confirmationCode);

                    MessageBox.Show($"Your account is pending confirmation.\n\nToolTip: Ask for help from the {(_role == "Athlete" ? "instructor" : "administrator")} if they take a long time.");

                    var mainWindow = Application.Current.MainWindow as MainWindow;
                    if (mainWindow != null)
                    {
                        var login = new Login();
                        LoginMenu.ReturnToLoginMenu(login, mainWindow);
                    }
                    Close();
                }
                else
                {
                    UserManagement userManagement = new UserManagement();
                    userManagement.SaveUserData(_login, _password, _role, _emailToConfirm);

                    var mainWindow = Application.Current.MainWindow as MainWindow;
                    if (mainWindow != null)
                    {
                        var login = new Login();
                        LoginMenu.ReturnToLoginMenu(login, mainWindow);
                    }
                    Close();
                }
            }
            else
            {
                MessageBox.Show("Invalid confirmation code.");
            }
        }


        private void TextBoxConfirmationCode_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxConfirmationCode.Text == "Enter the digital code")
            {
                TextBoxConfirmationCode.Text = "";
                TextBoxConfirmationCode.Foreground = Brushes.Black;
            }
        }

        private void ButtonSendAgainEmail_Click(object sender, RoutedEventArgs e)
        {
            StartCountdown();

            _confirmationCode = GenerateConfirmationCode();

            try
            {
                SendConfirmationEmail(_emailToConfirm, _confirmationCode);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
        }

        private string GenerateConfirmationCode()
        {
            Random random = new Random();
            return random.Next(000000, 999999).ToString();
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
                mail.Subject = $"Email Confirmation Code: {code}";
                mail.Body = $"Hello, <b>{_login}</b> <br><br>" +
                            $"Your role is <b>[ {_role} ]</b> <br><br>" +
                            $"Thank you for registering. Your confirmation code is: <b>{code}</b>";

                smtpServer.EnableSsl = true;
                smtpServer.Port = 587; // 587 - TLS, 465 - SSL [Google]
                smtpServer.Credentials = new NetworkCredential(fromEmail, fromPassword);
                smtpServer.Send(mail);
            }
            catch
            {
                throw new Exception("Incorrect email address");
            }
        }
    }
}
