namespace LoggerExercise.Data.Settings
{
    public class ConnectionStrings : IConnectionStrings
    {
        public string DefaultConnection { get; set; }
        public string ConnectionString { get; set; }
        public string DefaultSchema { get; set; }
    }
}