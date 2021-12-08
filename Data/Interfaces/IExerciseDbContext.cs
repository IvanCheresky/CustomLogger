using Logger.Models;
using Microsoft.EntityFrameworkCore;

namespace LoggerExercise.Data.Interfaces
{
    public interface IExerciseDbContext
    {
        DbSet<Log> Logs { get; set; }
    }
}