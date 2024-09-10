using System.Windows;
using WFP_Project.Classes;
using WFP_Project.Enums;

namespace WFP_Project.Pages
{
    public partial class Home : Window
    {
        private string _userLogin;
        private string _role;

        public Home()
        {
            InitializeComponent();
            UpdateUserDataJson();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SettingsManager.ApplySelectedTheme();
        }

        public void UpdateUserDataJson(string userLogin = null, string role = null)
        {
            if (userLogin != null && role != null)
            {
                _userLogin = userLogin;
                _role = role;

                var userData = new UserData
                {
                    UserLogin = _userLogin,
                    Role = _role
                };

                SettingsManager.SaveUserData(userData);

                TextBlockDataUser.Text = $"Hello! {_userLogin}, your role is: {_role}";
            }
            else
            {
                try
                {
                    var userData = SettingsManager.LoadUserData();
                    if (!string.IsNullOrEmpty(userData.UserLogin))
                    {
                        TextBlockDataUser.Text = $"Hello! {userData.UserLogin}, your role is: {userData.Role}";
                    }
                    else
                    {
                        TextBlockDataUser.Text = "No user data available.";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Failed to load user data: {ex.Message}", 
                                    "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
