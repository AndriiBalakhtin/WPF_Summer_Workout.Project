﻿using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
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
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            AdjustDataGridSize();
        }

        private void AdjustDataGridSize()
        {
            double windowHeight = this.ActualHeight;
            double availableHeight = windowHeight - 10;
            archivedDataGrid.Height = availableHeight;
            double windowWidth = this.ActualWidth;
            archivedDataGrid.Width = windowWidth - 20;
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

        private void archivedDataGrid_BeginningEdit(object sender, DataGridBeginningEditEventArgs e)
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

        private void LoadOverlay()
        {
            try
            {
                DataTable dataTable = DataBase.GetUserData();
                archivedDataGrid.ItemsSource = dataTable.DefaultView;
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
                tablesWrapPanel.Children.Clear();

                var tableNames = DataBase.GetArchivedTableNames();
                if (tableNames.Any())
                {
                    foreach (var tableName in tableNames)
                    {
                        StackPanel stackPanel = new StackPanel
                        {
                            Orientation = Orientation.Horizontal,
                            Margin = new Thickness(5)
                        };

                        Button folderButton = new Button
                        {
                            Content = tableName,
                            Width = 180,
                            Height = 100,
                            Margin = new Thickness(10),
                            Background = new SolidColorBrush(Color.FromRgb(74, 144, 226)),
                            Foreground = Brushes.White,
                            FontSize = 16,
                            FontWeight = FontWeights.Bold,
                            HorizontalContentAlignment = HorizontalAlignment.Center,
                            VerticalContentAlignment = VerticalAlignment.Center,
                        };
                        folderButton.Click += (s, e) => LoadTableData(tableName);

                        Button deleteButton = new Button
                        {
                            Content = "Delete",
                            Width = 80,
                            Height = 100,
                            Margin = new Thickness(10),
                            Background = Brushes.Red,
                            Foreground = Brushes.White,
                            FontSize = 14,
                            FontWeight = FontWeights.Bold,
                            HorizontalContentAlignment = HorizontalAlignment.Center,
                            VerticalContentAlignment = VerticalAlignment.Center,
                        };
                        deleteButton.Click += (s, e) => DeleteArchivedTable(tableName);

                        stackPanel.Children.Add(folderButton);
                        stackPanel.Children.Add(deleteButton);

                        tablesWrapPanel.Children.Add(stackPanel);
                    }
                }
                else
                {
                    MessageBox.Show("No archived tables found.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading table names: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void LoadTableData(string tableName)
        {
            try
            {
                DataTable dataTable = DataBase.GetTableData(tableName);
                archivedDataGrid.ItemsSource = dataTable.DefaultView;
                archivedDataGrid.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading table data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteArchivedTable(string tableName)
        {
            MessageBoxResult result = MessageBox.Show($"Are you sure you want to delete the table '{tableName}'? This action cannot be undone.", "Delete Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    DataBase.DeleteTable(tableName);
                    LoadArchivedTables();
                    MessageBox.Show("Table deleted successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while deleting the table: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void archiveTableNameTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            watermarkTextBlock.Visibility = string.IsNullOrEmpty(archiveTableNameTextBox.Text) ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}
