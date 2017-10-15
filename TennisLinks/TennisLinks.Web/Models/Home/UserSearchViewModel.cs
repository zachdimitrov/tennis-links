using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TennisLinks.Web.Models.Home
{
    public class UserSearchViewModel
    {
        [Display(Name = "Username")]
        public string SearchUserName { get; set; }

        [Display(Name = "Skill")]
        public double SearchSkill { get; set; }

        [Display(Name = "City")]
        public string SearchCity { get; set; }

        public IEnumerable<UserSearchResultViewModel> FoundUsers { get; set; }
    }
}