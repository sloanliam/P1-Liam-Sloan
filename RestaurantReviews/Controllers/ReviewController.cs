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
    public class ReviewController : Controller
    {
        private IRepository _appRepo;
        private readonly ILogger _logger;

        public ReviewController(IRepository appRepo, ILogger<ReviewController> logger)
        {
            _logger = logger;
            _appRepo = appRepo;
            _logger.LogCritical("Reviews page was visited");
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LeaveReview(CreatedReview createdReview)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", createdReview);
            }
                
            string user = "Temporary";
            if (TempData["user"] != null)
            {
                user = TempData["user"].ToString();
                var newReview = new CreatedReview
                {
                    Zipcode = createdReview.Zipcode,
                    Restaurant = createdReview.Restaurant,
                    Review1 = createdReview.Review1,
                    Stars = createdReview.Stars
                };
                _appRepo.WriteReview(user, newReview.Restaurant, newReview.Zipcode, newReview.Review1, newReview.Stars);
                _logger.LogCritical("A user created a review");
            } else {
                ViewData["error"] = "You must log in to create a review.";
            }
            TempData.Keep("user");
            return Redirect("~/Home");
        }
    }
}
