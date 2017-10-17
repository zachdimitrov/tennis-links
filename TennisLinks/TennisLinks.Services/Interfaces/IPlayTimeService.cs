using System.Linq;
using TennisLinks.Models;

namespace TennisLinks.Services.Interfaces
{
    public interface IPlayTimeService
    {
        IQueryable<PlayTime> GetAll();

        int Update(PlayTime time);
    }
}