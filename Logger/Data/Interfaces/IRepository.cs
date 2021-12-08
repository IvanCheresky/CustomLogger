using System.Linq;
using System.Threading.Tasks;

namespace LoggerExercise.Logger.Data.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        Task<T> Get(int id);
        Task<T> Add(T t);
        Task<T> Update(T t);
        Task Delete(int id);
        void SaveChanges();
    }
}