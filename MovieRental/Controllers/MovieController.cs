using Data.Models;
using Data.Services;
using MovieRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieRental.Controllers
{
    public class MovieController : Controller
    {

        private readonly MovieServices _movie = new MovieServices();
        private readonly AccountServices _account = new AccountServices();

        // GET: Movie
        [Route("")]
        public ActionResult Index(string user)
        {
            var model = new MovieModel
            {
                Movies = _movie.GetMovies(),
                LoggedIn = user != null ? true : false,
                User = (user != null ? true : false) == true ? _account.GetUserDetails(user) : null
            };
            return View(model);
        }
        public ActionResult About(string user)
        {
            ViewBag.User = user;
            return View();
        }
        public ActionResult Genres(string user)
        {

            var model = new MovieModel
            {
                Genres = _movie.GetGenreAll(),
                LoggedIn = user != null ? true : false,
                User = (user != null ? true : false) == true ? _account.GetUserDetails(user) : null
            };
            
            return View(model);
        }
        public ActionResult AddToFavorites(string movie,string user)
        {
            _movie.AddToFavorites(movie);

        }
        public ActionResult MoviesGenre(string genre, string user)
        {
            var model = new MovieModel
            {
                MoviesInEachGenre = _movie.MoviesInGenre(genre),
                LoggedIn = user != null ? true : false,
                Genre = genre,
                User = (user != null ? true : false) == true ? _account.GetUserDetails(user) : null
            };
            return View(model);
        }
        public ActionResult Movie(string movie, string user)
        {
            var model = new MovieModel
            {
                Movie = _movie.UrlToMovie(movie),
                LoggedIn = user != null ? true : false,
                User = (user != null ? true : false) == true ? _account.GetUserDetails(user) : null
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Search(string search, string user)
        {
            var model = new MovieModel
            {
                Movies = _movie.GetMoviesThatMatch(search),
                LoggedIn = user != null ? true : false,
                User = (user != null ? true : false) == true ? _account.GetUserDetails(user) : null
            };
            return View(model);
        }
    }
}