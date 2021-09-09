using CreateWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

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

        // Original GET method
        //[Route("movies/get/")]
        //[AcceptVerbs("GET")]
        //public IHttpActionResult Get (int movieId)
        //{
        //    Movie movie = MovieRepository.Get(movieId);

        //    if (movie == null)
        //    {
        //        return NotFound();
        //    }
        //    else
        //    {
        //        return Ok(movie);
        //    }
        //}

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
            else
            {
                Movie movie = new Movie()
                {
                    Title = request.Title,
                    Rating = request.Rating
                };

                MovieRepository.Add(movie);
                return Created($"movies/get/{movie.MovieId}", movie);
            }
        }

        [Route("movies/update")]
        [AcceptVerbs("PUT")]
        public IHttpActionResult Update(UpdateMovieRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Movie movie = MovieRepository.Get(request.MovieID);

            if (movie == null)
            {
                return NotFound();
            }
            else
            {
            movie.Title = request.Title;
            movie.Rating = request.Rating;

            MovieRepository.Edit(movie);
            return Ok(movie);
            }
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
            else
            {
                MovieRepository.Delete(movieId);
                return Ok();
            }
        }
    }
}

// Information when controller was created
//// GET api/<controller>
//public IEnumerable<string> Get()
//{
//    return new string[] { "value1", "value2" };
//}

//// GET api/<controller>/5
//public string Get(int id)
//{
//    return "value";
//}

//// POST api/<controller>
//public void Post([FromBody] string value)
//{
//}

//// PUT api/<controller>/5
//public void Put(int id, [FromBody] string value)
//{
//}

//// DELETE api/<controller>/5
//public void Delete(int id)
//{
//}