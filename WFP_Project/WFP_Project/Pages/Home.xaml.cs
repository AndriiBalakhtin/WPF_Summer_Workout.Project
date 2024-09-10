using MQTTnet;
using MQTTnet.Client;
using System.Text;
using System.Windows;
using System.Windows.Threading;
using WFP_Project.Classes;
using WFP_Project.Enums;

namespace WFP_Project.Pages
{
    public partial class Home : Window
    {
        private string _userLogin;
        private string _role;
        private IMqttClient _mqttClient;
        private DispatcherTimer _timer;

        public Home()
        {
            InitializeComponent();
            UpdateUserDataJson();
            InitializeTimer();
            MQTT();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SettingsManager.ApplySelectedTheme();
        }

        private async void MQTT()
        {
            string topic = "fdSZlsSff2jQHdsjQWZA21o397W31wSdmvfSahj92183dOksji";

            var factory = new MqttFactory();
            _mqttClient = factory.CreateMqttClient();
            var options = new MqttClientOptionsBuilder()
                .WithTcpServer("broker.hivemq.com", 1883)
                .WithCleanSession()
                .Build();

            try
            {
                await _mqttClient.ConnectAsync(options);

                if (_mqttClient.IsConnected)
                {
                    await _mqttClient.SubscribeAsync(topic);

                    _mqttClient.ApplicationMessageReceivedAsync += async e =>
                    {
                        string message = Encoding.UTF8.GetString(e.ApplicationMessage.PayloadSegment);
                        Dispatcher.Invoke(() => TextBlockMqttData.Text = $"Water Level {message}");
                        await Task.CompletedTask;
                    };
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Exception occurred while connecting to MQTT broker: {ex.Message}",
                                "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void InitializeTimer()
        {
            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(5)
            };
            _timer.Start();
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

        private void Window_Closed(object sender, EventArgs e)
        {
            if (_mqttClient != null && _mqttClient.IsConnected)
            {
                _mqttClient.UnsubscribeAsync("fdsffj21o39dfhj92183dsji").Wait();
                _mqttClient.DisconnectAsync().Wait();
            }

            if (_timer != null)
            {
                _timer.Stop();
            }
        }
    }
}
