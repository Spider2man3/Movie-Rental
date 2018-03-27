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
        public List<SelectListItem> DropDownList { get; set; }
    }
}