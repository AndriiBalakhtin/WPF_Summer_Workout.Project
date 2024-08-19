using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace WFP_Project.Pages
{
    public partial class Editor : Window
    {
        private string _connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;" +
            "AttachDbFilename=C:\\Reposotory\\C#\\Summer_product.api\\DataBase.mdf;" +
            "Integrated Security=True;" +
            "Connect Timeout=30";

        private DataRow _dataRow;
        private string _rowId;

        public Editor(string force, string repeate1st, string weight, string repeate2nd, string goal, string repeate3rd, DataRow dataRow, string rowId)
        {
            InitializeComponent();

            forceTextBox.Text = force;
            repeate_1stTextBox.Text = repeate1st;
            weightTextBox.Text = weight;
            repeate_2ndTextBox.Text = repeate2nd;
            goalTextBox.Text = goal;
            repeate_3rdTextBox.Text = repeate3rd;
            _dataRow = dataRow;
            _rowId = rowId;

            selectedRowLabel.Content = $"Selected Row: {_rowId}";
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(forceTextBox.Text) &&
                !string.IsNullOrEmpty(weightTextBox.Text) &&
                !string.IsNullOrEmpty(goalTextBox.Text))
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(_connectionString))
                    {
                        conn.Open();
                        string queryUpdate = "UPDATE [UserS] SET Force = @Force, [1st] = @1st, Weight = @Weight, [2nd] = @2nd, Goal = @Goal, [3rd] = @3rd WHERE Id = @Id";

                        using (SqlCommand cmd = new SqlCommand(queryUpdate, conn))
                        {
                            cmd.Parameters.AddWithValue("@Force", forceTextBox.Text);
                            cmd.Parameters.AddWithValue("@1st", repeate_1stTextBox.Text);
                            cmd.Parameters.AddWithValue("@Weight", weightTextBox.Text);
                            cmd.Parameters.AddWithValue("@2nd", repeate_2ndTextBox.Text);
                            cmd.Parameters.AddWithValue("@Goal", goalTextBox.Text);
                            cmd.Parameters.AddWithValue("@3rd", repeate_3rdTextBox.Text);
                            cmd.Parameters.AddWithValue("@Id", _rowId);

                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Record updated successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while updating data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Fill in all the rows from the textboxes.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
