using AutoMapper;
using TennisLinks.Models;
using TennisLinks.Web.Infrastructure;

namespace TennisLinks.Web.Models.Home
{
    public class HomeViewModel : IMap<User>, IHaveCustomMappings
    {
        public string UserName { get; set; }

        public string ImageUrl { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<User, HomeViewModel>()
                .ForMember(viewModel => viewModel.ImageUrl, cfg => cfg.MapFrom(model => model.Details.ImageUrl));
        }
    }
}