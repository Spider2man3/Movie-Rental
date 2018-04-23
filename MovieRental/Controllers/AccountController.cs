using Data.Services;
using MovieRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieRental.Controllers
{
    public class AccountController : Controller
    {
        private readonly AccountServices _account = new AccountServices();


        public ActionResult Index(string user)
        {
            //var person = _account.GetUserName(user);
            var model = new AccountModel()
            {
                User = _account.GetUserDetails(user),
                Logged = true
            };
            return View(model);
        }

        [HttpGet]
        public ActionResult Login(string errorMsg)
        {
            ViewBag.errorMsg = errorMsg;
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            var exists = _account.Login(email, password) == true ? true : false;
            if (exists)
            {
                return RedirectToAction("Index", new { user = email });
            }
            return View("Login", new { errorMsg = "No user found" });
        }
        [HttpPost]
        public ActionResult EditAccount(string name,string email,string user)
        {
            _account.EditAccount(name, email,user);
            return RedirectToAction("Index", new { user = user });
        }
        public ActionResult Logout(string user)
        {
            return RedirectToAction("Index", "Movie");
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel registerModel)
        {
            _account.RegisterAccount(registerModel.Email, registerModel.Password);
            return RedirectToAction("Index",new { user = registerModel.Email });
        }



   
    }
}