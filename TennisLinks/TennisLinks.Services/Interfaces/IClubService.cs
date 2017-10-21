using System.Collections.Generic;
using System.Linq;
using TennisLinks.Models;

namespace TennisLinks.Services.Interfaces
{
    public interface IClubService
    {
        IQueryable<Club> GetAll();
        int Update(Club club);
        IEnumerable<string> GetAllNames();
        int AddByNames(string name, string city, string surface);
    }
}