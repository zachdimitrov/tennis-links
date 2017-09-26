using Ninject;
using Ninject.Web.Common;
using TennisLinks.Data;
using TennisLinks.Data.Interfaces;

namespace TennisLinks.Web.Infrastructure.Registries
{
    public class DataBindingsRegister : INinjectRegistry
    {
        public void Register(IKernel kernel)
        {
            kernel.Bind<ITennisLinksDbContext>().To<TennisLinksDbContext>().InRequestScope();
            kernel.Bind(typeof(IRepository<>)).To(typeof(EfRepository<>));
            kernel.Bind<ITennisLinksData>().To<TennisLinksData>();
        }
    }
}
