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

        public string PlayTime { get; set; }

        public string Club { get; set; }

        public bool Favorite { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<User, UserSearchResultViewModel>()
                .ForMember(viewModel => viewModel.Age, cfg => cfg.MapFrom(model => model.Details.Age))
                .ForMember(viewModel => viewModel.Gender, cfg => cfg.MapFrom(model => model.Details.Gender.ToString()))
                .ForMember(viewModel => viewModel.Info, cfg => cfg.MapFrom(model => model.Details.Info))
                .ForMember(viewModel => viewModel.Skill, cfg => cfg.MapFrom(model => model.Details.Skill))
                .ForMember(viewModel => viewModel.PlayTime, cfg => cfg.MapFrom(model => model.Details.PlayTime.Time.ToString()))
                .ForMember(viewModel => viewModel.Club, cfg => cfg.MapFrom(model => model.Details.Club.Name))
                .ForMember(viewModel => viewModel.City, cfg => cfg.MapFrom(model => model.Details.City.Name));
        }
    }
}