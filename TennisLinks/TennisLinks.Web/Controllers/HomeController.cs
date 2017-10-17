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

        public HomeController(IUserService userService, IFavoriteService favorService)
        {
            this.userService = userService;
            this.favorService = favorService;
        }

        public ActionResult Index()
        {
            return View("Index");
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
        public ActionResult All()
        {
            var id = Guid.Parse(this.User.Identity.GetDetailsId());
            var favorites = this.favorService
                .GetAll()
                .Where(f => f.Details_Id == id)
                .Select(f => f.UserName)
                .ToList();

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
        public ActionResult Search()
        {
            return this.View(new UserSearchViewModel() { FoundUsers = new List<UserSearchResultViewModel>() });
        }

        [HttpPost]
        public ActionResult Search(UserSearchViewModel model)
        {
            var id = Guid.Parse(this.User.Identity.GetDetailsId());
            var favorites = this.favorService
                .GetAll()
                .Where(f => f.Details_Id == id)
                .Select(f => f.UserName)
                .ToList();


            var users = this.userService
                .GetAll()
                .MapTo<UserSearchResultViewModel>()
                .Where(x => x.UserName.ToLower().Contains(model.SearchUserName.ToLower()) ||
                            x.Skill == model.SearchSkill ||
                            x.City == model.SearchCity ||
                            x.Club == model.SearchClub ||
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