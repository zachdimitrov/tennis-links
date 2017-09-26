using Ninject;

namespace TennisLinks.Web.Infrastructure.Registries
{
    public interface INinjectRegistry
    {
        void Register(IKernel kernel);
    }
}
