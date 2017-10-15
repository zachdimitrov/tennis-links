using AutoMapper;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TennisLinks.Models;
using TennisLinks.Models.Enumerations;
using TennisLinks.Services.Interfaces;
using TennisLinks.Web.Models.Home;
using TennisLinks.Web.Models.Player;

namespace TennisLinks.Web.Controllers
{
    [Authorize]
    public class PlayerController : Controller
    {
        private readonly IMapper mapper;
        private readonly IUserService userService;
        private readonly IDetailsService detailsService;
        private readonly IClubService clubService;
        private readonly ICityService cityService;
        private readonly IPlayTimeService playTimeService;

        public PlayerController(
            IMapper mapper,
            IUserService userService,
            IDetailsService detailsService,
            IClubService clubService,
            ICityService cityService,
            IPlayTimeService playTimeService)
        {
            this.mapper = mapper;
            this.userService = userService;
            this.detailsService = detailsService;
            this.clubService = clubService;
            this.cityService = cityService;
            this.playTimeService = playTimeService;
        }

        //
        // GET: /Player/Details
        public ActionResult Details()
        {
            var user = this.userService
                .GetById(this.User.Identity.GetUserId());

            var details = user.Details;

            var viewDetails = new DetailsViewModel()
            {
                Email = user.Email,
                UserName = user.UserName
            };

            mapper.Map(details, viewDetails);

            return View(viewDetails);
        }

        //
        // GET: /Player/UpdateDetails
        public ActionResult UpdateDetails()
        {
            var user = this.userService
                .GetById(this.User.Identity.GetUserId());

            var details = user.Details;
            var allClubsFromDb = this.clubService.GetAll().ToList();
            var allPlayTimesFromDb = this.playTimeService.GetAll().ToList();

            var allClubs = new List<ClubBindModel>();
            var allPlayTimes = new List<PlayTimeBindModel>();

            mapper.Map(allClubsFromDb, allClubs);
            mapper.Map(allPlayTimesFromDb, allPlayTimes);

            var viewDetails = new DetailsViewModel()
            {
                Email = user.Email,
                UserName = user.UserName,
                AllPlayTimes = allPlayTimes,
                AllClubs = allClubs
            };

            mapper.Map(details, viewDetails);

            return View(viewDetails);
        }

        //
        // POST: /Player/UpdateDetails
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateDetails(UpdateDetailsBindModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var details = new Details();
            details.Clubs = new HashSet<Club>();
            details.PlayTimes = new HashSet<PlayTime>();
            details.Favorites = new HashSet<string>();

            foreach (var c in model.Clubs)
            {
                var club = this.clubService.GetAll().SingleOrDefault(x => x.Name == c);
                if (club == null)
                {
                    return this.ClubValidationFailure(c);
                }
                details.Clubs.Add(club);
            }

            foreach (var p in model.PlayTimes)
            {
                var time = this.playTimeService.GetAll().SingleOrDefault(x => x.Time.ToString() == p);
                details.PlayTimes.Add(time);
            }

            foreach (var u in model.Favorites)
            {
                var user = this.userService.GetAll().SingleOrDefault(x => x.UserName == u).UserName;
                details.Favorites.Add(user);
            }

            var city = this.cityService.GetAll().SingleOrDefault(x => x.Name == model.City);
            if (city == null)
            {
                city = new City()
                {
                    Name = model.City
                };

                this.cityService.Add(city);
            }

            details.City = this.cityService.GetAll().SingleOrDefault(x => x.Name == model.City);
            details.Age = model.Age;
            details.Gender = (Gender)Enum.Parse(typeof(Gender), model.Gender);
            details.Skill = model.SkillLevel;

            var result = this.detailsService.Update(details);

            if (result > 0)
            {
                return this.RedirectToAction("Details");
            }

            return this.DetailsValidationFailure();
        }

        private HttpStatusCodeResult DetailsValidationFailure()
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "User details validation failed");
        }

        private HttpStatusCodeResult ClubValidationFailure(string name)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest, $"Club \"{name}\" does not exist. Add it first.");
        }
    }
}