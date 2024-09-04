using System.Windows;
using WFP_Project.Classes;
using WFP_Project.UserControls;

namespace WFP_Project.Windows
{
    public partial class FirstStep : Window
    {
        public FirstStep()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SettingsManager.ApplySelectedTheme();
        }

        private void RadioButtonLogin_Checked(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            FirstStepContent.Content = login.Content;
            {
                TextBlockWelcome.Visibility     = Visibility.Hidden;
                RadioButtonLogin.Visibility     = Visibility.Hidden;
                RadioButtonSignUp.Visibility    = Visibility.Hidden;
                FirstStepRectangleUI.Visibility = Visibility.Hidden;
            }
        }

        private void RadioButtonSignUp_Checked(object sender, RoutedEventArgs e)
        {
            SignUp signUp = new SignUp();
            FirstStepContent.Content = signUp.Content;
            {
                TextBlockWelcome.Visibility     = Visibility.Hidden;
                RadioButtonLogin.Visibility     = Visibility.Hidden;
                RadioButtonSignUp.Visibility    = Visibility.Hidden;
                FirstStepRectangleUI.Visibility = Visibility.Hidden;
            }
        }
    }
}
