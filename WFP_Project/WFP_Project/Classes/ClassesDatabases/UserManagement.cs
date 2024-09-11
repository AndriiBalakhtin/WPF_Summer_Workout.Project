using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace WFP_Project.Classes
{
    internal class UserManagement
    {
        private static readonly string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;" +
            "AttachDbFilename=C:\\Reposotory\\WFP\\WPF_Summer.Project\\WFP_Project\\Databases\\UserManagement\\UserManagement.mdf;" +
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

        public bool VerifyUser(string loginOrEmail, string password, string role)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(1) FROM UserSData WHERE (Login = @loginOrEmail OR Email = @loginOrEmail) AND Password = @password AND Role = @role";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@loginOrEmail", loginOrEmail);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@role", role);

                int count = Convert.ToInt32(cmd.ExecuteScalar());

                return count > 0;
            }
        }

        public bool EmailExists(string email)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM [UserSData] WHERE Email = @Email";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);

                    try
                    {
                        conn.Open();
                        int emailCount = (int)cmd.ExecuteScalar();

                        return emailCount > 0;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while checking email: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return false;
                    }
                }
            }
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

        public void UpdateUserPassword(string login, string newPassword)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "UPDATE [UserSData] SET Password = @Password WHERE Login = @Login";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Password", newPassword);
                    cmd.Parameters.AddWithValue("@Login", login);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"An error occurred while updating the password: {ex.Message}");
                    }
                }
            }
        }

        public (string Login, string Role) GetUserLoginAndRoleByEmail(string email)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT Login, Role FROM [UserSData] WHERE Email = @Email";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);

                    try
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string login = reader["Login"].ToString();
                                string role = reader["Role"].ToString();
                                return (login, role);
                            }
                            else
                            {
                                throw new Exception("Email not found.");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Error retrieving user data: {ex.Message}");
                    }
                }
            }
        }

        public void SaveUserConfirmationData(string login, string password, string role, string email, string confirmationCode)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO [UserSDataConfirmations] (Login, Password, Role, Email) VALUES (@Login, @Password, @Role, @Email)";
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


        public void ApproveUser(string login)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"
            -- Insert data into UserSData from UserSDataConfirmations
            INSERT INTO UserSData (Login, Password, Role, Email)
            SELECT Login, Password, Role, Email
            FROM UserSDataConfirmations
            WHERE Login = @Login;

            -- Delete the user from UserSDataConfirmations
            DELETE FROM UserSDataConfirmations
            WHERE Login = @Login;";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Login", login);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Account approved.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while approving the user: {ex.Message}");
                    }
                }
            }
        }



        public void DenyUser(string login)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM [UserSConfirmations] WHERE Login = @Login";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Login", login);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while deleting data: {ex.Message}");
                    }
                }
            }
        }


        public (bool IsAuthenticated, string userLogin) ReadUser(string loginOrEmail, string password, string role)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT Login FROM UserSData WHERE (Login = @loginOrEmail OR Email = @loginOrEmail) AND Password = @password AND Role = @role";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@loginOrEmail", loginOrEmail);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@role", role);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string userLogin = reader["Login"].ToString();
                        return (true, userLogin);
                    }
                    else
                    {
                        return (false, null);
                    }
                }
            }
        }
    }
}
