using System.Windows;
using System.Windows.Threading;
using WFP_Project.Classes;

namespace WFP_Project
{
    public partial class SecureLogin : Window
    {
        private DispatcherTimer _timer;
        private int _countdownTime = 31;

        public SecureLogin()
        {
            InitializeComponent();
            _timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            _timer.Tick += Timer_Tick;
            StartCountdown();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SettingsManager.ApplySelectedTheme();
        }

        private void StartCountdown()
        {
            _timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            _countdownTime--;
            CountdownTextBlock.Text = $"Retrying in {_countdownTime} seconds...";
            if (_countdownTime <= 0)
            {
                _timer.Stop();
                CountdownTextBlock.Text = "You can now proceed.";
                OkButton.IsEnabled = true;
            }
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
