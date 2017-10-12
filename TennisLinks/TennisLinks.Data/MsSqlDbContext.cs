using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Data.Entity;
using System.Linq;
using TennisLinks.Models;
using TennisLinks.Models.Interfaces;

namespace TennisLinks.Data
{
    public class MsSqlDbContext : IdentityDbContext<User>, IMsSqlDbContext
    {
        public MsSqlDbContext()
            : base("TennisLinksConnection", throwIfV1Schema: false)
        {
            this.Configuration.AutoDetectChangesEnabled = false;
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
            this.Configuration.ValidateOnSaveEnabled = false;
        }

        public virtual IDbSet<Message> Messages { get; set; }

        public virtual IDbSet<Club> Clubs { get; set; }

        public virtual IDbSet<City> Cities { get; set; }

        public virtual IDbSet<PlayTime> PlayTimes { get; set; }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        /// <summary>
        /// Add changes info before saving changes
        /// </summary>
        /// <returns>SaveChanges()</returns>
        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        /// <summary>
        /// Add info to items when changed
        /// </summary>
        private void ApplyAuditInfoRules()
        {
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditable && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditable)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default(DateTime))
                {
                    entity.CreatedOn = DateTime.Now;
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }

        public static MsSqlDbContext Create()
        {
            return new MsSqlDbContext();
        }
    }
}