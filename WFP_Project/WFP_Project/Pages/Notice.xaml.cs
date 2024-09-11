using System.Data;
using System.Windows;
using WFP_Project.Classes;
using WFP_Project.Enums;

namespace WFP_Project.Pages
{
    public partial class Notice : Window
    {
        private DataRowView selectedRow;
        private UserData currentUserData;

        public string SelectedLogin { get; set; }
        public string SelectedRole { get; set; }
        public string SelectedEmail { get; set; }
        public string SelectedPassword { get; set; }

        public Notice()
        {
            InitializeComponent();
            currentUserData = SettingsManager.LoadUserData();
            LoadData();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SettingsManager.ApplySelectedTheme();
        }

        private void LoadData()
        {
            UserManagement userManagement = new UserManagement();
            DataTable dataTable = userManagement.LoadData();

            if (dataTable != null)
            {
                if (currentUserData != null && currentUserData.Role == "Instructor")
                {
                    DataRow[] rowsToRemove = dataTable.Select("Role = 'Instructor'");
                    foreach (DataRow row in rowsToRemove)
                    {
                        dataTable.Rows.Remove(row);
                    }
                }

                DataGridConfirmations.ItemsSource = dataTable.DefaultView;
            }
            else
            {
                MessageBox.Show("Failed to load user data.");
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
                LoadData();
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
                LoadData();
            }
            else
            {
                MessageBox.Show("Please select a user to deny.");
            }
        }
    }
}
