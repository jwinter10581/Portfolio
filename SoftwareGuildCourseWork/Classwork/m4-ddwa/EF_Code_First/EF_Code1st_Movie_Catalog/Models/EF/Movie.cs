using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EF_Code1st_Movie_Catalog.Models.EF
{
    public class Movie
    {
        public int MovieId { get; set; }
        public int GenreId { get; set; }
        public int? RatingId { get; set; }
        public string Title { get; set; }

        public virtual Genre Genre { get; set; }
        public virtual Rating Rating { get; set; }
    }
}