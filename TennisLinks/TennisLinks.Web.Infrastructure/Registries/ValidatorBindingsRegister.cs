using Ninject;
using Ninject.Extensions.Conventions;
using TennisLinks.Web.Infrastructure.Constants;

namespace TennisLinks.Web.Infrastructure.Registries
{
    public class ValidatorBindingsRegister : INinjectRegistry
    {
        public void Register(IKernel kernel)
        {
            kernel.Bind(k => k.From(Assemblies.Validators)
                .SelectAllClasses()
                .BindSingleInterface());
        }
    }
}
