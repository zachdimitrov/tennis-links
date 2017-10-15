using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TennisLinks.Models.Abstracts;
using TennisLinks.Models.Enumerations;

namespace TennisLinks.Models
{
    public class PlayTime : DataModel
    {
        private ICollection<Details> userDetails;

        public PlayTime()
        {
            this.userDetails = new HashSet<Details>();
        }

        public PlayTime(TimeOfDay time, DateTime createdOn)
        {
            this.Time = time;
            this.CreatedOn = createdOn;
            this.userDetails = new HashSet<Details>();
        }

        [Required]
        public TimeOfDay Time { get; set; }

        public virtual ICollection<Details> UserDetails
        {
            get { return this.userDetails; }
            set { this.userDetails = value; }
        }
    }
}
