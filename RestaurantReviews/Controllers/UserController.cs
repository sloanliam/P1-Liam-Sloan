using Microsoft.AspNetCore.Mvc;
using RestaurantReviews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantReviews.Controllers
{
    public class UserController : Controller
    {
        // variable to identify is user is logged in.
        bool loggedIn = false;
        string username;

        DataAccess access = new DataAccess();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SignIn()
        {
            if (!loggedIn)
            {
                return View();
            } else
            {

            }
            return View("Index");
        }

        [HttpPost]
        public IActionResult SignIn(string username, string password)
        {
            if(access.LogIn(username, password).Equals("Not a valid login.")){
                return View("Error");
            } else
            {
                ViewBag.Username = username;
                return View("LoggedIn");
            }
        }
    }
}
