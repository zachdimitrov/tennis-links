using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TennisLinks.Models.Abstracts;

namespace TennisLinks.Models
{
    public class City : DataModel
    {
        private ICollection<User> users;

        private ICollection<Club> clubs;

        public City()
        {
            this.users = new HashSet<User>();
            this.clubs = new HashSet<Club>();
        }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        public virtual ICollection<User> Users
        {
            get { return this.users; }
            set { this.users = value; }
        }

        public virtual ICollection<Club> Clubs
        {
            get { return this.clubs; }
            set { this.clubs = value; }
        }
    }
}
