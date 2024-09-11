using MaterialDesignThemes.Wpf;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using WFP_Project.Classes;
using WFP_Project.Enums;

namespace WFP_Project.Pages
{
    public partial class ArchiveWindow : Window
    {
        private UserData currentUserData;

        public ArchiveWindow()
        {
            InitializeComponent();
            currentUserData = SettingsManager.LoadUserData();
            LoadArchivedTables();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SettingsManager.ApplySelectedTheme();
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
                MessageBox.Show($"An error occurred while loading table data: {ex.Message}", 
                                 "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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

                        LinearGradientBrush gradientBrush = new LinearGradientBrush
                        {
                            StartPoint = new Point(0, 0),
                            EndPoint = new Point(1, 1),
                            GradientStops = new GradientStopCollection
                    {
                        new GradientStop(Colors.Azure, 0),
                        new GradientStop(Colors.White, 1)
                    }
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
                    MessageBox.Show("No archived tables found.", 
                                    "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading table names: {ex.Message}", 
                                 "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteArchivedTable(string tableName)
        {
            if (currentUserData != null && (currentUserData.Role == "Administrator" || currentUserData.Role == "Instructor"))
            {
                MessageBoxResult result = MessageBox.Show($"Are you sure you want to delete the table '{tableName}'? This action cannot be undone.",
                                                           "Delete Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (result == MessageBoxResult.Yes)
                {
                    try
                    {
                        DataBase.DeleteTable(tableName);
                        LoadArchivedTables();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"An error occurred while deleting the table: {ex.Message}",
                                         "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("You do not have permission to delete tables.", 
                                "Access Denied", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

    }
}