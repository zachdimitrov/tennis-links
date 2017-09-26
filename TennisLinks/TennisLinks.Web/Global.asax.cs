using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TennisLinks.Data;
using TennisLinks.Data.Migrations;
using TennisLinks.Web.App_Start;
using TennisLinks.Web.Infrastructure.ModelBinders;

namespace TennisLinks.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TennisLinksDbContext, Configuration>());

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AutoMapperConfig.RegisterMappings();
            ModelBinderProviders.BinderProviders.Add(new EntityModelBinderProvider());
        }
    }
}
