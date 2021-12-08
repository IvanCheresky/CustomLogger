namespace LoggerExercise.Data.Settings
{
    public class ConnectionStrings : IConnectionStrings
    {
        public string DefaultConnection { get; set; }
        public string ExerciseDbContext { get; set; }
        public string DefaultSchema { get; set; }
    }
}