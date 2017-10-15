using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TennisLinks.Models.Abstracts;

namespace TennisLinks.Models
{
    public class City : DataModel
    {
        private ICollection<Details> userDetails;

        private ICollection<Club> clubs;

        public City()
        {
            this.clubs = new HashSet<Club>();
            this.userDetails = new HashSet<Details>();
        }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        public virtual ICollection<Club> Clubs
        {
            get { return this.clubs; }
            set { this.clubs = value; }
        }

        public virtual ICollection<Details> UserDetails
        {
            get { return this.userDetails; }
            set { this.userDetails = value; }
        }
    }
}
