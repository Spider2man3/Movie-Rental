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
        // GET: Movie
        [Route("")]
        public ActionResult Index()
        {
            var model = new MovieModel
            {
                Movies = _movie.GetMovies(),
                DropDownList = _movie.MoviesDropDownList()               
            };
            return View(model);
        }
        public ActionResult About()
        {
            return View();
        }
    }
}