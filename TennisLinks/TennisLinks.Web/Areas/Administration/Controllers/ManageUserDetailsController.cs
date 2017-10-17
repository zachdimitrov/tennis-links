using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TennisLinks.Models.Extensions;
using TennisLinks.Services.Interfaces;
using TennisLinks.Web.Areas.Administration.Models;
using TennisLinks.Web.Infrastructure;

namespace TennisLinks.Web.Areas.Administration.Controllers
{
    public class ManageUserDetailsController : Controller
    {
        private readonly IUserService userService;
        private readonly IFavoriteService favorService;

        public ManageUserDetailsController(IUserService userService, IFavoriteService favorService)
        {
            this.userService = userService;
            this.favorService = favorService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var id = Guid.Parse(this.User.Identity.GetDetailsId());
            var favorites = this.favorService
                .GetAll()
                .Where(f => f.Details_Id == id)
                .Select(f => f.UserName)
                .ToList();

            var users = this.userService
                .GetAll()
                .MapTo<ManageUserDetailsViewModel>()
                .ToList();

            // TODO: show favorites

            return this.View(users);
        }
    }
}