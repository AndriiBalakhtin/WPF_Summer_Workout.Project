using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Input;


namespace WFP_Project
{
    public partial class ControlWindow : Window
    {
        string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;" +
            "AttachDbFilename=C:\\Reposotory\\C#\\Summer_product.api\\DataBase.mdf;" +
            "Integrated Security=True;" +
            "Connect Timeout=30";

        public ControlWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadOverlay();
        }

        private void InsertButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(forceTextBox.Text) && !string.IsNullOrEmpty(weightTextBox.Text) && !string.IsNullOrEmpty(goalTextBox.Text))
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string queryInsert = "INSERT INTO [UserS] (Force, Repeate_1st, Weight, Repeate_2nd, Goal, Repeate_3rd)" +
                            "VALUES" +
                            "(@Force, @Repeate_1st, @Weight, @Repeate_2nd, @Goal, @Repeate_3rd)";

                        using (SqlCommand cmd = new SqlCommand(queryInsert, conn))
                        {
                            cmd.Parameters.AddWithValue("@Force", forceTextBox.Text);
                            cmd.Parameters.AddWithValue("@Repeate_1st", repeate_1stTextBox.Text);
                            cmd.Parameters.AddWithValue("@Weight", weightTextBox.Text);
                            cmd.Parameters.AddWithValue("@Repeate_2nd", repeate_2ndTextBox.Text);
                            cmd.Parameters.AddWithValue("@Goal", goalTextBox.Text);
                            cmd.Parameters.AddWithValue("@Repeate_3rd", repeate_3rdTextBox.Text);

                            cmd.ExecuteNonQuery();
                        }

                        LoadOverlay();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Fill in all the rows from the textboxes.");
            }
        }

        private void LoadOverlay()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string queryOverWrite = "SELECT * FROM [UserS]";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(queryOverWrite, conn);
                DataTable dataTable = new DataTable();

                try
                {
                    conn.Open();
                    dataAdapter.Fill(dataTable);
                    databaseDataGrid.ItemsSource = dataTable.DefaultView;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void NumbersOnlyTextboxes(object sender, KeyEventArgs e)
        {
            e.Handled = !(e.Key >= Key.D0 && e.Key <= Key.D9) && !(e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9);
        }
    }
}
