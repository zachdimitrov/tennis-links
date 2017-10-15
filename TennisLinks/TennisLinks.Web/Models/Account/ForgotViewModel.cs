using System.ComponentModel.DataAnnotations;

namespace TennisLinks.Web.Models.Account
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}