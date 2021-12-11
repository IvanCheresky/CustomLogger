using Logger.Data.Interfaces;
using Logger.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Logger.Data.Repositories
{
    public class LogRepository : ILogRepository
    {
        private readonly ILogDbContext _logContext;

        public LogRepository(ILogDbContext logContext)
        {
            _logContext = logContext;
        }

        public async Task<Log> Add(Log l)
        {
            var log = await _logContext.Logs.AddAsync(l);
            _logContext.SaveChanges();
            return log.Entity;
        }

        public async Task Delete(int id)
        {
            var l = await _logContext.Logs.FindAsync(id);
            _logContext.Logs.Remove(l);
            _logContext.SaveChanges();
        }

        public async Task<Log> Get(int id)
        {
            return await _logContext.Logs.FindAsync(id);
        }

        public IQueryable<Log> GetAll()
        {
            return _logContext.Logs;
        }

        public void SaveChanges()
        {
            _logContext.SaveChanges();
        }

        public async Task<Log> Update(Log l)
        {
            var log = await _logContext.Logs.FindAsync(l.Id);

            log.LogType = l.LogType;
            log.Message = l.Message;

            _logContext.Logs.Update(log);
            _logContext.SaveChanges();

            return log;
        }
    }
}