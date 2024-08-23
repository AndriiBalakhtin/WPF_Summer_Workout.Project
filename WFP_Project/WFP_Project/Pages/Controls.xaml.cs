using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WFP_Project.Classes;

namespace WFP_Project.Pages
{
    public partial class ControlWindow : Window
    {
        public ControlWindow()
        {
            InitializeComponent();
            LoadOverlay();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SettingsManager.ApplySelectedTheme();
        }

        private void InsertButton_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(forceTextBox.Text) &&
                !string.IsNullOrEmpty(weightTextBox.Text) &&
                !string.IsNullOrEmpty(goalTextBox.Text))
            {
                DataBase.InsertUserData(
                    forceTextBox.Text,
                    repeate_1stTextBox.Text,
                    weightTextBox.Text,
                    repeate_2ndTextBox.Text,
                    goalTextBox.Text,
                    repeate_3rdTextBox.Text
                );

                LoadOverlay();
            }
            else
            {
                MessageBox.Show("Fill in all the rows from the textboxes.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void ArchiveButton_Click(object sender, RoutedEventArgs e)
        {
            string tableName = archiveTableNameTextBox.Text.Trim();

            if (!string.IsNullOrEmpty(tableName))
            {
                try
                {
                    DataBase.ArchiveUserData(tableName);
                    MessageBox.Show("Table archived successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    LoadArchivedTables();
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
            string selectedTable = archivedTablesComboBox.SelectedItem as string;

            if (!string.IsNullOrEmpty(selectedTable))
            {
                try
                {
                    DataTable dataTable = DataBase.GetTableData(selectedTable);
                    databaseDataGrid.ItemsSource = dataTable.DefaultView;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while loading data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a table from the list.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void LoadOverlay()
        {
            try
            {
                DataTable dataTable = DataBase.GetUserData();
                databaseDataGrid.ItemsSource = dataTable.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void LoadArchivedTables()
        {
            try
            {
                var tableNames = DataBase.GetArchivedTableNames();
                archivedTablesComboBox.ItemsSource = tableNames;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading tables: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void databaseDataGrid_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
        {
            if (e.Row.Item is DataRowView rowView)
            {
                DataRow selectedRow = rowView.Row;
                string rowId = selectedRow["Id"].ToString();

                var editorWindow = new Editor(
                    selectedRow["Force"].ToString(),
                    selectedRow["1st"].ToString(),
                    selectedRow["Weight"].ToString(),
                    selectedRow["2nd"].ToString(),
                    selectedRow["Goal"].ToString(),
                    selectedRow["3rd"].ToString(),
                    rowId
                );

                bool? result = editorWindow.ShowDialog();

                if (result == true)
                {
                    LoadOverlay();
                }

                e.Cancel = true;
            }
        }

        private void NumbersOnlyTextboxes(object sender, KeyEventArgs e)
        {
            e.Handled = !(e.Key >= Key.D0 && e.Key <= Key.D9) && !(e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9);
        }
    }
}
