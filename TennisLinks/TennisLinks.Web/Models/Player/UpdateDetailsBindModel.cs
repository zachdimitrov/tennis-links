using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;
using TennisLinks.Models.Attributes;
using TennisLinks.Web.Models.Home;

namespace TennisLinks.Web.Models.Player
{
    public class UpdateDetailsBindModel
    {
        [Required]
        public string Gender { get; set; }

        [Required]
        [Range(1, 120, ErrorMessage = "Enter your real age please!")]
        public int Age { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(250, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 10)]
        public string Info { get; set; }

        [SkillValidation]
        [Display(Name = "Skill Level")]
        public double SkillLevel { get; set; }

        public string City { get; set; }

        public string Club { get; set; }

        [Display(Name = "Profile picture")]
        [ImageValidation(ErrorMessage="Only image types. Filesize must be > 0.5kb and < 1mb!")]
        public HttpPostedFileBase Image { get; set; }

        [Display(Name = "Available to play")]
        public string PlayTime { get; set; }

        public IEnumerable<string> AllCities { get; set; }

        public IEnumerable<string> AllClubs { get; set; }

        public IEnumerable<string> AllPlayTimes { get; set; }
    }
}