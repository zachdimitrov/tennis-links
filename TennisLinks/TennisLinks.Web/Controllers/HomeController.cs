using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TennisLinks.Services.Interfaces;
using TennisLinks.Web.Infrastructure;
using TennisLinks.Web.Models.Home;

namespace TennisLinks.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService userService;

        public HomeController(IUserService userService)
        {
            this.userService = userService;
        }

        public ActionResult Index()
        {
            return View();
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
            var users = this.userService
                .GetAll()
                .MapTo<UserSearchResultViewModel>()
                .ToList();

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
            var users = this.userService
                .GetAll()
                .MapTo<UserSearchResultViewModel>()
                .Where(x => x.UserName.ToLower().Contains(model.SearchUserName.ToLower()) ||
                            x.Skill == model.SearchSkill ||
                            x.City == model.SearchCity)
                .ToList();

            model.FoundUsers = users;

            return View(model);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}