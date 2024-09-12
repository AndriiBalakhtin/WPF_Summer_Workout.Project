using System.Data.SqlClient;
using WFP_Project.Enums;

namespace WFP_Project.Classes.ClassesDatabases
{
    public class TrainingSessions
    {
        private readonly string _connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Reposotory\\WFP\\WPF_Summer.Project\\WFP_Project\\Databases\\TrainingSessions\\TrainingSessions.mdf;Integrated Security=True;Connect Timeout=30";

        public void AddTraining(Training training)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("INSERT INTO Trainings (TrainingName, AthleteName, CoachName) OUTPUT INSERTED.TrainingId VALUES (@TrainingName, @AthleteName, @CoachName)", connection))
                {
                    command.Parameters.AddWithValue("@TrainingName", training.TrainingName);
                    command.Parameters.AddWithValue("@AthleteName", training.AthleteName);
                    command.Parameters.AddWithValue("@CoachName", training.CoachName);

                    training.TrainingId = (int)command.ExecuteScalar();
                }

                foreach (var exercise in training.Exercises)
                {
                    using (var command = new SqlCommand("INSERT INTO Exercises (TrainingId, ExerciseName, Reps, Sets) VALUES (@TrainingId, @ExerciseName, @Reps, @Sets)", connection))
                    {
                        command.Parameters.AddWithValue("@TrainingId", training.TrainingId);
                        command.Parameters.AddWithValue("@ExerciseName", exercise.ExerciseName);
                        command.Parameters.AddWithValue("@Reps", exercise.Reps);
                        command.Parameters.AddWithValue("@Sets", exercise.Sets);

                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public void UpdateTraining(Training training)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("UPDATE Trainings SET TrainingName = @TrainingName, AthleteName = @AthleteName, CoachName = @CoachName WHERE TrainingId = @TrainingId", connection))
                {
                    command.Parameters.AddWithValue("@TrainingId", training.TrainingId);
                    command.Parameters.AddWithValue("@TrainingName", training.TrainingName);
                    command.Parameters.AddWithValue("@AthleteName", training.AthleteName);
                    command.Parameters.AddWithValue("@CoachName", training.CoachName);

                    command.ExecuteNonQuery();
                }

                using (var command = new SqlCommand("DELETE FROM Exercises WHERE TrainingId = @TrainingId", connection))
                {
                    command.Parameters.AddWithValue("@TrainingId", training.TrainingId);
                    command.ExecuteNonQuery();
                }

                foreach (var exercise in training.Exercises)
                {
                    using (var command = new SqlCommand("INSERT INTO Exercises (TrainingId, ExerciseName, Reps, Sets) VALUES (@TrainingId, @ExerciseName, @Reps, @Sets)", connection))
                    {
                        command.Parameters.AddWithValue("@TrainingId", training.TrainingId);
                        command.Parameters.AddWithValue("@ExerciseName", exercise.ExerciseName);
                        command.Parameters.AddWithValue("@Reps", exercise.Reps);
                        command.Parameters.AddWithValue("@Sets", exercise.Sets);

                        command.ExecuteNonQuery();
                    }
                }
            }
        }

        public void DeleteTraining(int trainingId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("DELETE FROM Exercises WHERE TrainingId = @TrainingId", connection))
                {
                    command.Parameters.AddWithValue("@TrainingId", trainingId);
                    command.ExecuteNonQuery();
                }

                using (var command = new SqlCommand("DELETE FROM Trainings WHERE TrainingId = @TrainingId", connection))
                {
                    command.Parameters.AddWithValue("@TrainingId", trainingId);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Training> GetAllTrainings()
        {
            var trainings = new List<Training>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT TrainingId, TrainingName, AthleteName, CoachName FROM Trainings", connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var training = new Training
                        {
                            TrainingId = reader.GetInt32(0),
                            TrainingName = reader.GetString(1),
                            AthleteName = reader.GetString(2),
                            CoachName = reader.GetString(3),
                            Exercises = GetExercisesForTraining(reader.GetInt32(0))
                        };
                        trainings.Add(training);
                    }
                }
            }

            return trainings;
        }

        private List<Exercise> GetExercisesForTraining(int trainingId)
        {
            var exercises = new List<Exercise>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT ExerciseName, Reps, Sets FROM Exercises WHERE TrainingId = @TrainingId", connection))
                {
                    command.Parameters.AddWithValue("@TrainingId", trainingId);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            exercises.Add(new Exercise
                            {
                                ExerciseName = reader.GetString(0),
                                Reps = reader.GetInt32(1),
                                Sets = reader.GetInt32(2)
                            });
                        }
                    }
                }
            }

            return exercises;
        }
    }
}
