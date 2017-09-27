using TennisLinks.Data.Interfaces;
using TennisLinks.Models;

namespace TennisLinks.Data.Repositories
{
    public class UsersRepository : EfRepository<User>, IUserRepository
    {
        public UsersRepository(ITennisLinksDbContext data)
            : base(data)
        {
        }

        public User GetByUsername(string username)
        {
            return this.context.Users.Find(username);
        }
    }
}
