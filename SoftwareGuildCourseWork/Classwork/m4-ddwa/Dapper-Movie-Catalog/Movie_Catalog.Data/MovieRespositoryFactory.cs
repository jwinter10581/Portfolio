using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movie_Catalog.Data
{
    public static class MovieRespositoryFactory
    {
        public static IMovieRepository GetMovieRepository()
        {
            IMovieRepository repo = null;

            switch (ConfigurationManager.AppSettings["MovieRepository"])
            {
                case null:
                    throw new NotImplementedException("No repository is specified.");

                default:
                    throw new NotImplementedException("Configured repository does not exist.");

                case "Dapper":
                    repo = new DapperMovieCatalogRepository();
                    break;

                case "EF_DatabaseFirst":
                    // repo = new EFDatabaseFirstMovieCatalogRepo();
                    break;

                case "EF_CodeFirst":
                    // repo = new EFCodeFirstMovieCatalogRepo();
                    break;
            }

            return repo;
        }
    }
}
