using System.Linq;
using TennisLinks.Data.Interfaces;
using TennisLinks.Models;
using TennisLinks.Services.Interfaces;

namespace TennisLinks.Services
{
    public class DetailsService : IDetailsService, IDataService
    {
        private ISaveContext context;
        private readonly IEfRepository<Details> detailsRepo;

        public DetailsService(IEfRepository<Details> userRepo, ISaveContext context)
        {
            this.detailsRepo = userRepo;
            this.context = context;
        }

        public IQueryable<Details> GetAll()
        {
            return this.detailsRepo.All;
        }

        public int Update(Details details)
        {
            this.detailsRepo.Update(details);
            return this.context.Commit();
        }
    }
}
