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
using System.IO;

namespace TennisLinks.Web.Controllers
{
    [Authorize]
    public class PlayerController : Controller
    {
        // private readonly IMapper mapper;
        private readonly IUserService userService;
        private readonly IDetailsService detailsService;
        private readonly IClubService clubService;
        private readonly ICityService cityService;
        private readonly IFavoriteService favorService;
        private readonly IPlayTimeService playTimeService;

        public PlayerController(
            IUserService userService,
            IDetailsService detailsService,
            IClubService clubService,
            ICityService cityService,
            IFavoriteService favorService,
            IPlayTimeService playTimeService)
        {
            this.userService = userService;
            this.detailsService = detailsService;
            this.clubService = clubService;
            this.cityService = cityService;
            this.favorService = favorService;
            this.playTimeService = playTimeService;
        }

        //
        // GET: /Player/Details
        [HttpGet]
        public ActionResult Details(string username)
        {
            UserSearchResultViewModel user = null;

            if (username != null && username is string)
            {
                var detailsId = this.User.Identity.GetDetailsId();
                var favorites = this.favorService.AllNamesPerUserId(Guid.Parse(detailsId));

                user = this.userService
                    .GetAll()
                    .Where(u => u.UserName == username)
                    .MapTo<UserSearchResultViewModel>()
                    .First();

                if (favorites.Contains(user.UserName))
                {
                    user.Favorite = true;
                }
                else
                {
                    user.Favorite = false;
                }

                user.Favorites = favorites;
            }
            else // does not work
            {
                var detailsId = this.User.Identity.GetDetailsId();
                var favorites = this.favorService.AllNamesPerUserId(Guid.Parse(detailsId));

                var idString = this.User.Identity.GetUserId();
                var id = Guid.Parse(idString);
                user = this.userService
                    .GetAll()
                    .Where(u => u.Id == idString)
                    .MapTo<UserSearchResultViewModel>()
                    .First();

                user.Favorites = favorites;
            }

            return View(user);
        }

        //
        // GET: /Player/UpdateDetails
        [HttpGet]
        public ActionResult UpdateDetails()
        {
            ViewBag.UserName = this.User.Identity.GetUserName();

            var allClubs = this.clubService.GetAllNames();
            var allCities = this.cityService.GetAllNames();
            var allPlayTimes = this.playTimeService.GetAllTimes();

            var viewDetails = new UpdateDetailsBindModel()
            {
                AllPlayTimes = allPlayTimes,
                AllClubs = allClubs,
                AllCities = allCities,
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

            if (model.Age > 0)
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


            if (model.Image != null && this.ModelState.IsValid)
            {
                ViewBag.ImageError = null;
                var fileName = Path.GetFileName(model.Image.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/Uploaded"), fileName);
                model.Image.SaveAs(path);
                details.ImageUrl = $"/Content/Uploaded/{fileName}";
            }
            else
            {
                details.ImageUrl = "/Content/Images/tennis-default.png";
            }


            var result = this.detailsService.Update(details);

            if (result > 0)
            {
                return this.RedirectToAction("Details");
            }

            return this.DetailsValidationFailure();
        }

        public HttpStatusCodeResult DetailsValidationFailure()
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "User details validation failed");
        }

        public HttpStatusCodeResult ClubValidationFailure(string name)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest, $"Club \"{name}\" does not exist. Add it first.");
        }
    }
}