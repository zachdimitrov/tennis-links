using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TennisLinks.Web.Models.Home
{
    public class UserSearchViewModel
    {
        [Display(Name = "Username")]
        public string SearchUserName { get; set; }

        [Display(Name = "Skill")]
        public double? SearchSkill { get; set; }

        [Display(Name = "City")]
        public string SearchCity { get; set; }

        [Display(Name = "Club")]
        public string SearchClub { get; set; }

        [Display(Name = "Time Available")]
        public string SearchTime { get; set; }

        public IEnumerable<string> Clubs { get; set; }

        public IEnumerable<string> Cities { get; set; }

        public IEnumerable<UserSearchResultViewModel> FoundUsers { get; set; }
    }
}