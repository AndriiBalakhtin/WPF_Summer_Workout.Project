using System.Net;
using System.Net.Mail;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using WFP_Project.Classes;

namespace WFP_Project.UserControls
{
    public partial class SignUp : Window
    {
        private string _confirmationCode;
        private string _emailToConfirm;
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
            _password = TextBoxNewPassword.Text;
            string repeatPassword = TextBoxNewRepeatPassword.Text;
            _emailToConfirm = TextBoxNewEmail.Text;

            if (ComboBoxNewRoleType.SelectedItem is ComboBoxItem selectedRole)
            {
                _role = selectedRole.Content.ToString();
            }

            if (_password != repeatPassword)
            {
                MessageBox.Show("Passwords do not match!");
                return;
            }

            UserManagement userManagement = new UserManagement();
            bool emailExists = userManagement.EmailExists(_emailToConfirm); // Новый метод проверки email

            if (emailExists)
            {
                MessageBox.Show("This email is already registered. Please use a different email.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            _confirmationCode = GenerateConfirmationCode();

            try
            {
                SendConfirmationEmail(_emailToConfirm, _confirmationCode);

                var confirmEmail = new ConfirmEmail(_confirmationCode, _login, _password, _role, _emailToConfirm);
                var mainWindow = Application.Current.MainWindow as MainWindow;
                if (mainWindow != null)
                {
                    ConfirmEmailMenu.Email(confirmEmail, mainWindow);
                }
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
            return random.Next(100000, 999999).ToString();
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
                mail.Subject = "Email Confirmation Code";
                mail.Body = $"Hello!!!\n\n" +
                            $"Thank you for registering. Your confirmation code is: {code}\n\n" +
                            $"Best regards,\n" +
                            $"From Your Company";

                SmtpServer.Port = 587; // 587 - TLS 465 - SSL [Google]
                SmtpServer.Credentials = new NetworkCredential(fromEmail, fromPassword);
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
            }
            catch
            {
                throw new Exception($"Incorrect email address");
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
            if (TextBoxNewPassword.Text == "Enter new password")
            {
                TextBoxNewPassword.Text = "";
                TextBoxNewPassword.Foreground = Brushes.Black;
            }
        }

        private void TextBoxNewRepeatPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxNewRepeatPassword.Text == "Repeat password")
            {
                TextBoxNewRepeatPassword.Text = "";
                TextBoxNewRepeatPassword.Foreground = Brushes.Black;
            }
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
