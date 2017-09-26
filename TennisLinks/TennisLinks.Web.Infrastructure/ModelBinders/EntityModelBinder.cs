using System.Web.Mvc;
using TennisLinks.Data.Interfaces;
using TennisLinks.Models.Interfaces;

namespace TennisLinks.Web.Infrastructure.ModelBinders
{
    public class EntityModelBinder<TEntity> : IModelBinder
        where TEntity : class, IEntity
    {
        private readonly IRepository<TEntity> repository;

        public EntityModelBinder(IRepository<TEntity> repo)
        {
            this.repository = repo;
        }

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var value = bindingContext.ValueProvider.GetValue("id");
            var id = int.Parse(value.AttemptedValue as string);
            var entity = this.repository.GetById(id);
            return entity;
        }
    }
}
