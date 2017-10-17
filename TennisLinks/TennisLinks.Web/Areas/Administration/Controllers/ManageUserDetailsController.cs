using AutoMapper;
using System;
using System.Linq;
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
        private readonly IMapper mapper;
        // private readonly IFavoriteService favorService;

        public ManageUserDetailsController(IUserService userService, IMapper mapper)
        {
            this.userService = userService;
            this.mapper = mapper;
        }

        [HttpGet]
        public ActionResult Index()
        {
            // TODO: show favorites
            // var id = Guid.Parse(this.User.Identity.GetDetailsId());
            // var favorites = this.favorService
            //    .GetAll()
            //    .Where(f => f.Details_Id == id)
            //    .Select(f => f.UserName)
            //    .ToList();

            var users = this.userService
                .GetAll()
                .MapTo<ManageUserDetailsViewModel>()  // tests do not work
                .ToList();

            // for testing, but does not work too
            // this.mapper.Map<ManageUserDetailsViewModel>(users);

            return this.View(users);
        }
    }
}