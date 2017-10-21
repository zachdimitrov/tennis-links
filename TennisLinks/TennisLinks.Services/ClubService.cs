using System;
using System.Collections.Generic;
using System.Linq;
using TennisLinks.Data.Interfaces;
using TennisLinks.Models;
using TennisLinks.Models.Enumerations;
using TennisLinks.Services.Interfaces;

namespace TennisLinks.Services
{
    public class ClubService : IClubService, IDataService
    {
        private readonly IEfRepository<Club> clubsRepo;
        private readonly ICityService cityService;
        private readonly ISaveContext context;

        public ClubService(IEfRepository<Club> clubsRepo, ICityService cityService, ISaveContext context)
        {
            this.clubsRepo = clubsRepo;
            this.cityService = cityService;
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

        public IEnumerable<string> GetAllNames()
        {
            return this.clubsRepo
                .All
                .Select(x => x.Name)
                .ToList();
        }

        public int AddByNames(string name, string city, string surface)
        {
            var cities = this.cityService.GetAllNames();
            if (!cities.Contains(city))
            {
                return -5;
            }
            City foundCity = this.cityService.GetByName(city);

            return this.Add(new Club()
            {
                Name = name,
                City_Id = foundCity.Id,
                SurfaceType = (Surface)Enum.Parse(typeof(Surface), surface, true)
            });
        }
    }
}
