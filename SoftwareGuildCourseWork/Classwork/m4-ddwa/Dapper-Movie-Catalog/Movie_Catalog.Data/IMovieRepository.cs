using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Movie_Catalog.Models;

namespace Movie_Catalog.Data
{
    public interface IMovieRepository
    {
        IEnumerable<MovieListView> GetAllMovies();

        Movie GetMovieById(int id);

        void MovieDelete(int id);

        void MovieInsert(Movie movie);

        void MovieEdit(Movie movie);

        IEnumerable<Genre> GetGenres();

        IEnumerable<Rating> GetRatings();        
    }
}


                