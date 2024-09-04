﻿using System.Windows;
using WFP_Project.UserControls;

namespace WFP_Project.Classes
{
    public static class LoginSuccess
    {
        public static void HideBlockUserControl(MainWindow mainWindow)
        {
            if (mainWindow != null)
            {
                mainWindow.BlockUserControl.Visibility = Visibility.Collapsed;
                mainWindow.LockIcon.Visibility = Visibility.Collapsed;

                mainWindow.ResizeMode = ResizeMode.CanResize;
                mainWindow.Height = 600; mainWindow.Width = 1140; mainWindow.MinHeight = 600; mainWindow.MinWidth = 1140;
            }
        }
    }
    public static class LoginMenu
    {
        public static void ReturnToLoginMenu(Login login, MainWindow mainWindow)
        {
            if (login != null && mainWindow != null)
            {
                mainWindow.MainContentControl.Content = login.Content;
            }
        }
    }
    public static class SignUpMenu
    {
        public static void ReturnToSignUpMenu(SignUp signUp, MainWindow mainWindow)
        {
            if (signUp != null && mainWindow != null)
            {
                mainWindow.MainContentControl.Content = signUp.Content;
            }
        }
    }
}