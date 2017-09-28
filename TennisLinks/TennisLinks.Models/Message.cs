using System;
using System.ComponentModel.DataAnnotations;
using TennisLinks.Models.Abstracts;
using TennisLinks.Models.Interfaces;

namespace TennisLinks.Models
{
    public class Message : DataModel
    {
        [Required]
        [StringLength(250, MinimumLength = 10)]
        public string Content { get; set; }

        public DateTime SentOn { get; set; }

        public string ContactId { get; set; }

        public string UserId { get; set; }

        public virtual User Contact { get; set; }

        public virtual User User { get; set; }
    }
}
