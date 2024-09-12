using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace WFP_Project.Classes.ClassesDatabases
{
    internal class AdminSQL
    {
        private readonly string connectionStringUserManagement = "Data Source=(LocalDB)\\MSSQLLocalDB;" +
            "AttachDbFilename=C:\\Reposotory\\WFP\\WPF_Summer.Project\\WFP_Project\\Databases\\UserManagement\\UserManagement.mdf;" +
            "Integrated Security=True;Connect Timeout=30";

        private readonly string connectionStringDatabase = "Data Source=(LocalDB)\\MSSQLLocalDB;" +
            "AttachDbFilename=C:\\Reposotory\\WFP\\WPF_Summer.Project\\WFP_Project\\Databases\\Database\\DataBase.mdf;" +
            "Integrated Security=True;" +
            "Connect Timeout=30";

        private string connectionStringWaterLevelSensorData = "Data Source=(LocalDB)\\MSSQLLocalDB;" +
            "AttachDbFilename=C:\\Reposotory\\WFP\\WPF_Summer.Project\\WFP_Project\\Databases\\WaterLevelSensorData\\WaterLevelSensorData.mdf;" +
            "Integrated Security=True;" +
            "Connect Timeout=30;";


        public DataTable ExecuteSQLQuery(string query, string database)
        {
            string connectionString = GetConnectionString(database);

            if (string.IsNullOrEmpty(connectionString))
            {
                MessageBox.Show("Error with database");
                return null;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable resultTable = new DataTable();
                    adapter.Fill(resultTable);
                    return resultTable;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"SQL Error: {ex.Message}");
                    return null;
                }
            }
        }

        private string GetConnectionString(string database)
        {
            switch (database)
            {
                case "DataBase":
                    return connectionStringDatabase;
                case "UserManagement":
                    return connectionStringUserManagement;
                case "WaterLevelSensorData":
                    return connectionStringWaterLevelSensorData;
                default:
                    return null;
            }
        }

        public DataTable GetAllTableNames(string database)
        {
            string connectionString = GetConnectionString(database);
            if (string.IsNullOrEmpty(connectionString))
            {
                MessageBox.Show("Error with database");
                return null;
            }

            string query = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable resultTable = new DataTable();
                    adapter.Fill(resultTable);
                    return resultTable;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"SQL Error: {ex.Message}");
                    return null;
                }
            }
        }
    }
}
