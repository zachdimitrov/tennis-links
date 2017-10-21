using AutoMapper;
using System.Linq;
using System.Web.Mvc;
using TennisLinks.Services.Interfaces;
using TennisLinks.Web.Areas.Administration.Models;
using TennisLinks.Web.Infrastructure;

namespace TennisLinks.Web.Areas.Administration.Controllers
{
    public class ManageItemsDetailsController : Controller
    {
        private readonly IUserService userService;
        private readonly ICityService cityService;
        private readonly IClubService clubService;

        public ManageItemsDetailsController(
            IUserService userService,
            ICityService cityService,
            IClubService clubService)
        {
            this.userService = userService;
            this.cityService = cityService;
            this.clubService = clubService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var users = this.userService
                .GetAll()
                .MapTo<UserDetailsViewModel>() 
                .ToList();

            var cities = this.cityService
                .GetAll()
                .MapTo<CityDetailsViewModel>()
                .ToList();

            var clubs = this.clubService
                .GetAll()
                .MapTo<ClubDetailsViewModel>()
                .ToList();

            var model = new AllDetailsViewModel()
            {
                Users = users,
                Cities = cities,
                Clubs = clubs
            };

            return this.View(model);
        }
    }
}