using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TennisLinks.Models.Abstracts;
using TennisLinks.Models.Enumerations;

namespace TennisLinks.Models
{
    public class Club : DataModel
    {
        private ICollection<Details> userDetails;

        public Club()
        {
            this.userDetails = new HashSet<Details>();
        }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        public Surface SurfaceType { get; set; }

        public virtual City City { get; set; }

        public virtual ICollection<Details> UserDetails
        {
            get { return this.userDetails; }
            set { this.userDetails = value; }
        }
    }
}
