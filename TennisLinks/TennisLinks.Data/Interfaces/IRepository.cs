using System.Linq;

namespace TennisLinks.Data.Interfaces
{
    public interface IRepository<T>
        where T : class
    {
        IQueryable<T> All();

        T GetById(object id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        int SaveChanges();
    }
}
