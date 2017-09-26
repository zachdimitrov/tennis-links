using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using TennisLinks.Models;

namespace TennisLinks.Data.Interfaces
{
    public interface ITennisLinksDbContext
    {
        IDbSet<Message> Messages { get; set; }

        IDbSet<User> Users { get; set; }

        IDbSet<Club> Clubs { get; set; }

        IDbSet<City> Cities { get; set; }

        IDbSet<T> Set<T>() where T : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
