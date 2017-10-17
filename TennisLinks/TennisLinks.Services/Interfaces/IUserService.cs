using System.Linq;
using TennisLinks.Models;

namespace TennisLinks.Services.Interfaces
{
    public interface IUserService
    {
        IQueryable<User> GetAll();

        User GetById(string Id);
    }
}