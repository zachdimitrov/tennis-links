using AutoMapper;
using AutoMapper.Configuration;

namespace TennisLinks.Web.Infrastructure.Mappings
{
    public interface IHaveCustomMappings
    {
        void CreateMappings(IConfiguration configuration);
    }
}
