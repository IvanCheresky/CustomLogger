namespace LoggerExercise.Data.Settings
{
    public interface IConnectionStrings
    {
        public string DefaultConnection { get; set; }
        public string ExerciseDbContext { get; set; }
        public string DefaultSchema { get; set; }
    }
}