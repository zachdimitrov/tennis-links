namespace TennisLinks.Data.Migrations
{
    using Interfaces;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using Models.Enumerations;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<MsSqlDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MsSqlDbContext context)
        {
            const string AdministratorUserName = "admin";
            const string AdministratorEmail = "info@tennislinks.win";
            const string AdministratorPassword = "123qwe";
            const string CityName = "Sofia";
            const string ClubName = "Akademik";

            this.CreatePlayTimes(context);
            this.SampleCity(context, CityName);
            this.SampleClub(context, ClubName);
            this.SeedAdmin(
                context, 
                AdministratorUserName,
                AdministratorEmail,
                AdministratorPassword, 
                CityName);
        }

        private void CreatePlayTimes(IMsSqlDbContext context)
        {
            if (!context.PlayTimes.Any())
            {
                context.PlayTimes.Add(new PlayTime(TimeOfDay.morning, DateTime.Now));
                context.PlayTimes.Add(new PlayTime(TimeOfDay.lunch, DateTime.Now));
                context.PlayTimes.Add(new PlayTime(TimeOfDay.afternoon, DateTime.Now));
                context.PlayTimes.Add(new PlayTime(TimeOfDay.evening, DateTime.Now));
                context.PlayTimes.Add(new PlayTime(TimeOfDay.night, DateTime.Now));
            }

            context.SaveChanges();
        }

        private void SampleCity(IMsSqlDbContext context, string CityName)
        {
            if (!context.Cities.Any())
            {
                var city = new City()
                {
                    Name = CityName,
                    CreatedOn = DateTime.Now
                };

                context.Cities.Add(city);
                context.SaveChanges();
            }
        }

        private void SampleClub(IMsSqlDbContext context, string ClubName)
        {
            if (!context.Clubs.Any())
            {
                var club = new Club()
                {
                    Name = ClubName,
                    SurfaceType = Surface.Clay,
                    City = context.Cities.First(),
                    CreatedOn = DateTime.Now
                };

                context.Clubs.Add(club);
                context.SaveChanges();
            }
        }

        private void SeedAdmin(MsSqlDbContext context, 
            string AdministratorUserName, 
            string AdministratorEmail,
            string AdministratorPassword, 
            string CityName)
        {

            if (!context.Roles.Any())
            {
                // create roles for all other users here 
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var adminRole = new IdentityRole { Name = "Admin" };
                var regularRole = new IdentityRole { Name = "Regular" };
                roleManager.Create(adminRole);
                roleManager.Create(regularRole);

                var userStore = new UserStore<User>(context);
                var userManager = new UserManager<User>(userStore);
                var user = new User
                {
                    UserName = AdministratorUserName,
                    Email = AdministratorEmail,
                    EmailConfirmed = true,
                    City = context.Cities.First(),
                    Age = 35,
                    Gender = Gender.Male,
                    Skill = 2.5,
                    Info = "Tennis Links app administrator. If you have any troubles or requests do not hesitate to contact me!",
                    CreatedOn = DateTime.Now
                };

                user.Clubs.Add(context.Clubs.First());
                user.PlayTimes.Add(context.PlayTimes.First(p => p.Time == TimeOfDay.morning));
                user.PlayTimes.Add(context.PlayTimes.First(p => p.Time == TimeOfDay.evening));

                userManager.Create(user, AdministratorPassword);
                userManager.AddToRole(user.Id, adminRole.Name);

                context.SaveChanges();
            }
        }
    }
}
