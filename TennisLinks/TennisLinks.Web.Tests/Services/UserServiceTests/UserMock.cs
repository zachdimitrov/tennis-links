using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TennisLinks.Models;

namespace TennisLinks.Web.Tests.Services.UserServiceTests
{
    class UserMock : User
    {
        public new string Id { get; set; }
    }
}
