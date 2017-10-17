using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TennisLinks.Models.Abstracts;
using TennisLinks.Models.Attributes;
using TennisLinks.Models.Enumerations;
using TennisLinks.Models.Interfaces;

namespace TennisLinks.Models
{
    public class Details : DataModel, IDetails
    {
        private IEnumerable<Favorite> favorites;

        public Details()
        {
            this.favorites = new HashSet<Favorite>();
        }

        public int? Age { get; set; }

        public Gender? Gender { get; set; }

        [StringLength(250, MinimumLength = 10)]
        public string Info { get; set; }

        [Column("Skill Level")]
        [SkillValidation]
        public double Skill { get; set; }

        public Guid? City_Id { get; set; }

        [ForeignKey("City_Id")]
        public virtual City City { get; set; }

        public Guid? PlayTime_Id { get; set; }

        [ForeignKey("PlayTime_Id")]
        public virtual PlayTime PlayTime { get; set; }

        public Guid? Club_Id { get; set; }

        [ForeignKey("Club_Id")]
        public virtual Club Club { get; set; }

        public virtual IEnumerable<Favorite> Favorites { get; set; }
    }
}
