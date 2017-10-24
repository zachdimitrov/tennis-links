using AutoMapper;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using TennisLinks.Models;
using TennisLinks.Models.Attributes;
using TennisLinks.Web.Infrastructure;

namespace TennisLinks.Web.Models.Player
{
    public class DetailsViewModel : IMap<Details>, IHaveCustomMappings
    {
        [Required]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        public string Gender { get; set; }

        [Required]
        [Range(1, 120, ErrorMessage = "Enter your real age please!")]
        public int? Age { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(250, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 10)]
        public string Info { get; set; }

        [SkillValidation]
        public double SkillLevel { get; set; }

        public string City { get; set; }

        public string ImageUrl { get; set; }

        public string Club { get; set; }

        public string PlayTime { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Details, DetailsViewModel>()
                .ForMember(viewModel => viewModel.Gender, cfg => cfg.MapFrom(model => model.Gender != null ? model.Gender.ToString() : null))
                .ForMember(viewModel => viewModel.City, cfg => cfg.MapFrom(model => model.City.Name))
                .ForMember(viewModel => viewModel.PlayTime, cfg => cfg.MapFrom(model => model.PlayTime.Time.ToString()))
                .ForMember(viewModel => viewModel.Club, cfg => cfg.MapFrom(model => model.Club.Name));
        }
    }
}