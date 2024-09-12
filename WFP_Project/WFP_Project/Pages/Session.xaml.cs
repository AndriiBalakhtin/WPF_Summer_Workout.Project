using System.Windows;
using WFP_Project.Classes;
using WFP_Project.Classes.ClassesDatabases;
using WFP_Project.Enums;
using WFP_Project.Windows;

namespace WFP_Project.Pages
{
    public partial class Session : Window
    {
        private UserData currentUserData;
        private readonly TrainingSessions _trainingSessions = new TrainingSessions();
        private List<Training> _trainings;

        public Session()
        {
            InitializeComponent();
            currentUserData = SettingsManager.LoadUserData();
            LoadTrainings();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SettingsManager.ApplySelectedTheme();
        }

        private void LoadTrainings()
        {
            _trainings = _trainingSessions.GetAllTrainings();
            TrainingDataGrid.ItemsSource = _trainings;
            TrainingDataGrid.Items.Refresh();
        }

        private void CreateTrainingButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentUserData != null && (currentUserData.Role == "Administrator" || currentUserData.Role == "Instructor"))
            {
                var createTrainingWindow = new EditTrainingWindow();
                if (createTrainingWindow.ShowDialog() == true)
                {
                    LoadTrainings();
                }
                else
                {
                    MessageBox.Show("You can't add an exercise, if you haven't done the workout");
                }
            }
            else
            {
                MessageBox.Show("You do not have permission to create this is",
                                "Access Denied", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void EditTrainingButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentUserData != null && (currentUserData.Role == "Administrator" || currentUserData.Role == "Instructor"))
            {
                if (TrainingDataGrid.SelectedItem is Training selectedTraining)
                {
                    var editTrainingWindow = new EditTrainingWindow(selectedTraining);
                    if (editTrainingWindow.ShowDialog() == true)
                    {
                        LoadTrainings();
                    }
                }
                else
                {
                    MessageBox.Show("Please select a training to edit.");
                }
            }
            else
            {
                MessageBox.Show("You do not have permission to edit this is",
                                "Access Denied", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DeleteTrainingButton_Click(object sender, RoutedEventArgs e)
        {
            if (currentUserData != null && (currentUserData.Role == "Administrator" || currentUserData.Role == "Instructor"))
            {
                if (TrainingDataGrid.SelectedItem is Training selectedTraining)
                {
                    _trainingSessions.DeleteTraining(selectedTraining.TrainingId);
                    LoadTrainings();
                    ExercisesDataGrid.ItemsSource = null;
                }
                else
                {
                    MessageBox.Show("Please select a training to delete.");
                }
            }
            else
            {
                MessageBox.Show("You do not have permission to delete this is",
                                "Access Denied", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void TrainingDataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (TrainingDataGrid.SelectedItem is Training selectedTraining)
            {
                ExercisesDataGrid.ItemsSource = selectedTraining.Exercises;
                ExercisesDataGrid.Items.Refresh();
            }
            else
            {
                ExercisesDataGrid.ItemsSource = null;
            }
        }
    }
}
