using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestaurantReviews.Data;
using RestaurantReviews.Data.Entities;

namespace RestaurantReviews.Models
{
    public class DataAccess
    {
        AppRepo appRepo = new AppRepo();

        public void Initialize()
        {

        }

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
    }
}
