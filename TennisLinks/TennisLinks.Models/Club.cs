using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TennisLinks.Models.Abstracts;
using TennisLinks.Models.Enumerations;

namespace TennisLinks.Models
{
    public class Club : DataModel
    {
        private ICollection<User> users;

        public Club()
        {
            this.users = new HashSet<User>();
        }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        public Surface SurfaceType { get; set; }

        public virtual City City { get; set; }

        public virtual ICollection<User> Users
        {
            get { return this.users; }
            set { this.users = value; }
        }
    }
}
