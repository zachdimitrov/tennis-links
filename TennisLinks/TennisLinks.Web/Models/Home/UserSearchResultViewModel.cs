using System.Collections.Generic;
using AutoMapper;
using TennisLinks.Models;
using TennisLinks.Web.Infrastructure;

namespace TennisLinks.Web.Models.Home
{
    public class UserSearchResultViewModel : IMap<User>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

        public string Email { get; set; }

        public string City { get; set; }

        public string Info { get; set; }

        public double Skill { get; set; }

        public ICollection<PlayTimeBindModel> PlayTimes { get; set; }

        public ICollection<ClubBindModel> Clubs { get; set; }

        public ICollection<string> Favorites { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<User, UserSearchResultViewModel>()
                .ForMember(viewModel => viewModel.Age, cfg => cfg.MapFrom(model => model.Details.Age))
                .ForMember(viewModel => viewModel.Gender, cfg => cfg.MapFrom(model => model.Details.Gender.ToString()))
                .ForMember(viewModel => viewModel.Info, cfg => cfg.MapFrom(model => model.Details.Info))
                .ForMember(viewModel => viewModel.Skill, cfg => cfg.MapFrom(model => model.Details.Skill))
                .ForMember(viewModel => viewModel.PlayTimes, cfg => cfg.MapFrom(model => model.Details.PlayTimes))
                .ForMember(viewModel => viewModel.Clubs, cfg => cfg.MapFrom(model => model.Details.Clubs))
                .ForMember(viewModel => viewModel.City, cfg => cfg.MapFrom(model => model.Details.City.Name));
        }
    }
}