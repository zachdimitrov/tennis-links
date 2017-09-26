using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisLinks.Models;

namespace TennisLinks.Data.Repositories
{
    public interface IUserRepository
    {
        User GetByUsername(string username);
    }
}
