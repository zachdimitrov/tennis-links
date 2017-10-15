using System.Linq;
using TennisLinks.Data.Interfaces;
using TennisLinks.Models;
using TennisLinks.Services.Interfaces;

namespace TennisLinks.Services
{
    public class UserService : IUserService, IDataService
    {
        private ISaveContext context;
        private readonly IEfRepository<User> userRepo;

        public UserService(IEfRepository<User> userRepo, ISaveContext context)
        {
            this.userRepo = userRepo;
            this.context = context;
        }

        public IQueryable<User> GetAll()
        {
            return this.userRepo.All;
        }

        public User GetById(string Id)
        {
            return this.userRepo.All.SingleOrDefault(x => x.Id == Id);
        }

        public int Update(User user)
        {
            this.userRepo.Update(user);
            return this.context.Commit();
        }
    }
}
