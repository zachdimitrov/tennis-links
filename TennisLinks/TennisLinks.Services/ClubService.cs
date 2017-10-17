using System.Linq;
using TennisLinks.Data.Interfaces;
using TennisLinks.Models;
using TennisLinks.Services.Interfaces;

namespace TennisLinks.Services
{
    public class ClubService : IClubService, IDataService
    {
        private readonly IEfRepository<Club> clubsRepo;
        private readonly ISaveContext context;

        public ClubService(IEfRepository<Club> clubsRepo, ISaveContext context)
        {
            this.clubsRepo = clubsRepo;
            this.context = context;
        }

        public IQueryable<Club> GetAll()
        {
            return this.clubsRepo.All;
        }

        public int Add(Club club)
        {
            this.clubsRepo.Add(club);
            return this.context.Commit();
        }

        public int Update(Club club)
        {
            this.clubsRepo.Update(club);
            return this.context.Commit();
        }
    }
}
