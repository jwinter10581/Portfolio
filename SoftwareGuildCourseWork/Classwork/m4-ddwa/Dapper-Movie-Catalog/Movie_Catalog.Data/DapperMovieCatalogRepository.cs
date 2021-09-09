using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Movie_Catalog.Models;

namespace Movie_Catalog.Data
{
    public class DapperMovieCatalogRepository : IMovieRepository
    {
        private string _connectionString = ConfigurationManager.ConnectionStrings["MovieCatalog"].ConnectionString;

        public IEnumerable<MovieListView> GetAllMovies()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = _connectionString;

                return conn.Query<MovieListView>("MovieSelectAll", commandType: CommandType.StoredProcedure);
            }
        }

        public Movie GetMovieById(int id)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = _connectionString;

                // create parameter object
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@MovieId", id);

                return conn.Query<Movie>("MovieSelectById", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public void MovieDelete(int id)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = _connectionString;

                // create parameter object
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@MovieId", id);

                conn.Execute("MovieDelete", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void MovieInsert(Movie movie)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = _connectionString;

                // create parameter object
                DynamicParameters parameters = new DynamicParameters();

                // declare output parameter
                parameters.Add("@MovieId", dbType: DbType.Int32, direction: ParameterDirection.Output);
                parameters.Add("@Title", movie.Title);
                parameters.Add("@GenreId", movie.GenreId);
                parameters.Add("@RatingId", movie.RatingId);

                conn.Execute("MovieInsert", parameters, commandType: CommandType.StoredProcedure);

                movie.MovieId = parameters.Get<int>("@MovieId");
            }
        }

        public void MovieEdit(Movie movie)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = _connectionString;

                // create parameter object
                DynamicParameters parameters = new DynamicParameters();

                // declare output parameter
                parameters.Add("@MovieId", movie.MovieId);
                parameters.Add("@Title", movie.Title);
                parameters.Add("@GenreId", movie.GenreId);
                parameters.Add("@RatingId", movie.RatingId);

                conn.Execute("MovieUpdate", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<Genre> GetGenres()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = _connectionString;

                return conn.Query<Genre>("GenreSelectAll", commandType: CommandType.StoredProcedure);
            }
        }

        public IEnumerable<Rating> GetRatings()
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = _connectionString;

                return conn.Query<Rating>("RatingSelectAll", commandType: CommandType.StoredProcedure);
            }
        }
    }
}