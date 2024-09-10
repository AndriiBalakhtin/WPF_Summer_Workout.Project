using MaterialDesignThemes.Wpf;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using WFP_Project.Classes;
using WFP_Project.Classes.ClassesDatabases;

namespace WFP_Project.Pages
{
    public partial class AdminPanel : Window
    {
        private AdminSQL adminSQL = new AdminSQL();
        private LinearGradientBrush gradientBrush;

        public AdminPanel()
        {
            InitializeComponent();
            InitializeGradientBrush();
        }

        private void InitializeGradientBrush()
        {
            gradientBrush = new LinearGradientBrush
            {
                StartPoint = new Point(0, 0),
                EndPoint = new Point(1, 1),
                GradientStops = new GradientStopCollection
                {
                    new GradientStop(Colors.LightGray, 0.0),
                    new GradientStop(Colors.Gray, 1.0)
                }
            };
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SettingsManager.ApplySelectedTheme();
            LoadDatabaseList();
        }

        private void LoadDatabaseList()
        {
            ComboBoxDatabases.Items.Clear();
            ComboBoxDatabases.Items.Add(new ComboBoxItem { Content = "DataBase" });
            ComboBoxDatabases.Items.Add(new ComboBoxItem { Content = "UserManagement" });
        }

        private void ButtonExecuteSQL_Click(object sender, RoutedEventArgs e)
        {
            string sqlCommand = TextBoxAdminSQL.Text;
            string selectedDatabase = GetSelectedDatabase();

            if (!string.IsNullOrEmpty(sqlCommand) && selectedDatabase != null)
            {
                DataTable resultTable = adminSQL.ExecuteSQLQuery(sqlCommand, selectedDatabase);
                if (resultTable != null)
                {
                    DataGridAdminSQL.ItemsSource = resultTable.DefaultView; // Bind result to DataGrid
                }
            }
            else
            {
                MessageBox.Show("Введите SQL-команду и выберите базу данных.");
            }
        }

        private string GetSelectedDatabase()
        {
            if (ComboBoxDatabases.SelectedItem != null)
            {
                ComboBoxItem selectedItem = ComboBoxDatabases.SelectedItem as ComboBoxItem;
                return selectedItem?.Content.ToString();
            }
            return null;
        }

        private void TextBoxAdminSQL_GotFocus(object sender, RoutedEventArgs e)
        {
            if (TextBoxAdminSQL.Text == "Enter sql command")
            {
                TextBoxAdminSQL.Text = "";
                TextBoxAdminSQL.Foreground = System.Windows.Media.Brushes.Black;
            }
        }

        private void ButtonOpenTables_Click(object sender, RoutedEventArgs e)
        {
            string selectedDatabase = GetSelectedDatabase();
            if (string.IsNullOrEmpty(selectedDatabase))
            {
                MessageBox.Show("Выберите базу данных для отображения таблиц.");
                return;
            }

            var storyboard = new Storyboard();
            var animation = new DoubleAnimation
            {
                Duration = TimeSpan.FromSeconds(0.3),
                From = TablesPanel.Visibility == Visibility.Collapsed ? 0 : TablesPanel.ActualHeight,
                To = TablesPanel.Visibility == Visibility.Collapsed ? 300 : 0 // Adjust height as needed
            };
            Storyboard.SetTarget(animation, TablesPanel);
            Storyboard.SetTargetProperty(animation, new PropertyPath("Height"));
            storyboard.Children.Add(animation);

            if (TablesPanel.Visibility == Visibility.Collapsed)
            {
                TablesPanel.Visibility = Visibility.Visible;
                storyboard.Begin();
                LoadArchivedTables(selectedDatabase);
            }
            else
            {
                animation.Completed += (s, a) =>
                {
                    TablesPanel.Visibility = Visibility.Collapsed;
                };
                storyboard.Begin();
            }
        }

