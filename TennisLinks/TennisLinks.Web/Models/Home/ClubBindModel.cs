using AutoMapper;
using TennisLinks.Models;
using TennisLinks.Web.Infrastructure;

namespace TennisLinks.Web.Models.Home
{
    public class ClubBindModel : IMap<Club>, IHaveCustomMappings
    {
        public string Name { get; set; }

        public string SurfaceType { get; set; }

        public string City { get; set; }

        public override string ToString()
        {
            return $"{this.Name}";
        }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Club, ClubBindModel>()
                .ForMember(viewModel => viewModel.City, cfg => cfg.MapFrom(model => model.City.Name))
                .ForMember(viewModel => viewModel.SurfaceType, cfg => cfg.MapFrom(model => model.SurfaceType.ToString()));
        }
    }
}