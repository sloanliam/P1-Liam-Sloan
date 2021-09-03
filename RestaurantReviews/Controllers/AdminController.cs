using Microsoft.AspNetCore.Mvc;
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

        public AdminController(IRepository appRepo)
        {
            _appRepo = appRepo;
        }

        public IActionResult Index()
        {
            List<Data.Models.User> user = _appRepo.ListAllUsers();
            return View(user);
        }
    }
}
