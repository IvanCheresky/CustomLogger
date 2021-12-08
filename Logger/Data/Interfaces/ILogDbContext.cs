/* Unmerged change from project 'Logger'
Before:
using System.Threading.Tasks;
using LoggerExercise.Logger.Models;
After:
using LoggerExercise.Logger.Models;
using Microsoft.Logger.Models;
*/

using LoggerExercise.Logger.Models;
using Microsoft.EntityFrameworkCore;

namespace LoggerExercise.Logger.Data.Interfaces
{
    public interface ILogDbContext
    {
        DbSet<Log> Logs { get; set; }
        int SaveChanges();
    }
}