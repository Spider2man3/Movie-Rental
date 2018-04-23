using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieRental.Models
{
    public class MovieModel
    {
        public List<Movies> Movies { get; set; }
        public bool LoggedIn { get; set; }
        public Movies Movie { get; set; }
        public List<string> Genres { get; set; }
        public List<string> MoviesInEachGenre { get; set; }
        public string Genre { get; set; }
    }
}