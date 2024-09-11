using System.Data.SqlClient;

namespace WFP_Project.Classes.ClassesDatabases
{
    internal class WaterLevelSensorData
    {
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;" +
            "AttachDbFilename=C:\\Reposotory\\WFP\\WPF_Summer.Project\\WFP_Project\\Databases\\WaterLevelSensorData\\WaterLevelSensorData.mdf;" +
            "Integrated Security=True;" +
            "Connect Timeout=30;";

        public void InsertData(double waterLevel)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("INSERT INTO UserSDataSensor (WaterLevel, Timestamp) VALUES (@WaterLevel, @Timestamp)", connection);
                command.Parameters.AddWithValue("@WaterLevel", Math.Round(waterLevel, 2));
                command.Parameters.AddWithValue("@Timestamp", DateTime.Now);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public IEnumerable<(DateTime Timestamp, double WaterLevel)> GetLatestData(int count)
        {
            var data = new List<(DateTime Timestamp, double WaterLevel)>();

            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand("SELECT TOP (@Count) Timestamp, WaterLevel FROM UserSDataSensor ORDER BY Timestamp DESC", connection);
                command.Parameters.AddWithValue("@Count", count);

                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var timestamp = reader.GetDateTime(0);
                        var waterLevel = reader.GetDouble(1);
                        data.Add((timestamp, waterLevel));
                    }
                }
            }

            return data;
        }
    }
}
