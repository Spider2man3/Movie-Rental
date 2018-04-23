using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Data.Models;

namespace Data.Services
{
    public class AccountServices
    {
        private readonly SqlConnection _context = new SqlConnection(ConfigurationManager.ConnectionStrings["Movies"].ToString());
        public void RegisterAccount(string Email,string Password)
        {
            _context.Query<string>(@"Insert into Users
                                     Values(@Email,@Password)",new { Email = Email, Password=Password});
        }

        public string GetUserName(string user)
        {
            var query = @"Select Email From Users Where UserID = @User";
            return _context.Query<string>(query, new { User = user}).FirstOrDefault();
        }

        public Users GetUserDetails(string user)
        {
            var query = @"Select UserID,Email,Name From Users Where Email = @User";
            var PersonItems = _context.Query<Users>(query, new { User = user }).FirstOrDefault();
            query = @"Select Title From Users,Favorites,Movie Where Users.email = @User and Users.UserID = Favorites.UserID and Favorites.MovieID = Movie.MovieID";
            var PersonFavorites = _context.Query<string>(query, new { User = user }).ToList();
            var person = new Users
            {
                UserID = PersonItems.UserID,
                Email = PersonItems.Email,
                Name = PersonItems.Name,
                FavoriteMovies = PersonFavorites
            };
            return person;
        }

        public void EditAccount(string name, string email,string user)
        {
            var query = @"Update Users
                          Set Name = @Name,Email = @Email
                          Where Email = @User";
            _context.Execute(query, new { Name = name, Email = email, User = user });
        }

        public bool Login(string email, string password)
        {
            var query = @"Select * From Users Where Email = @User and Password = @Password";
            return _context.Query<Users>(query, new { User = email,Password = password }).FirstOrDefault() != null ? true : false;
        }
    }
}