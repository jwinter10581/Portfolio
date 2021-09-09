using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EF_Code1st_Movie_Catalog.Models
{
    public class MovieListView
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string GenreType { get; set; }
        public string RatingName { get; set; }
    }
}