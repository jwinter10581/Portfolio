namespace GuildCars.UI.Migrations
{
    using GuildCars.UI.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.Owin.Security;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GuildCarsDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GuildCarsDbContext context)
        {
            // Load the user and role managers with our custom models
            var userMgr = new UserManager<AppUser>(new UserStore<AppUser>(context));
            var roleMgr = new RoleManager<AppRole>(new RoleStore<AppRole>(context));

            // have we loaded roles already?
            if (roleMgr.RoleExists("admin"))
                return;

            // create the roles
            roleMgr.Create(new AppRole() { Name = "admin" });
            roleMgr.Create(new AppRole() { Name = "sales" });
            roleMgr.Create(new AppRole() { Name = "disabled" });

            // create the default users
            var admin = new AppUser()
            {
                UserName = "admin@guildcars.com",
                Email = "admin@guildcars.com"
            };
            var sales = new AppUser()
            {
                UserName = "sales@guildcars.com",
                Email = "sales@guildcars.com"
            };
            var disabled = new AppUser()
            {
                UserName = "disabled@guildcars.com",
                Email = "disabled@guildcars.com"
            };

            // create the user with the manager class
            userMgr.Create(admin, "testing123");
            userMgr.Create(sales, "testing123");
            userMgr.Create(disabled, "testing123");

            // add the users to respective roles
            userMgr.AddToRole(admin.Id, "admin");
            userMgr.AddToRole(sales.Id, "sales");
            userMgr.AddToRole(disabled.Id, "disabled");
        }
    }
}
