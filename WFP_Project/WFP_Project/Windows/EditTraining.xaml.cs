using System.Windows;
using WFP_Project.Classes;
using WFP_Project.Classes.ClassesDatabases;
using WFP_Project.Enums;

namespace WFP_Project.Windows
{
    public partial class EditTraining : Window
    {
        private Training _training;
        private readonly TrainingSessions _trainingSessions = new TrainingSessions();

        public EditTraining()
        {
            InitializeComponent();
            LoadTrainingData();
            this.ResizeMode = ResizeMode.NoResize;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SettingsManager.ApplySelectedTheme();
        }

        public EditTraining(Training training) : this()
        {
            _training = training;
            LoadTrainingData();
        }

        private void LoadTrainingData()
        {
            if (_training != null)
            {
                TrainingNameTextBox.Text = _training.TrainingName;
                AthleteNameTextBox.Text = _training.AthleteName;
                CoachNameTextBox.Text = _training.CoachName;

                if (_training.Exercises == null)
                    _training.Exercises = new List<Exercise>();

                ExercisesListView.ItemsSource = _training.Exercises;
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (_training == null)
            {
                _training = new Training
                {
                    TrainingName = TrainingNameTextBox.Text,
                    AthleteName = AthleteNameTextBox.Text,
                    CoachName = CoachNameTextBox.Text,
                    Exercises = new List<Exercise>()
                };

                _trainingSessions.AddTraining(_training);
            }
            else
            {
                _training.TrainingName = TrainingNameTextBox.Text;
                _training.AthleteName = AthleteNameTextBox.Text;
                _training.CoachName = CoachNameTextBox.Text;

                _trainingSessions.UpdateTraining(_training);
            }
            DialogResult = true;
            Close();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void AddExerciseButton_Click(object sender, RoutedEventArgs e)
        {
            var exerciseName = ExerciseNameTextBox.Text;
            if (int.TryParse(RepsTextBox.Text, out int reps) && int.TryParse(SetsTextBox.Text, out int sets))
            {
                var newExercise = new Exercise
                {
                    ExerciseName = exerciseName,
                    Reps = reps,
                    Sets = sets
                };

                if (_training == null)
                {
                    _training = new Training
                    {
                        TrainingName = TrainingNameTextBox.Text,
                        AthleteName = AthleteNameTextBox.Text,
                        CoachName = CoachNameTextBox.Text,
                        Exercises = new List<Exercise>()
                    };
                }

                if (_training.Exercises == null)
                    _training.Exercises = new List<Exercise>();

                _training.Exercises.Add(newExercise);
                ExercisesListView.ItemsSource = null;
                ExercisesListView.ItemsSource = _training.Exercises;

                ExerciseNameTextBox.Clear();
                RepsTextBox.Clear();
                SetsTextBox.Clear();
            }
            else
            {
                MessageBox.Show("Please enter valid numbers for Reps and Sets.");
            }
        }
    }
}