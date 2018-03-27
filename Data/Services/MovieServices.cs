using Dapper;
using Data.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace Data.Services
{

    public class MovieServices
    {
        private readonly SqlConnection _context = new SqlConnection(ConfigurationManager.ConnectionStrings["Movies"].ToString());
        public List<Movies> GetMovies()
        {
            var query = @"Select * From Movies";
            return _context.Query<Movies>(query).AsList();
        }
        public List<SelectListItem> MoviesDropDownList()
        {
            var query = @"Select * From Movies";
            List<SelectListItem> list = new List<SelectListItem>();
            list = _context.Query<Movies>(query).Select(x => new SelectListItem
            {
                Value = x.MovieName,
                Text = x.MovieName
            }).AsList();
            return list;
        }
    }
}