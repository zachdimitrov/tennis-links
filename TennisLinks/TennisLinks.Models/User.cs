using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TennisLinks.Models.Enumerations;

namespace TennisLinks.Models
{
    public class User
    {
        private ICollection<PlayTime> playTimes;
        private ICollection<Club> clubs;

        public User()
        {
            this.playTimes = new HashSet<PlayTime>();
            this.clubs = new HashSet<Club>();
        }

        public string Id { get; set; }

        [Column("Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Username { get; set; }

        [Required]
        public int Age { get; set; }

        public Gender Gender { get; set; }

        [Column("Skill Level")]
        public double Skill { get; set; }

        public int CityId { get; set; }

        public virtual City City { get; set; }

        public virtual ICollection<PlayTime> PlayTimes
        {
            get { return this.playTimes; }
            set { this.playTimes = value; }
        }

        public virtual ICollection<Club> Clubs
        {
            get { return this.clubs; }
            set { this.clubs = value; }
        }
    }
}
