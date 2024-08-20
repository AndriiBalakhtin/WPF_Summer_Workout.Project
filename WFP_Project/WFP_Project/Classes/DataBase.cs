using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace WFP_Project.Classes
{
    public static class DataBase
    {
        private static string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;" +
                                                 "AttachDbFilename=C:\\Reposotory\\C#\\Summer_product.api\\DataBase.mdf;" +
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

        public static void InsertUserData(string force, string repeate1st, string weight, string repeate2nd, string goal, string repeate3rd)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO [UserS] (Force, [1st], Weight, [2nd], Goal, [3rd]) " +
                               "VALUES (@Force, @1st, @Weight, @2nd, @Goal, @3rd)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Force", force);
                    cmd.Parameters.AddWithValue("@1st", repeate1st);
                    cmd.Parameters.AddWithValue("@Weight", weight);
                    cmd.Parameters.AddWithValue("@2nd", repeate2nd);
                    cmd.Parameters.AddWithValue("@Goal", goal);
                    cmd.Parameters.AddWithValue("@3rd", repeate3rd);

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
                string query = "UPDATE [UserS]" +
                    "SET Force = @Force, [1st] = @1st, Weight = @Weight, [2nd] = @2nd, Goal = @Goal, [3rd] = @3rd WHERE Id = @Id";

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
    }
}
