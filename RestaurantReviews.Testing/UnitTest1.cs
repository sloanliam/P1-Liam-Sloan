using System;
using Xunit;
using RestaurantReviews.Data;
using RestaurantReviews.Data.Entities;
using RestaurantReviews;
using RestaurantReviews.Controllers;
using Microsoft.Extensions.Logging;
using RestaurantReviews.Models;
using System.Threading.Tasks;
using Moq;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantReviews.Testing
{
    public class UnitTest1
    {

        [Fact]
        public void UserRegistrationFailure()
        {
            var regUser = new RegisteredUser
            {
                name = "liam",
                username = "liam",
                password = null
            };

            var validationResults = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(regUser, new ValidationContext(regUser), validationResults, true);

            Assert.False(actual, "Expected to fail");
        }

        [Fact]
        public void AcceptedUserRegistration()
        {
            var regUser = new RegisteredUser
            {
                name = "unitTest",
                username = "unitTest",
                password = "unitTest"
            };

            var validationResults = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(regUser, new ValidationContext(regUser), validationResults, true);

            Assert.True(actual, "Expected to return true");
        }

        [Fact]
        public void DetermineThatZipcodeMustBeInRange()
        {
            CreatedReview review = new CreatedReview
            {
                Zipcode = 2,
                Restaurant = "unitTesting",
                Stars = 4,
                Review1 = "unit testing"
            };

            var validationResults = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(review, new ValidationContext(review), validationResults, true);

            Assert.False(actual, "Expected to fail");
        }

        [Fact]
        public void DetermineReviewStarsAreInRange()
        {
            CreatedReview review = new CreatedReview
            {
                Zipcode = 21212,
                Restaurant = "unitTesting",
                Stars = 6,
                Review1 = "unit testing"
            };

            var validationResults = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(review, new ValidationContext(review), validationResults, true);

            Assert.False(actual, "Expected to fail");
        }

        [Fact]
        public void ValidateUserLogInAttempt()
        {
            SignedInUser user = new SignedInUser
            {
                username = "unitTesting",
                password = "unitTesting"
            };

            var validationResults = new List<ValidationResult>();
            var actual = Validator.TryValidateObject(user, new ValidationContext(user), validationResults, true);

            Assert.True(actual, "Expected to fail");
        }

        [Fact]
        public void ProveThatUserIndexControllerIsCalled()
        {
            var logger = new Mock<ILogger<UserController>>();
            var mockRepo = new Mock<IRepository>();

            var userController = new UserController(mockRepo.Object, logger.Object);

            var result = userController.Index();

            var viewResult = Assert.IsType<ViewResult>(result);

            Assert.Equal(viewResult, result);
        }

        [Fact]
        public void ProveThatHomeIndexControllerIsCalled()
        {
            var logger = new Mock<ILogger<HomeController>>();
            var mockRepo = new Mock<IRepository>();

            var homeController = new HomeController(logger.Object, mockRepo.Object);

            var result = homeController.Index();

            var viewResult = Assert.IsType<ViewResult>(result);

            Assert.Equal(viewResult, result);
        }

        [Fact]
        public void ProveThatAdminIndexControllerIsCalled()
        {
            var logger = new Mock<ILogger<AdminController>>();
            var mockRepo = new Mock<IRepository>();

            var adminController = new AdminController(mockRepo.Object, logger.Object);

            var result = adminController.Index();

            var viewResult = Assert.IsType<ViewResult>(result);

            Assert.Equal(viewResult, result);
        }
    }
}
