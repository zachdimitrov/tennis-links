using System;
using System.Web.Mvc;
using TennisLinks.Models.Interfaces;

namespace TennisLinks.Web.Infrastructure.ModelBinders
{
    public class EntityModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(Type modelType)
        {
            if (!typeof(IEntity).IsAssignableFrom(modelType))
            {
                return null;
            }

            var modelBinderType = typeof(EntityModelBinder<>).MakeGenericType(modelType);
            var modelBinder = ObjectFactory.GetInstance(modelBinderType);

            return (IModelBinder)modelBinder;
        }
    }
}
