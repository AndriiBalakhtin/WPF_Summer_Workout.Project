using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace WFP_Project.Classes
{
    internal class UserManagement
    {
        private static readonly string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;" +
            "AttachDbFilename=C:\\Reposotory\\WFP\\WFP_Summer.Project\\WFP_Project\\Databases\\UserManagement\\UserManagement.mdf;" +
            "Integrated Security=True;Connect Timeout=30";

        public DataTable GetUserData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM [UserSData]";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();

                try
                {
                    conn.Open();
                    dataAdapter.Fill(dataTable);
                }
                catch (Exception ex)
                {
                    throw new Exception($"An error occurred while loading data: {ex.Message}");
                }

                return dataTable;
            }
        }

        public bool VerifyUser(string login, string password, string role)
        {
            DataTable usersTable = GetUserData();
            DataRow[] foundRows = usersTable.Select($"Login = '{login}' AND Role = '{role}'");

            if (foundRows.Length > 0)
            {
                DataRow userRow = foundRows[0];
                string storedPassword = userRow["Password"].ToString();
                return password == storedPassword;
            }
            return false;
        }

        public void SaveUserData(string login, string password, string role, string email)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO [UserSData] (Login, Password, Role, Email) VALUES (@Login, @Password, @Role, @Email)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Login", login);
                    cmd.Parameters.AddWithValue("@Password", password);
                    cmd.Parameters.AddWithValue("@Role", role);
                    cmd.Parameters.AddWithValue("@Email", email);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while saving data: {ex.Message}");
                    }
                }
            }
        }
    }
}
