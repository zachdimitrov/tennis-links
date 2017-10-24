using System;
using System.Collections.Generic;
using System.Linq;
using TennisLinks.Models;

namespace TennisLinks.Services.Interfaces
{
    public interface IFavoriteService
    {
        int Add(Favorite favorite);
        int Update(Favorite favorite);
        int Delete(Favorite favorite);
        IQueryable<Favorite> GetAll();
        IEnumerable<string> AllNamesPerUserId(Guid id);
    }
}
