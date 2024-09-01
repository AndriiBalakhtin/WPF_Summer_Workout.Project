using System.Windows;
using WFP_Project.Classes;
using WFP_Project.Enums;
using WFP_Project.Pages;
namespace WFP_Project
{
    public partial class MainWindow : Window
    {
        private AppSettings appSettings;
        private ApplyThemes applyThemes;

        public MainWindow()
        {
            InitializeComponent();

            appSettings = SettingsManager.LoadSettings();
            applyThemes = new ApplyThemes();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            applyThemes.ApplyTheme(appSettings.SelectedTheme);
            this.ResizeMode = ResizeMode.NoResize;
        }

        public event EventHandler LoginSuccessful;

        private void Button_Login_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateLogin())
            {
                if (TextBoxLogin.Text == "Admin" && TextBoxPassword.Text == "123456")
                {
                    this.Height = 600; this.Width = 1140; this.MinHeight = 600; this.MinWidth = 1140; this.ResizeMode = ResizeMode.CanResize;
                    LoginSuccessful?.Invoke(this, EventArgs.Empty);
                    BlockUserControl.Visibility = Visibility.Collapsed;
                    TextBoxLogin.Visibility = Visibility.Collapsed;
                    TextBoxPassword.Visibility = Visibility.Collapsed;
                    ComboBoxRoleType.Visibility = Visibility.Collapsed;
                    ButtonLogin.Visibility = Visibility.Collapsed;
                    LockIcon.Visibility = Visibility.Collapsed;
                }
            }
            else
            {
                MessageBox.Show("Login failed. Please try again.");
            }
        }

        private bool ValidateLogin()
        {
            return true;
        }

        private void TextBoxLogin_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxLogin.Text = "";
        }

        private void TextBoxPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            TextBoxPassword.Text = "";
        }

        private void RadioButton_HomeChecked(object sender, RoutedEventArgs e)
        {
            Home homeWindow = new Home();
            MainContentControl.Content = homeWindow.Content;
        }

        private void RadioButton_ControlsChecked(object sender, RoutedEventArgs e)
        {
            ControlWindow controlsWindow = new ControlWindow();
            MainContentControl.Content = controlsWindow.Content;
        }

        private void RadioButton_ArchiveChecked(object sender, RoutedEventArgs e)
        {
            ArchiveWindow archiveWindow = new ArchiveWindow();
            MainContentControl.Content = archiveWindow.Content;
        }

        private void RadioButton_SettingsChecked(object sender, RoutedEventArgs e)
        {
            SettingsWindow settingsWindow = new SettingsWindow();
            MainContentControl.Content = settingsWindow.Content;
        }
    }
}
