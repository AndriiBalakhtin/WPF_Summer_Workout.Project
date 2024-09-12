using System.Diagnostics;
using System.Windows;
using WFP_Project.Enums;
using WFP_Project.Classes;
using WFP_Project.Windows;
using System.Text.Json;

namespace WFP_Project.Pages
{
    public partial class Session : Window
    {
        private List<Training> _trainings;

        public Session()
        {
            InitializeComponent();
            _trainings = SettingsManager.LoadTrainingData();
            RefreshTrainingData();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SettingsManager.ApplySelectedTheme();
        }

        private void CreateTrainingButton_Click(object sender, RoutedEventArgs e)
        {
            var createTrainingWindow = new EditTrainingWindow();
            if (createTrainingWindow.ShowDialog() == true)
            {
                RefreshTrainingData();
                SaveTrainingData();
            }
        }

        private void EditTrainingButton_Click(object sender, RoutedEventArgs e)
        {
            if (TrainingDataGrid.SelectedItem is Training selectedTraining)
            {
                var editTrainingWindow = new EditTrainingWindow(selectedTraining);
                if (editTrainingWindow.ShowDialog() == true)
                {
                    RefreshTrainingData();
                    SaveTrainingData();
                }
            }
            else
            {
                MessageBox.Show("Please select a training to edit.");
            }
        }

        private void DeleteTrainingButton_Click(object sender, RoutedEventArgs e)
        {
            if (TrainingDataGrid.SelectedItem is Training selectedTraining)
            {
                _trainings.Remove(selectedTraining);
                SaveTrainingData();
                RefreshTrainingData();
            }
            else
            {
                MessageBox.Show("Please select a training to delete.");
            }
        }

        private void SaveTrainingData()
        {
            try
            {
                SettingsManager.SaveTrainingData(_trainings);
                MessageBox.Show("Training data saved successfully.");
                Debug.WriteLine("Data saved: " + JsonSerializer.Serialize(_trainings, new JsonSerializerOptions { WriteIndented = true }));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to save training data: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RefreshTrainingData()
        {
            _trainings = SettingsManager.LoadTrainingData();
            TrainingDataGrid.ItemsSource = null;
            TrainingDataGrid.ItemsSource = _trainings;
            TrainingDataGrid.Items.Refresh();
        }

        private void FilterTextBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            
        }

        private void TrainingDataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
           
        }
    }
}
