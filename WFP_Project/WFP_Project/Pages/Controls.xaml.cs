using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Input;
using WFP_Project.Classes;
using WFP_Project.Enums;

namespace WFP_Project.Pages
{
    public partial class ControlWindow : Window
    {
        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;" +
            "AttachDbFilename=C:\\Reposotory\\C#\\Summer_product.api\\DataBase.mdf;" +
            "Integrated Security=True;" +
            "Connect Timeout=30";

        private AppSettings appSettings;
        private ApplyThemes applyThemes;

        public ControlWindow()
        {
            InitializeComponent();

            appSettings = SettingsManager.LoadSettings();
            applyThemes = new ApplyThemes();
            LoadOverlay();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(appSettings.SelectedTheme))
            {
                applyThemes.ApplyTheme(appSettings.SelectedTheme);
            }
            else
            {
                MessageBox.Show("No theme selected in settings.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            LoadOverlay();
        }

        private void InsertButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(forceTextBox.Text) &&
                !string.IsNullOrEmpty(weightTextBox.Text) &&
                !string.IsNullOrEmpty(goalTextBox.Text))
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string queryInsert = "INSERT INTO [UserS] (Force, [1st], Weight, [2nd], Goal, [3rd]) " +
                            "VALUES (@Force, @1st, @Weight, @2nd, @Goal, @3rd)";

                        using (SqlCommand cmd = new SqlCommand(queryInsert, conn))
                        {
                            cmd.Parameters.AddWithValue("@Force", forceTextBox.Text);
                            cmd.Parameters.AddWithValue("@1st", repeate_1stTextBox.Text);
                            cmd.Parameters.AddWithValue("@Weight", weightTextBox.Text);
                            cmd.Parameters.AddWithValue("@2nd", repeate_2ndTextBox.Text);
                            cmd.Parameters.AddWithValue("@Goal", goalTextBox.Text);
                            cmd.Parameters.AddWithValue("@3rd", repeate_3rdTextBox.Text);

                            cmd.ExecuteNonQuery();
                        }

                        LoadOverlay();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while inserting data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Fill in all the rows from the textboxes.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
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
                    MessageBox.Show($"An error occurred while loading data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void NumbersOnlyTextboxes(object sender, KeyEventArgs e)
        {
            e.Handled = !(e.Key >= Key.D0 && e.Key <= Key.D9) && !(e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9);
        }
    }
}
