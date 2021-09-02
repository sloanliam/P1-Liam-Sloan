using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestaurantReviews.Data;
using RestaurantReviews.Data.Models;
using RestaurantReviews.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantReviews.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IRepository _appRepo;

        public HomeController(ILogger<HomeController> logger, IRepository appRepo)
        {
            _logger = logger;
            _logger.LogInformation("Controller Initialized");
            _appRepo = appRepo;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetReviews(string name, int zipcode)
        {
            List<Data.Models.Review> foundReviews = _appRepo.GetReviews(name, zipcode);
            _logger.LogInformation("user creating a review...");

            int averageReview = 0;
            int count = 0;

            if (foundReviews != null)
            {
                foreach (var review in foundReviews)
                {
                    count += 1;
                    averageReview += (int)review.Stars;
                }

                if (averageReview != 0)
                {
                    int finalAverave = averageReview / count;
                    ViewData["finalreview"] = finalAverave;
                }
            }

            return View("Index", foundReviews);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
