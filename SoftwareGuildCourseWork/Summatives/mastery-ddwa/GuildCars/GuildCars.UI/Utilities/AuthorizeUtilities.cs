using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using GuildCars.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.UI.Utilities
{
    public class AuthorizeUtilities
    {
        public static string GetUserId(Controller controller)
        {
            var userMgr = new UserManager<AppUser>(new UserStore<AppUser>(new GuildCarsDbContext()));
            var user = userMgr.FindByName(controller.User.Identity.Name);
            return user.Id;
        }

        public static string GetEmail(Controller controller)
        {
            var userMgr = new UserManager<AppUser>(new UserStore<AppUser>(new GuildCarsDbContext()));
            var user = userMgr.FindByName(controller.User.Identity.Name);
            return user.Email;
        }
    }
}