namespace LoggerExercise.Settings.Interfaces
{
    public interface IConnectionStrings
    {
        public string DefaultConnection { get; set; }
        public string ConnectionString { get; set; }
        public string DefaultSchema { get; set; }
    }
}