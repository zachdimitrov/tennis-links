using TennisLinks.Data.Repositories;
using TennisLinks.Models;

namespace TennisLinks.Data.Interfaces
{
    public interface ITennisLinksData
    {
        IRepository<Message> Messages { get; }

        IUserRepository Users { get; }
    }
}
