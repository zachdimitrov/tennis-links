using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TennisLinks.Models.Enumerations;
using TennisLinks.Models.Interfaces;

namespace TennisLinks.Models
{
    public class Club : IEntity
    {
        private ICollection<User> users;

        public Club()
        {
            this.users = new HashSet<User>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        public Surface SurfaceType { get; set; }

        public int CityId { get; set; }

        public virtual City City { get; set; }

        public virtual ICollection<User> Users
        {
            get { return this.users; }
            set { this.users = value; }
        }
    }
}
