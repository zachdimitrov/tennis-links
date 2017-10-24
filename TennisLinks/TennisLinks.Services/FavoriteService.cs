using System;
using System.Collections.Generic;
using System.Linq;
using TennisLinks.Data.Interfaces;
using TennisLinks.Models;
using TennisLinks.Services.Interfaces;

namespace TennisLinks.Services
{
    public class FavoriteService : IFavoriteService, IDataService
    {
        private readonly IEfRepository<Favorite> favsRepo;
        private readonly ISaveContext context;

        public FavoriteService(IEfRepository<Favorite> favsRepo, ISaveContext context)
        {
            this.favsRepo = favsRepo;
            this.context = context;
        }

        public int Add(Favorite favorite)
        {
            this.favsRepo.Add(favorite);
            return this.context.Commit();
        }

        public IQueryable<Favorite> GetAll()
        {
            return this.favsRepo.All;
        }

        public int Update(Favorite favorite)
        {
            this.favsRepo.Update(favorite);
            return this.context.Commit();
        }

        public int Delete(Favorite favorite)
        {
            this.favsRepo.Delete(favorite);
            return this.context.Commit();
        }

        public IEnumerable<string> AllNamesPerUserId(Guid id)
        {
            return this.GetAll()
                .Where(f => f.Details_Id == id)
                .Select(f => f.UserName)
                .ToList();
        }
    }
}
