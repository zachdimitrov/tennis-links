using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TennisLinks.Models.Attributes;

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
        public double SkillLevel { get; set; }

        public string City { get; set; }

        public IEnumerable<string> Clubs { get; set; }

        public IEnumerable<string> PlayTimes { get; set; }

        public IEnumerable<string> Favorites { get; set; }
    }
}