namespace EF_Code1st_Movie_Catalog.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using EF_Code1st_Movie_Catalog.Models.EF;

    internal sealed class Configuration : DbMigrationsConfiguration<EF_Code1st_Movie_Catalog.Models.EF.MovieCatalogEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EF_Code1st_Movie_Catalog.Models.EF.MovieCatalogEntities context)
        {
            //  This method will be called after migrating to the latest version.
            context.Genres.AddOrUpdate(
                g => g.GenreType,
                new Genre { GenreType = "Sci-Fi" },
                new Genre { GenreType = "Adventure" },
                new Genre { GenreType = "Mystery" },
                new Genre { GenreType = "Horror" }
            );

            context.Ratings.AddOrUpdate(
                r => r.RatingName,
                new Rating { RatingName = "G" },
                new Rating { RatingName = "PG" },
                new Rating { RatingName = "PG-13" },
                new Rating { RatingName = "R" }
            );

            context.SaveChanges();

            context.Movies.AddOrUpdate(
                m => m.Title,
                new Movie
                {
                    Title = "Star Wars",
                    GenreId = context.Genres.First(g => g.GenreType == "Sci-Fi").GenreId,
                    RatingId = context.Ratings.First(r => r.RatingName == "PG").RatingId
                }
            );
        }
    }
}
