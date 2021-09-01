using Microsoft.AspNetCore.Mvc;
using RestaurantReviews.Data;
using RestaurantReviews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantReviews.Controllers
{
    public class UserController : Controller
    {

        private IRepository _appRepo;

        public UserController(IRepository appRepo)
        {
            _appRepo = appRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(SignedInUser user)
        {

            if (!ModelState.IsValid)
            {
                return View(user);
            }

            if(_appRepo.LogIn(user.username, user.password).Equals("Not a valid login.")){
                return View("Error");
            } else
            {
                ViewBag.Username = user.username;
                TempData["user"] = user.username;
                TempData.Keep("user");
                return View("LoggedIn");
            }
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisteredUser user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            ViewData["name"] = _appRepo.RegisterAccount(user.name, user.username, user.password);
            return View();
        }
    }
}
