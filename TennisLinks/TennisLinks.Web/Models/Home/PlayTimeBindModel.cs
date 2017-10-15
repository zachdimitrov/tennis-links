using AutoMapper;
using TennisLinks.Models;
using TennisLinks.Web.Infrastructure;

namespace TennisLinks.Web.Models.Home
{
    public class PlayTimeBindModel : IMap<PlayTime>, IHaveCustomMappings
    {
        public string Time { get; set; }

        public override string ToString()
        {
            return $"{this.Time}";
        }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<PlayTime, PlayTimeBindModel>()
                .ForMember(viewModel => viewModel.Time, cfg => cfg.MapFrom(model => model.Time.ToString()));
        }
    }
}