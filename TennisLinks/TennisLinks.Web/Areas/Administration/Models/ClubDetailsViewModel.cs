using GridMvc.DataAnnotations;
using TennisLinks.Models;
using TennisLinks.Web.Infrastructure;
using AutoMapper;

namespace TennisLinks.Web.Areas.Administration.Models
{
    [GridTable(PagingEnabled = true, PageSize = 16)]
    public class ClubDetailsViewModel : IMap<Club>, IHaveCustomMappings
    {
        [GridColumn(Title = "City Id", SortEnabled = true, FilterEnabled = true)]
        public string Id { get; set; }

        [GridColumn(Title = "Name", SortEnabled = true, FilterEnabled = true)]
        public string Name { get; set; }

        [GridColumn(Title = "Clubs count", SortEnabled = true, FilterEnabled = true)]
        public string Surface { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<Club, ClubDetailsViewModel>()
                .ForMember(viewModel => viewModel.Id, cfg => cfg.MapFrom(model => model.Id.ToString()))
                .ForMember(viewModel => viewModel.Surface, cfg => cfg.MapFrom(model => model.SurfaceType.ToString()));
        }
    }
}