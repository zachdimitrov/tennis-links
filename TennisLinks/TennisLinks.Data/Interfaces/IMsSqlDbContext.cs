using System.Data.Entity;
using TennisLinks.Models;

namespace TennisLinks.Data.Interfaces
{
    public interface IMsSqlDbContext
    {
        int SaveChanges();
        IDbSet<T> Set<T>() where T : class;
        IDbSet<City> Cities { get; set; }
        IDbSet<Details> Details { get; set; }
        IDbSet<Club> Clubs { get; set; }
        IDbSet<Message> Messages { get; set; }
        IDbSet<PlayTime> PlayTimes { get; set; }
        IDbSet<Favorite> Favorites { get; set; }
    }
}