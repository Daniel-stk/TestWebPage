namespace RickAndMortyRestoreStore.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RickAndMortyRestoreStore.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RickAndMortyRestoreStore.Models.ApplicationDbContext context)
        {
            if (context.Users.Any())
            {
                var userStore = new UserStore<ApplicationUser>(context);
                var userManager = new UserManager<ApplicationUser>(userStore);
                var roleStore = new RoleStore<IdentityRole>(context);
                var roleManager = new RoleManager<IdentityRole>(roleStore);

                string[] roles = { "ShopOwner", "ShopAdministrator" };
                if (!context.Roles.Any())
                {
                    foreach (var role in roles)
                    {
                        var roleToCreate = new IdentityRole(role);
                        roleManager.Create(roleToCreate);
                    }
                }
                var rick = userManager.FindByName("TheRick");
                if (rick == null)
                {
                    var newRick = new ApplicationUser()
                    {
                        UserName = "TheRick",
                        Email = "sanchez@therick.com",
                        PhoneNumber = "(614)136-7727",
                        IsEnabled = true
                    };

                    userManager.Create(newRick, "ImTheRickSanchez5103!");
                    userManager.SetLockoutEnabled(newRick.Id, false);
                    userManager.AddToRole(newRick.Id, "ShopOwner");
                    userManager.AddToRole(newRick.Id, "ShopAdministrator");

                }
            }
            
        }
    }
}
