using System;
using Xunit;
using RestaurantReviews.Data;
using RestaurantReviews.Data.Entities;

namespace RestaurantReviews.Testing
{
    public class UnitTest1
    {
        [Fact]
        public void FindRestaurant()
        {
            AppRepo appRepo = new AppRepo();

            string expectedResult = "test";

            var result = appRepo.FindRestaurant("mcdonalds");

            Assert.Equal(expectedResult, result[0]);
            
        }
    }
}
