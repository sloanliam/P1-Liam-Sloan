using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestaurantReviews.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantReviews.Controllers
{
    public class AdminController : Controller
    {
        private IRepository _appRepo;
        private readonly ILogger<AdminController> _logger;

        public AdminController(IRepository appRepo, ILogger<AdminController> logger)
        {
            _appRepo = appRepo;
            _logger = logger;
            _logger.LogCritical("admin page visited");
        }

        public IActionResult Index()
        {
            List<Data.Models.User> user = _appRepo.ListAllUsers();
            return View(user);
        }

        public IActionResult GetUserInformation(string username)
        {
            try
            {
                Data.Models.User foundUser = _appRepo.GetUserInformation(username);

                ViewData["nameInfo"] = foundUser.Name;
                ViewData["usernameInfo"] = foundUser.Username;
                ViewData["passwordInfo"] = foundUser.Password;
            }
            catch (System.InvalidOperationException)
            {
                ViewData["adminError"] = "Not a user.";
            }

            List<Data.Models.User> user = _appRepo.ListAllUsers();

            return View("Index", user);
        }
    }
}
