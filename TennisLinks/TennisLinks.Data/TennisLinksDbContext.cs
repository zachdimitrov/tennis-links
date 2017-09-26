using System.Data.Entity;
using TennisLinks.Data.Interfaces;
using TennisLinks.Models;

namespace TennisLinks.Data
{
    public class TennisLinksDbContext : DbContext, ITennisLinksDbContext
    {
        public TennisLinksDbContext()
            : base("TennisLinksConnection")
        {
            this.Configuration.AutoDetectChangesEnabled = false;
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
            this.Configuration.ValidateOnSaveEnabled = false;
        }

        public virtual IDbSet<Message> Messages { get; set; }

        public virtual IDbSet<User> Users { get; set; }

        public virtual IDbSet<Club> Clubs { get; set; }

        public virtual IDbSet<City> Cities { get; set; }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}