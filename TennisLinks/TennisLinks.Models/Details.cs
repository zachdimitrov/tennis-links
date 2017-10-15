using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TennisLinks.Models.Abstracts;
using TennisLinks.Models.Attributes;
using TennisLinks.Models.Enumerations;

namespace TennisLinks.Models
{
    public class Details : DataModel
    {
        private ICollection<PlayTime> playTimes;
        private ICollection<Club> clubs;
        private ICollection<string> favorites;

        public Details()
        {
            this.playTimes = new HashSet<PlayTime>();
            this.clubs = new HashSet<Club>();
            this.favorites = new HashSet<string>();
        }

        public int? Age { get; set; }

        public Gender? Gender { get; set; }

        [StringLength(250, MinimumLength = 10)]
        public string Info { get; set; }

        [Column("Skill Level")]
        [SkillValidation]
        public double Skill { get; set; }

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

        public virtual ICollection<string> Favorites
        {
            get { return this.favorites; }
            set { this.favorites = value; }
        }
    }
}
