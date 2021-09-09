using System.Data.Entity;
using EF_Code1st_Movie_Catalog.Models;
using EF_Code1st_Movie_Catalog.Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EF_Code1st_Movie_Catalog.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var repository = new MovieCatalogEntities();

            var model = from movie in repository.Movies
                        select new MovieListView
                        {
                            MovieId = movie.MovieId,
                            Title = movie.Title,
                            GenreType = movie.Genre.GenreType,
                            RatingName = movie.Rating.RatingName
                        };

            return View(model);
        }

        public ActionResult AddMovie()
        {
            var repository = new MovieCatalogEntities();
            AddMovieViewModel model = new AddMovieViewModel();

            model.Genres = from g in repository.Genres
                           select new SelectListItem { Text = g.GenreType, Value = g.GenreId.ToString() };

            model.Ratings = from r in repository.Ratings
                            select new SelectListItem { Text = r.RatingName, Value = r.RatingId.ToString() };

            return View(model);
        }

        [HttpPost]
        public ActionResult AddMovie(AddMovieViewModel model)
        {
            var repository = new MovieCatalogEntities();

            if (ModelState.IsValid)
            {
                Movie movie = new Movie();
                movie.Title = model.Title;
                movie.RatingId = model.SelectedRatingId;
                movie.GenreId = model.SelectedGenreId;

                repository.Movies.Add(movie);
                repository.SaveChanges();
                return RedirectToAction("EditMovie", new { id = movie.MovieId });
            }

            // validation failed, return them to the view
            model.Genres = from g in repository.Genres
                           select new SelectListItem { Text = g.GenreType, Value = g.GenreId.ToString() };

            model.Ratings = from r in repository.Ratings
                            select new SelectListItem { Text = r.RatingName, Value = r.RatingId.ToString() };
            return View(model);
        }

        public ActionResult EditMovie(int id)
        {
            var repository = new MovieCatalogEntities();
            var movie = repository.Movies.FirstOrDefault(m => m.MovieId == id);

            // if movie doesn't exist go home
            if (movie == null)
            {
                return RedirectToAction("Index");
            }

            EditMovieViewModel model = new EditMovieViewModel();
            model.MovieId = movie.MovieId;
            model.Title = movie.Title;
            model.SelectedGenreId = movie.GenreId;
            model.SelectedRatingId = movie.RatingId;

            model.Genres = from g in repository.Genres
                           select new SelectListItem { Text = g.GenreType, Value = g.GenreId.ToString() };

            model.Ratings = from r in repository.Ratings
                            select new SelectListItem { Text = r.RatingName, Value = r.RatingId.ToString() };

            return View(model);
        }

        [HttpPost]
        public ActionResult EditMovie(EditMovieViewModel model)
        {
            var repository = new MovieCatalogEntities();

            if (ModelState.IsValid)
            {
                Movie movie = new Movie();
                movie.MovieId = model.MovieId;
                movie.Title = model.Title;
                movie.RatingId = model.SelectedRatingId;
                movie.GenreId = model.SelectedGenreId;

                repository.Entry(movie).State = EntityState.Modified;
                repository.SaveChanges();
                return RedirectToAction("Index");
            }

            // validation failed, return them to the view
            model.Genres = from g in repository.Genres
                           select new SelectListItem { Text = g.GenreType, Value = g.GenreId.ToString() };

            model.Ratings = from r in repository.Ratings
                            select new SelectListItem { Text = r.RatingName, Value = r.RatingId.ToString() };

            return View(model);
        }

        [HttpPost]
        public ActionResult DeleteMovie(int id)
        {
            var repository = new MovieCatalogEntities();

            var movie = repository.Movies.FirstOrDefault(m => m.MovieId == id);

            // movie exists?
            if (movie != null)
            {
                repository.Movies.Remove(movie);
                repository.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}