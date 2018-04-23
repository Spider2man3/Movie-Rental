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
            var person = _account.GetUserName(user);
            var model = new AccountModel()
            {
                User = _account.GetUserDetails(person)
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
        public string Login(LoginModel registerModel)
        {
            var exists = _account.Login(registerModel.Email, registerModel.Password) == true ? true : false;
            if (exists)
            {
                return _account.GetUserDetails(registerModel.Email).UserID;
            }
            return "No User Found";
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