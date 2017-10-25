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
            var id = Guid.Parse(this.User.Identity.GetDetailsId());
            var current = this.favService.AllNamesPerUserId(id);
            var currentDeleted = this.favService.AllDeletedNamesPerUserId(id);

            if (current.Contains(userName))
            {
                return this.Redirect(Request.UrlReferrer.ToString());
            }

            if (currentDeleted.Contains(userName))
            {
                var fav = this.favService.GetDeletedByUsername(id, userName);
                fav.IsDeleted = false;
                this.favService.Update(fav);
                return this.Redirect(Request.UrlReferrer.ToString());
            }

            var favorite = new Favorite() { UserName = userName, Details_Id = Guid.Parse(this.User.Identity.GetDetailsId())};
            this.favService.Add(favorite);

            return this.Redirect(Request.UrlReferrer.ToString());
        }

        // TODO: do with ajax
        public ActionResult Remove(string userName)
        {
            var id = Guid.Parse(this.User.Identity.GetDetailsId());

            var fav = this.favService.GetByUsername(id, userName);

            var result = favService.Delete(fav);

            if (result < 0)
            {
                return this.Redirect(Request.UrlReferrer.ToString());
            }

            return this.Redirect(Request.UrlReferrer.ToString());
        }
    }
}