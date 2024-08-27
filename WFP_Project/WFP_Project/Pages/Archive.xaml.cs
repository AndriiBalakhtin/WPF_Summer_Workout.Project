using MaterialDesignThemes.Wpf;
using System.Data;
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

        private void LoadArchivedTables()
        {
            try
            {
                tablesWrapPanel.Children.Clear();

                var tableNames = DataBase.GetArchivedTableNames();
                if (tableNames.Count > 0)
                {
                    foreach (var tableName in tableNames)
                    {
                        StackPanel stackPanel = new StackPanel
                        {
                            Orientation = Orientation.Horizontal,
                            Margin = new Thickness(5)
                        };

                        LinearGradientBrush folderButtonBrush = new LinearGradientBrush
                        {
                            StartPoint = new Point(0, 0),
                            EndPoint = new Point(1, 1),
                            GradientStops = new GradientStopCollection
                    {
                        new GradientStop(Colors.Azure, 0),
                        new GradientStop(Colors.White, 1)
                    }
                        };

                        Button folderButton = new Button
                        {
                            Width = 120,
                            Height = 40,
                            Margin = new Thickness(10),
                            FontSize = 16,
                            FontWeight = FontWeights.ExtraBold,
                            HorizontalContentAlignment = HorizontalAlignment.Center,
                            VerticalContentAlignment = VerticalAlignment.Center,
                            Background = folderButtonBrush,
                            Content = new StackPanel
                            {
                                Orientation = Orientation.Horizontal,
                                Children =
                        {
                            new PackIcon
                            {
                                Kind = PackIconKind.Folder,
                                Width = 20,
                                Height = 20,
                                Margin = new Thickness(0, 0, 5, 0)
                            },
                            new TextBlock
                            {
                                Text = tableName,
                                VerticalAlignment = VerticalAlignment.Center
                            }
                        }
                            }
                        };

                        folderButton.Style = (Style)this.FindResource("RoundedButtonStyle");
                        folderButton.Click += (s, e) => LoadTableData(tableName);

                        LinearGradientBrush deleteButtonBrush = new LinearGradientBrush
                        {
                            StartPoint = new Point(0, 0),
                            EndPoint = new Point(1, 1),
                            GradientStops = new GradientStopCollection
                    {
                        new GradientStop(Colors.Aquamarine, 0),
                        new GradientStop(Colors.Azure, 1)
                    }
                        };

                        Button deleteButton = new Button
                        {
                            Width = 100,
                            Height = 40,
                            Margin = new Thickness(10),
                            FontSize = 14,
                            FontWeight = FontWeights.ExtraBold,
                            HorizontalContentAlignment = HorizontalAlignment.Center,
                            VerticalContentAlignment = VerticalAlignment.Center,
                            Background = deleteButtonBrush,
                            Content = new StackPanel
                            {
                                Orientation = Orientation.Horizontal,
                                Children =
                        {
                            new PackIcon
                            {
                                Kind = PackIconKind.Delete,
                                Width = 20,
                                Height = 20,
                                Margin = new Thickness(0, 0, 5, 0)
                            },
                            new TextBlock
                            {
                                Text = "Delete",
                                VerticalAlignment = VerticalAlignment.Center
                            }
                        }
                            }
                        };

                        deleteButton.Style = (Style)this.FindResource("RoundedButtonStyle");
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
    }
}