using System.Linq;
using TennisLinks.Models;

namespace TennisLinks.Services.Interfaces
{
    public interface IDetailsService
    {
        IQueryable<Details> GetAll();
        int Update(Details details);
    }
}