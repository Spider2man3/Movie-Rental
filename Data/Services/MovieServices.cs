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
            var query = @"Select * From Movie";
            return _context.Query<Movies>(query).AsList();
        }
        public List<SelectListItem> MoviesDropDownList()
        {
            var query = @"Select * From Movie";
            List<SelectListItem> list = new List<SelectListItem>();
            list = _context.Query<Movies>(query).Select(x => new SelectListItem
            {
                Value = x.Title,
                Text = x.Description
            }).AsList();
            return list;
        }
        public List<string> GetGenreAll()
        {
            var query = @"Select Genre 
                          From Movie
                          Where Year > 2010 and Description is not null and Genre is not null and Year is not null and Director is not null and Cast is not null
                          Intersect
                          Select Genre
                          From Genres";
            return _context.Query<string>(query).AsList();
        }
        public List<string> MoviesInGenre(string genre)
        {
            var query = @"  Select Title 
                            From Movie
                            Where Year > 2010 and Description is not null and Genre is not null
                            and Year is not null and Director is not null and Cast is not null
                            and Movie.Genre = @Genre";
            return _context.Query<string>(query, new { Genre = genre }).AsList();         
           
        }

        public List<Movies> GetMoviesThatMatch(string search)
        {

            var query = @"Select * From Movie WHERE Title LIKE '%" + search + "%' and Description is not null and Genre is not null and Year is not null and Director is not null and Cast is not null ";
            var film = _context.Query<Movies>(query).AsList();
            foreach(var item in film)
            {
                item.Picture = item.Title + ".jpg";
            }

            return film;
        }

        public Movies UrlToMovie(string movie)
        {
            var query = @"Select * 
                        From Movie
                        Where Movie.Title = @Movie";
            var film = _context.Query<Movies>(query, new { Movie = movie }).FirstOrDefault();
            film.Picture = film.Title + ".jpg";
            return film;

        }
    }
}