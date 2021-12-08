using Logger.Models;
using LoggerExercise.Data.Interfaces;
using System.Linq;

namespace LoggerExercise.Data.Repositories
{
    public class LogRepository : ILogRepository
    {
        private readonly IExerciseDbContext _exerciseDbContext;

        public LogRepository(IExerciseDbContext exerciseDbContext)
        {
            _exerciseDbContext = exerciseDbContext;
        }

        public Log Add(Log t)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public Log Get(int id)
        {
            throw new System.NotImplementedException();
        }

        public IQueryable<Log> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public Log Update(Log t)
        {
            throw new System.NotImplementedException();
        }
    }
}