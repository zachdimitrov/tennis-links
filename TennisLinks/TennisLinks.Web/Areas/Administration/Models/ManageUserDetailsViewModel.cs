using AutoMapper;
using GridMvc.DataAnnotations;
using TennisLinks.Models;
using TennisLinks.Web.Infrastructure;

namespace TennisLinks.Web.Areas.Administration.Models
{
    [GridTable(PagingEnabled = true, PageSize = 8)]
    public class ManageUserDetailsViewModel : IMap<User>, IHaveCustomMappings
    {
        [GridHiddenColumn]
        public string Id { get; set; }

        [GridColumn(Title = "Username", SortEnabled = true, FilterEnabled = true)]
        public string UserName { get; set; }

        [GridColumn(Title = "Age", SortEnabled = true, FilterEnabled = true)]
        public int Age { get; set; }

        [GridColumn(Title = "Gender", SortEnabled = true, FilterEnabled = true)]
        public string Gender { get; set; }

        [GridColumn(Title = "E-mail", SortEnabled = true, FilterEnabled = true)]
        public string Email { get; set; }

        [GridColumn(Title = "City", SortEnabled = true, FilterEnabled = true)]
        public string City { get; set; }

        [GridColumn(Title = "User info", SortEnabled = true, FilterEnabled = true)]
        public string Info { get; set; }

        [GridColumn(Title = "Skill level", SortEnabled = true, FilterEnabled = true)]
        public double Skill { get; set; }

        [GridColumn(Title = "Available time", SortEnabled = true, FilterEnabled = true)]
        public string PlayTime { get; set; }

        [GridColumn(Title = "Favorite club", SortEnabled = true, FilterEnabled = true)]
        public string Club { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<User, ManageUserDetailsViewModel>()
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