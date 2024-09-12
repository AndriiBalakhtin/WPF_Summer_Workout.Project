namespace WFP_Project.Enums
{
    public class AppSettingsEnums
    {
        public string SelectedTheme { get; set; } = "Default";
    }

    public class UserData
    {
        public string UserLogin { get; set; }
        public string Role { get; set; }
    }

    public class Training
    {
        public string TrainingName { get; set; }
        public string AthleteName { get; set; }
        public string CoachName { get; set; }
        public List<Exercise> Exercises { get; set; } = new List<Exercise>();
    }

    public class Exercise
    {
        public string ExerciseName { get; set; }
        public int Reps { get; set; }
        public int Sets { get; set; }
    }
}
