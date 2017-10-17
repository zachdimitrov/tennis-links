using System.Linq;
using TennisLinks.Data.Interfaces;
using TennisLinks.Models;
using TennisLinks.Services.Interfaces;

namespace TennisLinks.Services
{
    public class CityService : ICityService, IDataService
    {
        private readonly IEfRepository<City> citiesRepo;
        private readonly ISaveContext context;

        public CityService(IEfRepository<City> citiesRepo, ISaveContext context)
        {
            this.citiesRepo = citiesRepo;
            this.context = context;
        }

        public IQueryable<City> GetAll()
        {
            return this.citiesRepo.All;
        }

        public int Add(City city)
        {
            this.citiesRepo.Add(city);
            return this.context.Commit();
        }

        public int Update(City city)
        {
            this.citiesRepo.Update(city);
            return this.context.Commit();
        }
    }
}
