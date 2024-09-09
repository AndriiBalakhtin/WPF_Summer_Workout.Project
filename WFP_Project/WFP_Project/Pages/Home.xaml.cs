using System.Windows;
using WFP_Project.Classes;

namespace WFP_Project.Pages
{
    public partial class Home : Window
    {
        private string _userLogin;
        private string _role;
        public string UserLogin { get; set; }
        public string Role { get; set; }

        public Home()
        {
            InitializeComponent();
        }

        public void SetRole(string userLogin, string role)
        {
            _role = role;
            _userLogin = userLogin;
            TextBlockDataUser.Text = $"Hello! {_userLogin}, your role is: {_role}.";

            var userData = new UserData
            {
                UserLogin = _userLogin,
                Role = _role
            };

            SettingsManager.SaveUserData(userData);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SettingsManager.ApplySelectedTheme();

            try
            {
                var userData = SettingsManager.LoadUserData();
                if (!string.IsNullOrEmpty(userData.UserLogin))
                {
                    TextBlockDataUser.Text = $"Hello! {userData.UserLogin}, your role is: {userData.Role}.";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to load user data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
