using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Web.Common;
using TennisLinks.Services.Interfaces;

namespace TennisLinks.Web.Infrastructure.Registries
{
    public class ServiceBindingsRegister : INinjectRegistry
    {
        public void Register(IKernel kernel)
        {
            kernel.Bind(k => k.FromAssemblyContaining<IService>()
                .SelectAllClasses()
                .BindAllInterfaces()
                .Configure(b => b.InRequestScope()));
        }
    }
}
