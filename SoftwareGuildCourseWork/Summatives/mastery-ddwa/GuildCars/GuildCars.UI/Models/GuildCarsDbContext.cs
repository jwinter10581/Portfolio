using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars.UI.Models
{
    public class GuildCarsDbContext : IdentityDbContext<AppUser>
    {
        public GuildCarsDbContext() : base("DefaultConnection")
        {
        }
    }
}