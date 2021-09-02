using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<UserController> _logger;

        public UserController(IRepository appRepo, ILogger<UserController> logger)
        {
            _logger = logger;
            logger.LogCritical("user page visited");
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
            TempData.Remove("isAdmin");
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            if(_appRepo.LogIn(user.username, user.password).Equals("Not a valid login.")){
                return View("Error");
            } else
            {
                if (_appRepo.IsAdmin(user.username))
                {
                    TempData["isAdmin"] = "true";
                }
                ViewBag.Username = user.username;
                TempData["user"] = user.username;
                TempData.Keep("user");
                _logger.LogCritical("user signed in.");
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
            _logger.LogCritical("user created an account.");
            return View();
        }
    }
}
