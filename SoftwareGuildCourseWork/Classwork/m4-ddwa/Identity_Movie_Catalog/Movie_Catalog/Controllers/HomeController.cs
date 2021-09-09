using Movie_Catalog.Data;
using Movie_Catalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Owin;
using Movie_Catalog.Models.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;

namespace Movie_Catalog.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            MovieRepository repository = new MovieRepository();
            IEnumerable<MovieListView> model = repository.GetAllMovies();

            return View(model);
        }

        [Authorize(Roles = "admin")]
        public ActionResult AddMovie()
        {
            MovieRepository repository = new MovieRepository();
            AddMovieViewModel model = new AddMovieViewModel();

            model.Genres = from g in repository.GetGenres()
                           select new SelectListItem { Text = g.GenreType, Value = g.GenreId.ToString() };

            model.Ratings = from r in repository.GetRatings()
                           select new SelectListItem { Text = r.RatingName, Value = r.RatingId.ToString() };

            return View(model);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public ActionResult AddMovie(AddMovieViewModel model)
        {
            MovieRepository repository = new MovieRepository();

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
            MovieRepository repository = new MovieRepository();
            Movie movie = repository.GetMovieById(id);

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
            MovieRepository repository = new MovieRepository();

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
            MovieRepository repository = new MovieRepository();
            repository.MovieDelete(id);

            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            LoginViewModel model = new LoginViewModel();

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userManager = HttpContext.GetOwinContext().GetUserManager<UserManager<AppUser>>();
            var authManager = HttpContext.GetOwinContext().Authentication;

            // attempt to load the user with this password
            AppUser user = userManager.Find(model.UserName, model.Password);

            // user will be null if the password or user name is bad
            if (user == null)
            {
                ModelState.AddModelError("", "Invalid username or password");

                return View(model);
            }
            else
            {
                // successful login, set up their cookies and send them on their way
                var identity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authManager.SignIn(new AuthenticationProperties { IsPersistent = model.RememberMe }, identity);

                if (!string.IsNullOrEmpty(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }
        }
    }
}