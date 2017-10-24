using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TennisLinks.Models.Extensions;
using TennisLinks.Services.Interfaces;
using TennisLinks.Web.Infrastructure;
using TennisLinks.Web.Models.Home;

namespace TennisLinks.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService userService;
        private readonly IFavoriteService favorService;
        private readonly IClubService clubService;
        private readonly ICityService cityService;

        public HomeController(
            IUserService userService, 
            IFavoriteService favorService, 
            IClubService clubService,
            ICityService cityService)
        {
            this.userService = userService;
            this.favorService = favorService;
            this.clubService = clubService;
            this.cityService = cityService;
        }

        public ActionResult Index()
        {
            var images = this.userService
                .GetAll()
                .OrderBy(d => d.CreatedOn)
                .Where(i => i.Details.ImageUrl != "/Content/Images/tennis-default.png")
                .MapTo<HomeViewModel>()
                .ToList();

                images.Reverse();

            if(images.ElementAtOrDefault(0) == null) { images.Add(new HomeViewModel() { UserName = "sample", ImageUrl = "/Content/Images/Capture1.PNG" }); }
            if(images.ElementAtOrDefault(1) == null) { images.Add(new HomeViewModel() { UserName = "sample", ImageUrl = "/Content/Images/Capture2.PNG" }); }
            if(images.ElementAtOrDefault(2) == null) { images.Add(new HomeViewModel() { UserName = "sample", ImageUrl = "/Content/Images/Capture3.PNG" }); }
            if(images.ElementAtOrDefault(3) == null) { images.Add(new HomeViewModel() { UserName = "sample", ImageUrl = "/Content/Images/Capture4.PNG" }); }

            return View("Index", images);
        }

        // for ajax request
        [HttpGet]
        public JsonResult GetUsers()
        {
            var users = this.userService
                .GetAll()
                .Select(u=>u.UserName)
                .ToList();

            return Json(users, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult GetById(string id)
        {
            var users = this.userService
                .GetAll()
                .MapTo<UserSearchResultViewModel>()
                .SingleOrDefault(x => x.Id == id);

            return this.View(users);
        }

        [HttpGet]
        [Authorize]
        public ActionResult All()
        {
            var id = Guid.Parse(this.User.Identity.GetDetailsId());
            var favorites = this.favorService.AllNamesPerUserId(id);

            var users = this.userService
                .GetAll()
                .MapTo<UserSearchResultViewModel>()
                .ToList();

            foreach (var m in users)
            {
                if (favorites.Contains(m.UserName))
                {
                    m.Favorite = true;
                }
                else
                {
                    m.Favorite = false;
                }
            }

            return this.View(users);
        }

        [HttpGet]
        [Authorize]
        public ActionResult Search()
        {
            var clubs = this.clubService.GetAllNames();
            var cities = this.cityService.GetAllNames();

            var model = new UserSearchViewModel()
            {
                FoundUsers = new List<UserSearchResultViewModel>(),
                Clubs = clubs,
                Cities = cities
            };

            return this.View(model);
        }

        [HttpPost]
        public ActionResult Search(UserSearchViewModel model)
        {
            var clubs = this.clubService.GetAllNames();
            var cities = this.cityService.GetAllNames();

            var id = Guid.Parse(this.User.Identity.GetDetailsId());
            var favorites = this.favorService.AllNamesPerUserId(id);

            var users = this.userService
                .GetAll()
                .MapTo<UserSearchResultViewModel>()
                .Where(x => (model.SearchUserName == null || 
                      x.UserName.ToLower().Contains(model.SearchUserName.ToLower())) &&
                            (model.SearchSkill == 0 || x.Skill == model.SearchSkill) &&
                            (model.SearchCity == null || x.City == model.SearchCity) &&
                            (model.SearchClub == null || x.Club == model.SearchClub) &&
                            (model.SearchTime == null ||
                                model.SearchTime == "all" ||
                                x.PlayTime == model.SearchTime))
                .ToList();

            foreach (var m in users)
            {
                if (favorites.Contains(m.UserName))
                {
                    m.Favorite = true;
                }
                else
                {
                    m.Favorite = false;
                }
            }

            model.FoundUsers = users;
            model.Clubs = clubs;
            model.Cities = cities;

            return View(model);
        }

        public ActionResult About()
        {
            return View("About");
        }

        public ActionResult Contact()
        {
            return View("Contact");
        }
    }
}