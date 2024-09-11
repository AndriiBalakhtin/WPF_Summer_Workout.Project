using System.Data;
using System.Windows;
using System.Data.SqlClient;
using WFP_Project.Classes;

namespace WFP_Project.Pages
{
    public partial class Notice : Window
    {
        private static readonly string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;" +
            "AttachDbFilename=C:\\Reposotory\\WFP\\WPF_Summer.Project\\WFP_Project\\Databases\\UserManagement\\UserManagement.mdf;" +
            "Integrated Security=True;Connect Timeout=30";

        private DataRowView selectedRow;

        public string SelectedLogin { get; set; }
        public string SelectedRole { get; set; }
        public string SelectedEmail { get; set; }
        public string SelectedPassword { get; set; }

        public Notice()
        {
            InitializeComponent();
            LoadData();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM UserSDataConfirmations";

                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
                DataTable dataTable = new DataTable();

                try
                {
                    conn.Open();
                    dataAdapter.Fill(dataTable);
                    DataGridConfirmations.ItemsSource = dataTable.DefaultView;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while loading data: {ex.Message}");
                }
            }
        }

        private void DataGridConfirmations_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            selectedRow = DataGridConfirmations.SelectedItem as DataRowView;
            if (selectedRow != null)
            {
                SelectedLogin = selectedRow["Login"].ToString();
                SelectedRole = selectedRow["Role"].ToString();
                SelectedEmail = selectedRow["Email"].ToString();
                SelectedPassword = selectedRow["Password"].ToString();
            }
        }

        private void ButtonApprove_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(SelectedLogin))
            {
                UserManagement userManagement = new UserManagement();
                try
                {
                    userManagement.ApproveUser(SelectedLogin);
                    MessageBox.Show("Account approved.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while approving the user: {ex.Message}");
                }
                LoadData(); // Refresh data after approval
            }
            else
            {
                MessageBox.Show("Please select a user to approve.");
            }
        }

        private void ButtonDeny_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(SelectedLogin))
            {
                UserManagement userManagement = new UserManagement();
                try
                {
                    userManagement.DenyUser(SelectedLogin);
                    MessageBox.Show("Account denied.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while denying the user: {ex.Message}");
                }
                LoadData(); // Refresh data after denial
            }
            else
            {
                MessageBox.Show("Please select a user to deny.");
            }
        }
    }
}
