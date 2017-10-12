using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisLinks.Data.Interfaces;
using TennisLinks.Models;
using TennisLinks.Services.Interfaces;

namespace TennisLinks.Services
{
    public class UserService : IUserService
    {
        private readonly IEfRepository<User> userRepo;

        public UserService(IEfRepository<User> userRepo)
        {
            this.userRepo = userRepo;
        }

        public IQueryable<User> GetAll()
        {
            return this.userRepo.All;
        }

    }
}
