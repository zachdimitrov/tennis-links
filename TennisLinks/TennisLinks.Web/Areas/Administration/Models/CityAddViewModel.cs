using System.ComponentModel.DataAnnotations;
using TennisLinks.Models;
using TennisLinks.Web.Infrastructure;

namespace TennisLinks.Web.Areas.Administration.Models
{
    public class CityAddViewModel : IMap<City>
    {
        [Required]
        [StringLength(40, ErrorMessage = "Error! The {0} must be no more than {1} characters long.")]
        public string Name { get; set; }

        public string Error { get; set; }

        public string Success { get; set; }
    }
}