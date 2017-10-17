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
using TennisLinks.Models.Extensions;
using TennisLinks.Web.Infrastructure;

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
        [HttpGet]
        public ActionResult Details()
        {
            var id = this.User.Identity.GetUserId();

            var user = this.userService
                .GetAll()
                .Where(u=>u.Id == id)
                .MapTo<UserSearchResultViewModel>()
                .First();

            return View(user);
        }

        //
        // GET: /Player/UpdateDetails
        [HttpGet]
        public ActionResult UpdateDetails()
        {
            ViewBag.UserName = this.User.Identity.GetUserName();

            var allClubs = this.clubService
                .GetAll()
                .Select(x=>x.Name)
                .ToList();

            var allPlayTimes = this.playTimeService
                .GetAll()
                .Select(x => x.Time.ToString())
                .ToList();

            var viewDetails = new UpdateDetailsBindModel()
            {
                AllPlayTimes = allPlayTimes,
                AllClubs = allClubs,
                Club = "",
                PlayTime = ""
            };

            return View(viewDetails);
        }

        //
        // POST: /Player/UpdateDetails
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateDetails(UpdateDetailsBindModel model)
        {
            var id = this.User.Identity.GetUserId();
            var user = this.userService
                .GetAll()
                .Where(u => u.Id == id)
                .First();

            var detailsId = this.User.Identity.GetDetailsId();

            var details = this.detailsService
                .GetAll()
                .Where(x => x.Id.ToString() == detailsId)
                .First();

            if (model.Club != null)
            {
                    var club = this.clubService
                        .GetAll()
                        .Where(x => x.Name == model.Club)
                        .First();

                    if (club == null)
                    {
                        return this.ClubValidationFailure(model.Club);
                    }

                    details.Club_Id = club.Id;
            }

            if (model.PlayTime != null)
            {
                    var time = this.playTimeService
                        .GetAll()
                        .Where(x => x.Time.ToString() == model.PlayTime)
                        .First();

                    details.PlayTime_Id = time.Id;
            }

            if (model.City != null && model.City.Length > 2)
            {
                var city = this.cityService
                    .GetAll()
                    .Where(x => x.Name == model.City)
                    .FirstOrDefault();

                if (city == null)
                {
                    city = new City()
                    {
                        Name = model.City
                    };

                    this.cityService.Add(city);
                }

                details.City_Id = city.Id;
            }

            if(model.Age > 0)
            {
                details.Age = model.Age;
            }

            if (model.Info != null)
            {
                details.Info = model.Info;
            }


            if (model.Gender != null)
            {
                details.Gender = (Gender)Enum.Parse(typeof(Gender), model.Gender);
            }

            if (model.SkillLevel >= 1)
            {
                details.Skill = model.SkillLevel;
            }
            else
            {
                details.Skill = 1;
            }

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