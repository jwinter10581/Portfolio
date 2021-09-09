using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Movie_Catalog.Models.Identity
{
    public class MovieCatalogDbContext : IdentityDbContext<AppUser>
    {
        public MovieCatalogDbContext() : base("MovieCatalog")
        {
        }
    }
}