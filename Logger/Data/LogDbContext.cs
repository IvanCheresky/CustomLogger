using Logger.Data.Interfaces;
using Logger.Models;
using Microsoft.EntityFrameworkCore;

namespace Logger.Data
{
    public class LogDbContext : DbContext, ILogDbContext
    {
        public DbSet<Log> Logs { get; set; }

        public LogDbContext(DbContextOptions<LogDbContext> options)
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
        }
    }
}