using System.Linq;
using TennisLinks.Models;

namespace TennisLinks.Services.Interfaces
{
    public interface IClubService
    {
        IQueryable<Club> GetAll();
        int Update(Club club);
    }
}