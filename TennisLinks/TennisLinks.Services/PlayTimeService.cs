using System;
using System.Collections.Generic;
using System.Linq;
using TennisLinks.Data.Interfaces;
using TennisLinks.Models;
using TennisLinks.Services.Interfaces;

namespace TennisLinks.Services
{
    public class PlayTimeService : IPlayTimeService, IDataService
    {
        private ISaveContext context;
        private readonly IEfRepository<PlayTime> playTimesRepo;

        public PlayTimeService(IEfRepository<PlayTime> playTimesRepo, ISaveContext context)
        {
            this.playTimesRepo = playTimesRepo;
            this.context = context;
        }

        public IQueryable<PlayTime> GetAll()
        {
            return this.playTimesRepo.All;
        }

        public IEnumerable<string> GetAllTimes()
        {
            return this.playTimesRepo.All
                .Select(x => x.Time.ToString())
                .ToList();
        }

        public int Update(PlayTime time)
        {
            this.playTimesRepo.Update(time);
            return this.context.Commit();
        }
    }
}
