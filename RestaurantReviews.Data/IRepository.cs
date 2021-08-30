using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReviews.Data
{
    public interface IRepository
    {
        public string GetUsername(int userId);

        public bool IsAdmin(string username);

        public string LogIn(string username, string password);

        public string RegisterAccount(string name, string username, string password);

        public string GetRestaurantById(int id);

        public List<int> GetRestaurantIds(string name);

        public List<Models.Restaurant> ListRestaurants();

        public List<string> FindRestaurant(string name);

        public List<Models.Review> GetReviews(string name, int zipcode);

        public int GetStarRating(string name, int zipcode);

    }
}
