using Logger.Models;
using LoggerExercise.Data.Interfaces;
using LoggerExercise.Data.Settings;
using Microsoft.EntityFrameworkCore;

namespace LoggerExercise.Data
{
    public class ExerciseDbContext : DbContext, IExerciseDbContext
    {
        private readonly IConnectionStrings _connectionStrings;

        public DbSet<Log> Logs { get; set; }

        public ExerciseDbContext(DbContextOptions<ExerciseDbContext> options, IConnectionStrings connectionStrings)
            : base(options)
        {
            _connectionStrings = connectionStrings;
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasDefaultSchema(_connectionStrings.DefaultSchema);
        }
    }
}