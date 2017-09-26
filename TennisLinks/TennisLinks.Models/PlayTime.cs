using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TennisLinks.Models.Enumerations;

namespace TennisLinks.Models
{
    public class PlayTime
    {
        private ICollection<User> users;

        public PlayTime()
        {
            this.Id = (int)this.Time;
            this.users = new HashSet<User>();
        }

        [Key]
        public int Id;

        [Required]
        public TimeOfDay Time { get; set; }

        public virtual ICollection<User> Users
        {
            get { return this.users; }
            set { this.users = value; }
        }
    }
}
