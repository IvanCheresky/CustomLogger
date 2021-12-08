using System.Linq;
using System.Threading.Tasks;
using Logger.Data.Interfaces;
using Logger.Models;
using Microsoft.EntityFrameworkCore;

namespace Logger.Data.Repositories
{
    public class LogRepository : ILogRepository
    {
        private readonly DbContext _dbContext;

        public LogRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Log> Add(Log l)
        {
            var log = await _dbContext.Set<Log>().AddAsync(l);
            await _dbContext.SaveChangesAsync();
            return log.Entity;
        }

        public async Task Delete(int id)
        {
            var l = await _dbContext.Set<Log>().FindAsync(id);
            _dbContext.Set<Log>().Remove(l);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Log> Get(int id)
        {
            return await _dbContext.Set<Log>().FindAsync(id);
        }

        public IQueryable<Log> GetAll()
        {
            return _dbContext.Set<Log>();
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }

        public async Task<Log> Update(Log l)
        {
            var log = await _dbContext.Set<Log>().FindAsync(l.Id);

            log.LogType = l.LogType;
            log.Message = l.Message;

            _dbContext.Set<Log>().Update(log);
            await _dbContext.SaveChangesAsync();

            return log;
        }
    }
}