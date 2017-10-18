using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TennisLinks.Models;
using TennisLinks.Services.Interfaces;
using TennisLinks.Models.Extensions;

namespace TennisLinks.Web.Controllers
{
    [Authorize]
    public class FavoritesController : Controller
    {
        private readonly IUserService userService;
        private readonly IDetailsService detailsService;
        private readonly IFavoriteService favService;

        public FavoritesController(
            IUserService userService,
            IDetailsService detailsService,
            IFavoriteService favService)
        {
            this.userService = userService;
            this.detailsService = detailsService;
            this.favService = favService;
        }

        // TODO: do with ajax
        public ActionResult Add(string userName)
        {
            var favorite = new Favorite() { UserName = userName, Details_Id = Guid.Parse(this.User.Identity.GetDetailsId())};
            this.favService.Add(favorite);
            return this.RedirectToAction("All", "Home");
        }

        // TODO: do with ajax
        public ActionResult Remove(string userName)
        {
            var id = Guid.Parse(this.User.Identity.GetDetailsId());
            var favorite = favService
                .GetAll()
                .Where(f => f.Details_Id == id && f.UserName == userName)
                .FirstOrDefault();

            var result = favService.Delete(favorite);

            if (result < 0)
            {
                // todo
            }

            return this.RedirectToAction("All", "Home");
        }
    }
}