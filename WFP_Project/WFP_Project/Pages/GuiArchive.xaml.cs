using System.Windows;
using WFP_Project.Classes;

namespace WFP_Project.Pages
{

    public partial class GuiArchive : Window
    {
        public GuiArchive()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SettingsManager.ApplySelectedTheme();
            this.ResizeMode = ResizeMode.NoResize;
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

            this.Close();
        }      
    }
}
