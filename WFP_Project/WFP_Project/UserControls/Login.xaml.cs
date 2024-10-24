﻿/*
 * © [2024] Andrii Balakhtin
 * 
 * All rights reserved.
 * 
 * This code and all its parts are the property of Andrii Balakhtin. 
 * Distribution, copying, modification, or use of this code 
 * without explicit written permission from the owner is prohibited.
 * 
 * Unauthorized use or distribution of this code may result in civil, administrative, or criminal penalties 
 * in accordance with copyright laws.
 */

using System.Windows;
using System.Windows.Media;
using WFP_Project.Classes;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using MaterialDesignThemes.Wpf;
using WFP_Project.Pages;


namespace WFP_Project.UserControls
{
    public partial class Login : Window
    {
        private UserManagement _userManagement;
        private ToggleButton _toggleButton;

        public Login()
        {
            InitializeComponent();
            _toggleButton = (ToggleButton)FindName("ToggleButton");
            _userManagement = new UserManagement();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SettingsManager.ApplySelectedTheme();
        }

        private void RadioButtonSignUp_Checked(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            if (mainWindow != null)
            {
                var signUp = new SignUp();
                SignUpMenu.ReturnToSignUpMenu(signUp, mainWindow);
            }
        }

        private void Button_Login_Click(object sender, RoutedEventArgs e)
        {
            string loginOrEmail = TextBoxLogin.Text.Trim();
            string password = PasswordBoxPassword.Password.Trim();
            string role = ComboBoxRoleType.Text.Trim();

            PasswordBoxPassword.Password   = TextBoxPassword.Text;
            ShowPasswordToggleIcon.Kind    = PackIconKind.EyeOff;
            PasswordBoxPassword.Foreground = Brushes.Black;
            TextBoxPassword.Foreground     = Brushes.Black;

            if (string.IsNullOrEmpty(loginOrEmail) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(role))
            {
                MessageBox.Show("Please fill in all fields.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            (bool isAuthenticated, string userLogin) = _userManagement.ReadUser(loginOrEmail, password, role);

            if (isAuthenticated)
            {
                ResizeWindowForAuthenticatedUser();

                MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
                LoginSuccess.HideBlockUserControl(mainWindow, role);

                Home home = new Home();
                home.UpdateUserDataJson(userLogin, role);

                HomeMenu.Home(home, mainWindow);

                HideLoginUIElements();
            }
            else
            {
                SecureLogin secureLogin = new SecureLogin();
                secureLogin.ShowDialog();
            }
        }


        private void ResizeWindowForAuthenticatedUser()
        {
            this.ResizeMode = ResizeMode.CanResize;
            this.Height = 600; this.Width = 1140; this.MinHeight = 600; this.MinWidth = 1140;         
        }

        private void HideLoginUIElements()
        {
            LoginRectangleUI.Visibility                = Visibility.Hidden;
            RadioButtonSignUp.Visibility               = Visibility.Hidden;
            TextBlockLogin.Visibility                  = Visibility.Hidden;
            TextBlockPassword.Visibility               = Visibility.Hidden;
            TextBlockRole.Visibility                   = Visibility.Hidden;
            TextBoxLogin.Visibility                    = Visibility.Hidden;
            TextBoxPassword.Visibility                 = Visibility.Hidden;
            PasswordBoxPassword.Visibility             = Visibility.Hidden;
            ShowPasswordToggleIcon.Visibility          = Visibility.Hidden;
            ComboBoxRoleType.Visibility                = Visibility.Hidden;
            ButtonLogin.Visibility                     = Visibility.Hidden;
            ButtonForgotPasswordRectangleUI.Visibility = Visibility.Hidden;
            ButtonForgotPassword.Visibility            = Visibility.Hidden;
        }

        private void TextBoxLogin_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxLogin.Text == "Enter login")
            {
                TextBoxLogin.Text = "";
                TextBoxLogin.Foreground = Brushes.Black;
            }
        }

        private void ButtonToggleShowPassword_Click(object sender, RoutedEventArgs e)
        {
            if (TextBoxPassword.Text == "Enter pass...")
            {
                TextBoxPassword.Text = "";
                TextBoxPassword.Foreground     = Brushes.Black;
                PasswordBoxPassword.Foreground = Brushes.Black;
                TextBoxPassword.Visibility     = Visibility.Collapsed;
                PasswordBoxPassword.Visibility = Visibility.Visible;
                PasswordBoxPassword.Focus();
            }
            if (PasswordBoxPassword.Visibility == Visibility.Visible)
            {
                ShowPasswordToggleIcon.Kind    = PackIconKind.Eye;
                TextBoxPassword.Text           = PasswordBoxPassword.Password;
                TextBoxPassword.Visibility     = Visibility.Visible;
                PasswordBoxPassword.Visibility = Visibility.Collapsed;
            }
            else
            {
                ShowPasswordToggleIcon.Kind    = PackIconKind.EyeOff;
                PasswordBoxPassword.Password   = TextBoxPassword.Text;
                PasswordBoxPassword.Visibility = Visibility.Visible;
                TextBoxPassword.Visibility     = Visibility.Collapsed;
            }
        }

        private void TextBoxPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxPassword.Text == "Enter pass...")
            {
                TextBoxPassword.Text = "";
                TextBoxPassword.Foreground     = Brushes.Black;
                PasswordBoxPassword.Foreground = Brushes.Black;
                TextBoxPassword.Visibility     = Visibility.Collapsed;
                PasswordBoxPassword.Visibility = Visibility.Visible;
                PasswordBoxPassword.Focus();
            }
        }

        private void PasswordBoxPassword_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            TextBoxPassword.Text = PasswordBoxPassword.Password;
            if ((Keyboard.Modifiers == ModifierKeys.Control) && (e.Key == Key.C || e.Key == Key.V))
            {
                e.Handled = true;
            }
        }

        private void TextBoxPassword_MouseLeave(object sender, MouseEventArgs e)
        {
            if (TextBoxPassword.Text == "Enter pass...")
            {
                TextBoxPassword.Text = "";
                TextBoxPassword.Foreground     = Brushes.Black;
                PasswordBoxPassword.Foreground = Brushes.Black;
                TextBoxPassword.Visibility     = Visibility.Collapsed;
                PasswordBoxPassword.Visibility = Visibility.Visible;
            }
            ShowPasswordToggleIcon.Kind = PackIconKind.EyeOff;
            PasswordBoxPassword.Password = TextBoxPassword.Text;
            PasswordBoxPassword.Visibility = Visibility.Visible;
            TextBoxPassword.Visibility = Visibility.Collapsed;
        }

        private void TextBoxPassword_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            PasswordBoxPassword.Password = TextBoxPassword.Text;
            if ((Keyboard.Modifiers == ModifierKeys.Control) && (e.Key == Key.C || e.Key == Key.V))
            {
                e.Handled = true;
            }
        }

        private void ButtonForgotPassword_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = Application.Current.MainWindow as MainWindow;
            if (mainWindow != null)
            {
                var forgotPassword = new ForgotPassword();
                ForgotPasswordMenu.ForgotPassword(forgotPassword, mainWindow);
            }
        }
    }
}
