using System.Data.Entity.Migrations;

namespace TennisLinks.Data.Migrations
{
    public class Configuration : DbMigrationsConfiguration<TennisLinksDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            ContextKey = "TennisLinks.Data.TennisLinksDbContext";
        }

        protected override void Seed(TennisLinksDbContext context)
        {

        }
    }
}
