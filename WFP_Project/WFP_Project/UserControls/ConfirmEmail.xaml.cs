using System.Windows;
using System.Windows.Media;
using WFP_Project.Classes;

namespace WFP_Project.UserControls
{
    public partial class ConfirmEmail : Window
    {
        private string _confirmationCode;
        private string _login;
        private string _password;
        private string _role;
        private string _emailToConfirm;
        public ConfirmEmail(string confirmationCode, string login, string password, string role, string emailToConfirm)
        {
            InitializeComponent();
            _confirmationCode = confirmationCode;
            _login = login;
            _password = password;
            _role = role;
            _emailToConfirm = emailToConfirm;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SettingsManager.ApplySelectedTheme();
        }

        private void ButtonConfirmEmail_Click(object sender, RoutedEventArgs e)
        {
            string enteredCode = TextBoxConfirmationCode.Text;

            if (enteredCode == _confirmationCode)
            {
                UserManagement userManagement = new UserManagement();
                userManagement.SaveUserData(_login, _password, _role, _emailToConfirm);
                MessageBox.Show("Registration successful!");

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
    }
}
