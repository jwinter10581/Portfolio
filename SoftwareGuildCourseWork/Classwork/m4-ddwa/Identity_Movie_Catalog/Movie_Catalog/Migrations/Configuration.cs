namespace Movie_Catalog.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Movie_Catalog.Models.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity;

    internal sealed class Configuration : DbMigrationsConfiguration<Movie_Catalog.Models.Identity.MovieCatalogDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Movie_Catalog.Models.Identity.MovieCatalogDbContext context)
        {
            // Load the user and role managers with our custom models
            UserManager<AppUser> userMgr = new UserManager<AppUser>(new UserStore<AppUser>(context));
            RoleManager<AppRole> roleMgr = new RoleManager<AppRole>(new RoleStore<AppRole>(context));

            // only create if the admin role does not exist
            if (!roleMgr.RoleExists("admin"))
            {
                // create the admin role
                roleMgr.Create(new AppRole() { Name = "admin" });

                // create the default user
                AppUser user = new AppUser()
                {
                    UserName = "admin"
                };

                // create the user with the manager class
                userMgr.Create(user, "testing123");

                // add the user to the admin role
                userMgr.AddToRole(user.Id, "admin");
            }
        }
    }
}
