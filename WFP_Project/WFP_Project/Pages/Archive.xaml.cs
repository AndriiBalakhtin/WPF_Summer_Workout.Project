
using System.Data;
using System.Windows;
using WFP_Project.Classes;

namespace WFP_Project.Pages
{
    public partial class ArchiveWindow : Window
    {
        public ArchiveWindow()
        {
            InitializeComponent();
            LoadArchivedTables();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SettingsManager.ApplySelectedTheme();
            LoadArchivedTables(); 
        }

        private void ArchiveButton_Click(object sender, RoutedEventArgs e)
        {
            string tableName = archiveTableNameTextBox.Text.Trim();

            if (!string.IsNullOrEmpty(tableName))
            {
                try
                {
                    DataBase.ArchiveUserData(tableName);
                    LoadArchivedTables();
                    MessageBox.Show("Data archived successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while archiving data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter a table name.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void LoadTableButton_Click(object sender, RoutedEventArgs e)
        {
            string tableName = archivedTablesComboBox.Text.Trim();

            if (!string.IsNullOrEmpty(tableName))
            {
                try
                {
                    DataTable dataTable = DataBase.GetTableData(tableName);
                    archivedDataGrid.ItemsSource = dataTable.DefaultView;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while loading table data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a table.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void LoadArchivedTables()
        {
            try
            {
                var tableNames = DataBase.GetArchivedTableNames();
                if (tableNames.Any())
                {
                    archivedTablesComboBox.ItemsSource = tableNames;
                    archivedTablesComboBox.SelectedIndex = 0; // Optionally select the first item if available
                }
                else
                {
                    archivedTablesComboBox.ItemsSource = null; // Clear items if none available
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading table names: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
