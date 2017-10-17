using System.Data.Entity;
using System.Linq;
using TennisLinks.Data;
using TennisLinks.Data.Interfaces;
using TennisLinks.Models;
using TennisLinks.Services.Interfaces;

namespace TennisLinks.Services
{
    public class DetailsService : IDetailsService, IDataService
    {
        private ISaveContext context;
        private readonly IEfRepository<Details> generalRepo;
        private MsSqlDbContext db;

        public DetailsService(IEfRepository<Details> generalRepo, ISaveContext context, MsSqlDbContext db)
        {
            this.generalRepo = generalRepo;
            this.context = context;
            this.db = db;
        }

        public IQueryable<Details> GetAll()
        {
            return this.generalRepo.All;
        }

        public int Update(Details details)
        {
            this.generalRepo.Update(details);

            return this.context.Commit();
        }
    }
}
