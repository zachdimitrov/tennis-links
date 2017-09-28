using System.ComponentModel.DataAnnotations;
using TennisLinks.Models.Abstracts;

namespace TennisLinks.Models
{
    public class Message : DataModel
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        [StringLength(250, MinimumLength = 10)]
        public string Content { get; set; }

        public virtual User Contact { get; set; }

        public virtual User Author { get; set; }
    }
}
