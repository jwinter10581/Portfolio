using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CreateWebApi
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public string Rating { get; set; }
    }

    public class MovieRepository
    {
        private static List<Movie> _movies = new List<Movie>
    {
        new Movie
            { MovieId=1, Title="Ghostbusters", Rating="PG-13" },
        new Movie
            { MovieId=2, Title="Finding Nemo", Rating="G" },
        new Movie
            { MovieId=3, Title="Rocky", Rating="PG-13" }
    };

        public static List<Movie> GetAll()
        {
            return _movies;
        }

        public static Movie Get(int movieId)
        {
            return _movies.FirstOrDefault(m => m.MovieId == movieId);
        }

        public static void Add(Movie movie)
        {
            movie.MovieId = _movies.Max(m => m.MovieId) + 1;
            _movies.Add(movie);
        }

        public static void Edit(Movie movie)
        {
            var found = _movies.FirstOrDefault(m => m.MovieId == movie.MovieId);

            if (found != null)
                found = movie;
        }

        public static void Delete(int movieID)
        {
            _movies.RemoveAll(m => m.MovieId == movieID);
        }
    }
}