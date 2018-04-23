using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Data.Models
{
    public class Users
    {
        public string UserID { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        [Display(Name="Favorite Movies")]
        public List<string> FavoriteMovies { get; set; }
    }
}