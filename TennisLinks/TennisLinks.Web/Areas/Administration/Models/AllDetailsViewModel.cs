using System.Collections.Generic;

namespace TennisLinks.Web.Areas.Administration.Models
{
    public class AllDetailsViewModel
    {
        public IEnumerable<UserDetailsViewModel> Users {get; set;}

        public IEnumerable<CityDetailsViewModel> Cities {get; set;}

        public IEnumerable<ClubDetailsViewModel> Clubs {get; set; }
    }
}