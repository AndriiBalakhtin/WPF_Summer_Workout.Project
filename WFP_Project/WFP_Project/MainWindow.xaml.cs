/*
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
using WFP_Project.Classes;
using WFP_Project.Pages;
using WFP_Project.Windows;

namespace WFP_Project
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SettingsManager.ApplySelectedTheme();
            this.ResizeMode = ResizeMode.NoResize;

            FirstStep firstStep = new FirstStep();
            MainContentControl.Content = firstStep.Content;
        }

        private void RadioButton_AdminChecked(object sender, RoutedEventArgs e)
        {
            AdminPanel adminPanel = new AdminPanel();
            MainContentControl.Content = adminPanel.Content;
        }

        private void RadioButton_HomeChecked(object sender, RoutedEventArgs e)
        {
            Home homeWindow = new Home();
            MainContentControl.Content = homeWindow.Content;
        }

        private void RadioButton_NoticeChecked(object sender, RoutedEventArgs e)
        {
            Notice notice = new Notice();
            MainContentControl.Content = notice.Content;
        }

        private void RadioButton_SessionChecked(object sender, RoutedEventArgs e)
        {
            Session sessionWindow = new Session();
            MainContentControl.Content = sessionWindow.Content;
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

        private void RadioButton_LogoutChecked(object sender, RoutedEventArgs e)
        {
            string exePath = System.Reflection.Assembly.GetEntryAssembly().Location.Replace(".dll", ".exe");

            var newProcess = new System.Diagnostics.ProcessStartInfo
            {
                FileName = exePath,
                UseShellExecute = true
            };
            System.Diagnostics.Process.Start(newProcess);

            Application.Current.Shutdown();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
