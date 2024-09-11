using LiveCharts;
using LiveCharts.Wpf;
using MQTTnet;
using MQTTnet.Client;
using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Threading;
using WFP_Project.Classes;
using WFP_Project.Classes.ClassesDatabases;
using WFP_Project.Enums;

namespace WFP_Project.Pages
{
    public partial class Home : Window
    {
        private string _userLogin;
        private string _role;
        private IMqttClient _mqttClient;
        private DispatcherTimer _timer;
        private WaterLevelSensorData _dataHandler;

        public ChartValues<double> SeriesValues { get; set; }
        public Func<double, string> XFormatter { get; set; }
        public Func<double, string> YFormatter { get; set; }

        public static int samples = 10;

        public Home()
        {
            InitializeComponent();
            SeriesValues = new ChartValues<double>();
            XFormatter   = value => new DateTime((long)value).ToString("HH:mm:ss");
            YFormatter   = value => value.ToString("0.00");
            DataContext  = this;
            _dataHandler = new WaterLevelSensorData();
            UpdateUserDataJson();
            InitializeTimer();
            LoadChartData();
            MQTT();

            cartesianChartWaterLevelData.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Water Level",
                    Values = SeriesValues
                }
            };
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SettingsManager.ApplySelectedTheme();
        }

        private void InitializeTimer()
        {
            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(5)
            };
            _timer.Tick += (sender, args) =>
            {
                LoadChartData();
            };
            _timer.Start();
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
                        string message = Encoding.UTF8.GetString(e.ApplicationMessage.PayloadSegment).Trim();
                        string cleanedMessage = System.Text.RegularExpressions.Regex.Replace(message, @"[^0-9.,-]", "");

                        if (double.TryParse(cleanedMessage, NumberStyles.Any, CultureInfo.InvariantCulture, out double waterLevel))
                        {
                            waterLevel *= 26.6;
                            _dataHandler.InsertData(waterLevel);

                            Dispatcher.Invoke(() =>
                            {
                                LoadChartData();
                                TextBlockMqttData.Text = $"Water Level: {waterLevel:0.00}%";
                            });
                        }
                        else
                        {
                            MessageBox.Show($"Failed to parse message to double: '{cleanedMessage}'");
                        }
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

        private void LoadChartData()
        {
            try
            {
                var data = _dataHandler.GetLatestData(20);
                SeriesValues.Clear();

                foreach (var (timestamp, waterLevel) in data.OrderBy(d => d.Timestamp))
                {
                    SeriesValues.Add(waterLevel);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading chart data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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
                _mqttClient.UnsubscribeAsync("fdSZlsSff2jQHdsjQWZA21o397W31wSdmvfSahj92183dOksji").Wait();
                _mqttClient.DisconnectAsync().Wait();
            }

            if (_timer != null)
            {
                _timer.Stop();
            }
        }
    }
}
