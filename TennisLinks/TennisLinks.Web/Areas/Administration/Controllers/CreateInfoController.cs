using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TennisLinks.Services.Interfaces;
using TennisLinks.Web.Areas.Administration.Models;

namespace TennisLinks.Web.Areas.Administration.Controllers
{
    [Authorize]
    public class CreateInfoController : Controller
    {
        private readonly IClubService clubService;
        private readonly ICityService cityService;

        public CreateInfoController(IClubService clubService, ICityService cityService)
        {
            this.clubService = clubService;
            this.cityService = cityService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult City(string error, string success)
        {
            var cityAddModel = new CityAddViewModel();

            if (error != null)
            {
                cityAddModel.Error = error;
            }

            if (success != null)
            {
                cityAddModel.Success = success;
            }

            return View(cityAddModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult City(CityAddViewModel model)
        {
            var otherCities = this.cityService.GetAllNames();

            if (model.Name == null || model.Name.Length < 3 || !(model.Name is string))
            {
                return this.RedirectToAction("City", new { error = "Error! Name of city must be a string with 3 or more symbols!" });
            }

            if (otherCities.Contains(model.Name))
            {
                return this.RedirectToAction("City", new { error = $"Error! City {model.Name} already exists!" });
            }

            int result = this.cityService.AddByName(model.Name);

            if (result <= 0)
            {
                return this.RedirectToAction("City", new { error = $"Error! City {model.Name} was not created!" });
            }

            return this.RedirectToAction("City", new { success = $"Success! City {model.Name} was added to database!" });
        }

        [HttpGet]
        public ActionResult Club(string error, string success)
        {
            var cities = this.cityService.GetAllNames();

            var clubAddModel = new ClubAddViewModel()
            {
                Cities = cities
            };

            if (error != null)
            {
                clubAddModel.Error = error;
            }

            if (success != null)
            {
                clubAddModel.Success = success;
            }

            return View(clubAddModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Club(ClubAddViewModel model)
        {
            var otherClubs = this.clubService.GetAllNames();

            if (model.Name == null || model.Name.Length < 3 || !(model.Name is string))
            {
                return this.RedirectToAction("Club", new { error = "Error! Name of club must be a string with 3 or more symbols!" });
            }

            if (model.City == null || model.City.Length < 3 || !(model.City is string))
            {
                return this.RedirectToAction("Club", new { error = "Error! Name of city must be a string with 3 or more symbols!" });
            }

            if (model.Surface == null || !(model.Surface is string))
            {
                return this.RedirectToAction("Club", new { error = "Error! Surface type is not specified!" });
            }

            if (otherClubs.Contains(model.Name))
            {
                return this.RedirectToAction("Club", new { error = $"Error! Club {model.Name} already exists!" });
            }

            int result = this.clubService.AddByNames(model.Name, model.City, model.Surface);

            if (result <= 0)
            {
                return this.RedirectToAction("Club", new { error = $"Error! Club {model.Name} was not created!" });
            }

            return this.RedirectToAction("Club", new { success = $"Success! Club {model.Name} was added to database!" });
        }
    }
}