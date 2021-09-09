using System.Web.Http;
using CreateWebApi.Models;
using CreateWebApi.Models;

namespace CreateWebApi.Controllers
{
    public class MovieController : ApiController
    {
        [Route("movies/all")]
        [AcceptVerbs("GET")]
        public IHttpActionResult All()
        {
            return Ok(MovieRepository.GetAll());
        }

/*        [Route("movies/get/")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Get(int movieId)
        {
            Movie movie = MovieRepository.Get(movieId);

            if (movie == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(movie);
            }
        }*/

        [Route("movies/get/{movieId}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Get(int movieId)
        {
            Movie movie = MovieRepository.Get(movieId);

            if (movie == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(movie);
            }
        }

        [Route("movies/add")]
        [AcceptVerbs("POST")]
        public IHttpActionResult Add(AddMovieRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Movie movie = new Movie()
            {
                Title = request.Title,
                Rating = request.Rating
            };

            MovieRepository.Add(movie);
            return Created($"movies/get/{movie.MovieId}", movie);
        }

        [Route("movies/update")]
        [AcceptVerbs("PUT")]
        public IHttpActionResult Update(UpdateMovieRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Movie movie = MovieRepository.Get(request.MovieId);

            if (movie == null)
            {
                return NotFound();
            }

            movie.Title = request.Title;
            movie.Rating = request.Rating;

            MovieRepository.Edit(movie);
            return Ok(movie);
        }

        [Route("movies/delete")]
        [AcceptVerbs("DELETE")]
        public IHttpActionResult Delete(int movieId)
        {
            Movie movie = MovieRepository.Get(movieId);

            if (movie == null)
            {
                return NotFound();
            }

            MovieRepository.Delete(movieId);
            return Ok();
        }
    }
}