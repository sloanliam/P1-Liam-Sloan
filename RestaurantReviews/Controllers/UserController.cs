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
        private readonly ILogger _logger;

        public UserController(IRepository appRepo, ILogger<UserController> logger)
        {
            _logger = logger;
            _logger.LogCritical("User visited Sign-in page");
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
                _logger.LogCritical("User signed in.");
                return Redirect("~/Home/Index");
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

            if (ViewData["name"].Equals("That username already exists, please enter a new one"))
            {
                return View();
            }
            else
            {
                _logger.LogCritical("User created an account");
                return this.RedirectToAction("SignIn");
            }
        }
    }
}
