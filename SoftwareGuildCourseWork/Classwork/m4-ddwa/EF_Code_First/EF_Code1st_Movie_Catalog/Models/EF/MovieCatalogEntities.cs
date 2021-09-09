using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace EF_Code1st_Movie_Catalog.Models.EF
{
    public class MovieCatalogEntities : DbContext
    {
        public MovieCatalogEntities() : base("MovieCatalog")
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Rating> Ratings { get; set; }
    }
}