using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TennisLinks.Models;
using TennisLinks.Web.Infrastructure;

namespace TennisLinks.Web.Areas.Administration.Models
{
    public class ClubAddViewModel : IMap<Club>
    {
        [Required]
        [StringLength(40, ErrorMessage = "Error! Club name must be no more than {1} characters long.")]
        public string Name { get; set; }

        [Required]
        [StringLength(40, ErrorMessage = "Error! City name must be no more than {1} characters long.")]
        public string City { get; set; }

        public string Surface { get; set; }

        public IEnumerable<string> Cities { get; set; }

        public string Error { get; set; }

        public string Success { get; set; }
    }
}