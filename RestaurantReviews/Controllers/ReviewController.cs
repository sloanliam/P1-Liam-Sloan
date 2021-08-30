using Microsoft.AspNetCore.Mvc;
using RestaurantReviews.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantReviews.Controllers
{
    public class ReviewController : Controller
    {
        private IRepository _appRepo;

        public ReviewController(IRepository appRepo)
        {
            _appRepo = appRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LeaveReview(string name, int zipcode, string review, int stars)
        {
            string user = TempData["user"].ToString();
            _appRepo.WriteReview(user, name, zipcode, review, stars);
            return View("Index");
        }
    }
}
