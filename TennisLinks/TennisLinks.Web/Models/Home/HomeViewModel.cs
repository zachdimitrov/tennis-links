using System.Collections.Generic;

namespace TennisLinks.Web.Models.Home
{
    public class HomeViewModel
    {
        public ICollection<UserSearchResultViewModel> Users { get; set; }
    }
}