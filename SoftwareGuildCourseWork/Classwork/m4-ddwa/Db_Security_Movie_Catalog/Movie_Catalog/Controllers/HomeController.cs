using Movie_Catalog.Data;
using Movie_Catalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Movie_Catalog.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var repository = new MovieRepository();
            var model = repository.GetAllMovies();

            return View(model);
        }

        public ActionResult AddMovie()
        {
            var repository = new MovieRepository();
            AddMovieViewModel model = new AddMovieViewModel();

            model.Genres = from g in repository.GetGenres()
                           select new SelectListItem { Text = g.GenreType, Value = g.GenreId.ToString() };

            model.Ratings = from r in repository.GetRatings()
                           select new SelectListItem { Text = r.RatingName, Value = r.RatingId.ToString() };

            return View(model);
        }

        [HttpPost]
        public ActionResult AddMovie(AddMovieViewModel model)
        {
            var repository = new MovieRepository();

            if (ModelState.IsValid)
            {
                Movie movie = new Movie();
                movie.Title = model.Title;
                movie.RatingId = model.SelectedRatingId;
                movie.GenreId = model.SelectedGenreId;

                repository.MovieInsert(movie);
                return RedirectToAction("EditMovie", new { id = movie.MovieId });
            }

            // validation failed, return them to the view
            model.Genres = from g in repository.GetGenres()
                           select new SelectListItem { Text = g.GenreType, Value = g.GenreId.ToString() };

            model.Ratings = from r in repository.GetRatings()
                            select new SelectListItem { Text = r.RatingName, Value = r.RatingId.ToString() };
            return View(model);
        }

        public ActionResult EditMovie(int id)
        {
            var repository = new MovieRepository();
            var movie = repository.GetMovieById(id);

            // if movie doesn't exist go home
            if(movie == null)
            {
                return RedirectToAction("Index");
            }

            EditMovieViewModel model = new EditMovieViewModel();
            model.MovieId = movie.MovieId;
            model.Title = movie.Title;
            model.SelectedGenreId = movie.GenreId;
            model.SelectedRatingId = movie.RatingId;

            model.Genres = from g in repository.GetGenres()
                           select new SelectListItem { Text = g.GenreType, Value = g.GenreId.ToString() };

            model.Ratings = from r in repository.GetRatings()
                            select new SelectListItem { Text = r.RatingName, Value = r.RatingId.ToString() };

            return View(model);
        }

        [HttpPost]
        public ActionResult EditMovie(EditMovieViewModel model)
        {
            var repository = new MovieRepository();

            if (ModelState.IsValid)
            {
                Movie movie = new Movie();
                movie.MovieId = model.MovieId;
                movie.Title = model.Title;
                movie.RatingId = model.SelectedRatingId;
                movie.GenreId = model.SelectedGenreId;

                repository.MovieEdit(movie);
                return RedirectToAction("Index");
            }

            // validation failed, return them to the view
            model.Genres = from g in repository.GetGenres()
                           select new SelectListItem { Text = g.GenreType, Value = g.GenreId.ToString() };

            model.Ratings = from r in repository.GetRatings()
                            select new SelectListItem { Text = r.RatingName, Value = r.RatingId.ToString() };

            return View(model);
        }

        [HttpPost]
        public ActionResult DeleteMovie(int id)
        {
            var repository = new MovieRepository();
            repository.MovieDelete(id);

            return RedirectToAction("Index");
        }
    }
}