using AutoMapper;

namespace TennisLinks.Web.Infrastructure
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IMapperConfigurationExpression configuration);
    }
}