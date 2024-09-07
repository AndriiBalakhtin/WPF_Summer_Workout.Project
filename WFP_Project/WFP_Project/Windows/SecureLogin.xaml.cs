using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;
using WFP_Project.Classes;

namespace WFP_Project
{
    public partial class SecureLogin : Window
    {
        private DispatcherTimer _timer;
        private int _countdownTime = 31;
        private bool _countdownComplete = false;

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
            if (!_countdownComplete)
            {
                _countdownTime--;
                CountdownTextBlock.Text = $"     Retrying in {_countdownTime} seconds...";
                if (_countdownTime <= 0)
                {
                    _timer.Interval = TimeSpan.FromMilliseconds(1000);
                    CountdownTextBlock.Text = "You can now proceed.";
                    CheckIcon.Visibility = Visibility.Visible;
                    AlertFirstIcon.Visibility  = Visibility.Hidden;
                    AlertSecondIcon.Visibility = Visibility.Hidden;
                    TextBlockFailed.Visibility = Visibility.Hidden;
                    OkButton.IsEnabled = true;
                    _countdownComplete = true;
                }
            }
            else
            {
                var animationDuration = TimeSpan.FromMilliseconds(250);
                var colorAnimation = new System.Windows.Media.Animation.ColorAnimation
                {
                    From = Colors.Transparent,
                    To = Colors.LawnGreen,
                    AutoReverse = true,
                    Duration = new Duration(animationDuration)
                };

                var brush = new SolidColorBrush();
                brush.BeginAnimation(SolidColorBrush.ColorProperty, colorAnimation);
                OkButton.Background = brush;
            }
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            _timer.Stop();
            OkButton.Background = Brushes.Transparent;
            this.Close();
        }
    }
}