        private void LoadArchivedTables(string database)
        {
            try
            {
                tablesWrapPanel.Children.Clear();
                DataTable tableNamesTable = adminSQL.GetAllTableNames(database);
                if (tableNamesTable != null && tableNamesTable.Rows.Count > 0)
                {
                    foreach (DataRow row in tableNamesTable.Rows)
                    {
                        string tableName = row["TABLE_NAME"].ToString();

                        StackPanel stackPanel = new StackPanel
                        {
                            Orientation = Orientation.Horizontal,
                            Margin = new Thickness(5)
                        };

                        Border roundedBorder = new Border
                        {
                            Width = 174,
                            Height = 40,
                            CornerRadius = new CornerRadius(10),
                            Background = gradientBrush,
                            Padding = new Thickness(10),
                            Margin = new Thickness(5),
                            Cursor = Cursors.Hand
                        };

                        TextBlock textBlock = new TextBlock
                        {
                            Text = tableName,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Center,
                            FontSize = 16,
                            FontWeight = FontWeights.Bold,
                            Foreground = Brushes.Black
                        };

                        roundedBorder.Child = textBlock;

                        roundedBorder.MouseEnter += (s, e) =>
                        {
                            roundedBorder.Background = new LinearGradientBrush
                            {
                                StartPoint = new Point(0, 0),
                                EndPoint = new Point(1, 1),
                                GradientStops = new GradientStopCollection
                        {
                            new GradientStop(Colors.LightBlue, 0),
                            new GradientStop(Colors.White, 1)
                        }
                            };
                        };

                        roundedBorder.MouseLeave += (s, e) =>
                        {
                            roundedBorder.Background = gradientBrush;
                        };

                        roundedBorder.MouseLeftButtonUp += (s, e) =>
                        {
                            LoadTableData(tableName);
                        };

                        Grid grid = new Grid
                        {
                            Width = 50,
                            Height = 50
                        };

                        Ellipse ellipse = new Ellipse
                        {
                            Width = 40,
                            Height = 40,
                            Fill = Brushes.LightGray,
                            Opacity = 0,
                            HorizontalAlignment = HorizontalAlignment.Center,
                            VerticalAlignment = VerticalAlignment.Center
                        };

                        Button deleteButton = new Button
                        {
                            Width = 30,
                            Height = 30,
                            Background = Brushes.Transparent,
                            BorderBrush = Brushes.Transparent,
                            Content = new PackIcon
                            {
                                Kind = PackIconKind.Delete,
                                Width = 20,
                                Height = 20,
                                Foreground = Brushes.Red
                            }
                        };

                        deleteButton.Click += (s, e) => DeleteArchivedTable(tableName);

                        deleteButton.MouseEnter += (s, e) =>
                        {
                            DoubleAnimation fadeIn = new DoubleAnimation
                            {
                                From = 0,
                                To = 0.5,
                                Duration = TimeSpan.FromSeconds(0.3)
                            };
                            ellipse.BeginAnimation(UIElement.OpacityProperty, fadeIn);
                        };

                        deleteButton.MouseLeave += (s, e) =>
                        {
                            DoubleAnimation fadeOut = new DoubleAnimation
                            {
                                From = 0.5,
                                To = 0,
                                Duration = TimeSpan.FromSeconds(0.3)
                            };
                            ellipse.BeginAnimation(UIElement.OpacityProperty, fadeOut);
                        };

                        grid.Children.Add(ellipse);
                        grid.Children.Add(deleteButton);

                        stackPanel.Children.Add(roundedBorder);
                        stackPanel.Children.Add(grid);

                        tablesWrapPanel.Children.Add(stackPanel);
                    }
                }
                else
                {
                    MessageBox.Show("No tables found in the selected database.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
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
                DataTable dataTable = adminSQL.ExecuteSQLQuery($"SELECT * FROM [{tableName}]", GetSelectedDatabase());
                DataGridAdminSQL.ItemsSource = dataTable?.DefaultView;
                DataGridAdminSQL.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading data for table '{tableName}': {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteArchivedTable(string tableName)
        {
            MessageBoxResult result = MessageBox.Show($"Are you sure you want to delete the table '{tableName}'? This action cannot be undone.", "Delete Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);

            if (result == MessageBoxResult.Yes)
            {
                try
                {
                    adminSQL.ExecuteSQLQuery($"DROP TABLE [{tableName}]", GetSelectedDatabase());
                    LoadArchivedTables(GetSelectedDatabase());
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while deleting the table: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
