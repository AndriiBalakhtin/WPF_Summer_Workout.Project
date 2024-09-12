using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace WFP_Project.Classes
{
    public static class DataBase
    {
        private static readonly string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;" +
            "AttachDbFilename=C:\\Reposotory\\WFP\\WPF_Summer.Project\\WFP_Project\\Databases\\Database\\DataBase.mdf;" +
            "Integrated Security=True;" +
            "Connect Timeout=30";

        public static DataTable GetUserData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM [UserS]";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();

                try
                {
                    conn.Open();
                    dataAdapter.Fill(dataTable);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while loading data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                return dataTable;
            }
        }
        public static void InsertUserData(string force, string repeate1st, string weight, string repeate2nd, string goal, string repeate3rd, int difficulty, string description, string category)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO [UserS] (Force, [1st], Weight, [2nd], Goal, [3rd], Difficulty, Description, Category) " +
                               "VALUES (@Force, @1st, @Weight, @2nd, @Goal, @3rd, @Difficulty, @Description, @Category)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Force", force);
                    cmd.Parameters.AddWithValue("@1st", repeate1st);
                    cmd.Parameters.AddWithValue("@Weight", weight);
                    cmd.Parameters.AddWithValue("@2nd", repeate2nd);
                    cmd.Parameters.AddWithValue("@Goal", goal);
                    cmd.Parameters.AddWithValue("@3rd", repeate3rd);
                    cmd.Parameters.AddWithValue("@Difficulty", difficulty);
                    cmd.Parameters.AddWithValue("@Description", description);
                    cmd.Parameters.AddWithValue("@Category", category);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while inserting data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        public static void UpdateUserData(string id, string force, string repeate1st, string weight, string repeate2nd, string goal, string repeate3rd)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE [UserS] " +
                               "SET Force = @Force, [1st] = @1st, Weight = @Weight, [2nd] = @2nd, Goal = @Goal, [3rd] = @3rd " +
                               "WHERE Id = @Id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Force", force);
                    cmd.Parameters.AddWithValue("@1st", repeate1st);
                    cmd.Parameters.AddWithValue("@Weight", weight);
                    cmd.Parameters.AddWithValue("@2nd", repeate2nd);
                    cmd.Parameters.AddWithValue("@Goal", goal);
                    cmd.Parameters.AddWithValue("@3rd", repeate3rd);
                    cmd.Parameters.AddWithValue("@Id", id);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while updating data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        public static void DeleteUserData(string id)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM [UserS] WHERE Id = @Id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while deleting data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        public static void DeleteTable(string tableName)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = $"DROP TABLE [{tableName}]";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while deleting the table '{tableName}': {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        public static void ArchiveUserData(string tableName)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string checkTableQuery = $"IF OBJECT_ID('{tableName}', 'U') IS NOT NULL SELECT 1 ELSE SELECT 0";
                string createTableQuery = $"SELECT * INTO [{tableName}] FROM [UserS]";

                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.Connection = conn;

                    try
                    {
                        conn.Open();

                        cmd.CommandText = checkTableQuery;
                        int tableExists = (int)cmd.ExecuteScalar();

                        if (tableExists == 1)
                        {
                            throw new Exception("Table with this name already exists. Please choose a different name.");
                        }
                        else
                        {
                            cmd.CommandText = createTableQuery;
                            cmd.ExecuteNonQuery();
                            MessageBox.Show($"Data successfully archived to table '{tableName}'", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while archiving data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        public static DataTable GetTableData(string tableName)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = $"SELECT * FROM [{tableName}]";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();

                try
                {
                    conn.Open();
                    dataAdapter.Fill(dataTable);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while loading data from table '{tableName}': {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }

                return dataTable;
            }
        }

        public static List<string> GetArchivedTableNames()
        {
            List<string> tableNames = new List<string>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME <> 'UserS'";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    try
                    {
                        conn.Open();

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                tableNames.Add(reader["TABLE_NAME"].ToString());
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while retrieving table names: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }

            return tableNames;
        }
    }
}