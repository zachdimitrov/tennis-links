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
            const string AdministratorUserName = "info@tennislinks.win";
            const string AdministratorPassword = "123456";
            const string CityName = "Sofia";
            const string ClubName = "Akademik";

            this.SampleCity(context, CityName);
            this.SampleClub(context, ClubName);
            this.SeedAdmin(
                context, 
                AdministratorUserName, 
                AdministratorPassword, 
                CityName);
        }

        private void CreatePlayTimes(IMsSqlDbContext context)
        {
            if (!context.PlayTimes.Any())
            {
                context.PlayTimes.Add(new PlayTime(TimeOfDay.morning));
                context.PlayTimes.Add(new PlayTime(TimeOfDay.lunch));
                context.PlayTimes.Add(new PlayTime(TimeOfDay.afternoon));
                context.PlayTimes.Add(new PlayTime(TimeOfDay.evening));
                context.PlayTimes.Add(new PlayTime(TimeOfDay.night));
            }
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
            }
        }

        private void SeedAdmin(MsSqlDbContext context, 
            string AdministratorUserName, 
            string AdministratorPassword, 
            string CityName)
        {

            if (!context.Roles.Any())
            {
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);
                var role = new IdentityRole { Name = "Admin" };
                roleManager.Create(role);

                var userStore = new UserStore<User>(context);
                var userManager = new UserManager<User>(userStore);
                var user = new User
                {
                    UserName = AdministratorUserName,
                    Email = AdministratorUserName,
                    EmailConfirmed = true,
                    City = context.Cities.First(),
                    Age = 35,
                    Gender = Gender.Male,
                    Skill = 2.5,
                    Info = "Hi, I am looking for somebody to play with. I am a beginner but sometimes can be tough opponent when I have a good day."
                };

                user.Clubs.Add(context.Clubs.First());
                user.PlayTimes.Add(context.PlayTimes.First(p => p.Time == TimeOfDay.morning));
                user.PlayTimes.Add(context.PlayTimes.First(p => p.Time == TimeOfDay.evening));

                userManager.Create(user, AdministratorPassword);

                userManager.AddToRole(user.Id, "Admin");
            }
        }
    }
}
