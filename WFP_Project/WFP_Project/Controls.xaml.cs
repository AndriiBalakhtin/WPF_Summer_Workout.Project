using System;
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

        private AppSettings appSettings;

        public ControlWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            appSettings = SettingsManager.LoadSettings();
            ApplyTheme(appSettings.SelectedTheme);

            LoadOverlay();
        }

        private void ApplyTheme(string theme)
        {
            ResourceDictionary newTheme = new ResourceDictionary();

            try
            {
                switch (theme)
                {
                    case "White":
                        newTheme.Source = new Uri("pack://application:,,,/Themes/WhiteTheme.xaml", UriKind.Absolute);
                        break;
                    case "Dark":
                        newTheme.Source = new Uri("pack://application:,,,/Themes/DarkTheme.xaml", UriKind.Absolute);
                        break;
                    default:
                        MessageBox.Show("Unknown theme selected.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                }

                Application.Current.Resources.MergedDictionaries.Clear();
                Application.Current.Resources.MergedDictionaries.Add(newTheme);

                foreach (Window window in Application.Current.Windows)
                {
                    window.Background = (System.Windows.Media.Brush)newTheme["WindowBackgroundBrush"];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading theme: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
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
