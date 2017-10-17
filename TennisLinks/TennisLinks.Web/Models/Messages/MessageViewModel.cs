using System;
using System.ComponentModel.DataAnnotations;
using TennisLinks.Models;
using TennisLinks.Web.Infrastructure;

namespace TennisLinks.Web.Models.Messages
{
    public class MessageViewModel : IMap<Message>
    {
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime CreatedOn { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [StringLength(250, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 10)]
        public string Content { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        [Display(Name = "To")]
        public string Recipient { get; set; }
    }
}