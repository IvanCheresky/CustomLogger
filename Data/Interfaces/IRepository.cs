using System.Linq;

namespace LoggerExercise.Data.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T Get(int id);
        T Add(T t);
        T Update(T t);
        void Delete(int id);
        void SaveChanges();
    }
}