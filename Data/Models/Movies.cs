using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Data.Models
{
    public class Movies
    {
        public int MovieID { get; set; }
        public string Title { get; set;}
        public string Description { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }
        public string Cast { get; set; }
        public string Picture { get; set; }
    }
}