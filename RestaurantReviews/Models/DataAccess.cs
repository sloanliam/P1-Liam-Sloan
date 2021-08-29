using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestaurantReviews.Data;
using RestaurantReviews.Data.Models;
using RestaurantReviews.Data.Entities;

namespace RestaurantReviews.Models
{
    public class DataAccess
    {
        AppRepo appRepo = new AppRepo();

        public string GetUsername(int userId)
        {
            return appRepo.GetUsername(userId);
        }

        public bool isAdmin(string username)
        {
            return appRepo.IsAdmin(username);
        }

        public string LogIn(string username, string password)
        {
            return appRepo.LogIn(username, password);
        }

        public string RegisterAccount(string name, string username, string password)
        {
            return appRepo.RegisterAccount(name, username, password);
        }

        public string GetRestaurantById(int id)
        {
            return appRepo.GetRestaurantById(id);
        }

        public List<Data.Models.Restaurant> ListRestaurants()
        {
            return appRepo.ListRestaurants();
        }

        public List<string> FindRestaurant(string name)
        {
            return appRepo.FindRestaurant(name);
        }

        
    }
}
