using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TennisLinks.Models.Abstracts;
using TennisLinks.Models.Enumerations;

namespace TennisLinks.Models
{
    public class PlayTime : DataModel
    {
        private ICollection<User> users;

        public PlayTime()
        {
            this.users = new HashSet<User>();
        }

        public PlayTime(TimeOfDay time)
        {
            this.Time = time;
            this.users = new HashSet<User>();
        }

        [Required]
        public TimeOfDay Time { get; set; }

        public virtual ICollection<User> Users
        {
            get { return this.users; }
            set { this.users = value; }
        }
    }
}
