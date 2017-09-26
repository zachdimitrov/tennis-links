using System.Web.Mvc;

namespace TennisLinks.Web.Infrastructure.Validators
{
    public interface IValidator<T>
    {
        bool Validate(T model, ControllerContext controllerContext);
    }
}
