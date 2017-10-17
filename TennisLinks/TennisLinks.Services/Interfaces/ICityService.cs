using System.Linq;
using TennisLinks.Models;

namespace TennisLinks.Services.Interfaces
{
    public interface ICityService
    {
        int Add(City city);
        int Update(City city);
        IQueryable<City> GetAll();
    }
}