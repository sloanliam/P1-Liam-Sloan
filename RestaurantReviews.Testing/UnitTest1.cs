using System;
using Xunit;
using RestaurantReviews.Data;
using RestaurantReviews.Data.Entities;

namespace RestaurantReviews.Testing
{
    public class UnitTest1
    {
        [Fact]
        public void RegisterNewUser()
        {
            AppRepo appRepo = new AppRepo();

            var registerAttempt = appRepo.Register("lim", "sloanli", "password");

            bool expectedResult = true;

            Assert.Equal(expectedResult, registerAttempt);
        }
    }
}
