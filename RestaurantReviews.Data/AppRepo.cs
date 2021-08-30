using RestaurantReviews.Data.Entities;
using RestaurantReviews.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReviews.Data
{
    public class AppRepo
    {
        /// <summary>
        /// 
        /// </summary>

        /// <dependencies>
        /// Ef Core SqlServer
        /// Ef Core Design
        /// Ef Core Tools
        /// </dependencies>

        revtrainingdbContext context = new revtrainingdbContext();

        public string GetUsername(int userId)
        {
            var userList = context.Users.Single(u => u.Id == userId);

            return (string)userList.Username;
        }

        // This method will return true or false if the user is an admin.
        public bool IsAdmin(string username)
        {
            try
            {
                var user = context.Users.Single(u => u.Username.Equals(username));

                if (user.IsAdmin.Equals("yes"))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            } catch(System.InvalidOperationException e)
            {
                return false;
            }
        }

        public string LogIn(string username, string password)
        {
            try
            {
                var user = context.Users.Single(u => u.Username.Equals(username));

                if (user.Password != password)
                {
                    return "Not a valid login.";
                }
                else if (user.Password == password)
                {
                    return username;
                }
                else
                {
                    return "Something went wrong...";
                }
            } catch (System.InvalidOperationException e)
            {
                return "Not a valid login.";
            }
        }

        public string RegisterAccount(string name, string username, string password)
        {

            string resultUsername;
            try
            {
                var user = context.Users.Single(u => u.Username.Equals(username));
                resultUsername = user.Username;
            } catch(System.InvalidOperationException e)
            {
                resultUsername = "none";
            }

            if (resultUsername.Equals(username))
            {
                return "That username already exists, please enter a new one";
            } else
            {
                context.Add(new Entities.User
                {
                    Name = name,
                    Username = username,
                    Password = password
                }) ;

                context.SaveChanges();

                return "Profile Created.";
            }
        }

        public string GetRestaurantById(int id)
        {
            var restaurant = context.Restaurants.Single(r => r.Id == id);

            return $"{restaurant.Name}";
        }

        public List<int> GetRestaurantIds(string name)
        {
            List<int> ids = new List<int>();
            var restaurantList = context.Restaurants.Where(r => r.Name.Equals(name));
            foreach(var id in restaurantList)
            {
                ids.Add(id.Id);
            }

            return ids;
        }

        // submit a review
        public void CreateAReview(string restaurant, int zipcode)
        {
            
        }

        public List<Models.Restaurant> ListRestaurants()
        {
            return context.Restaurants.Select(r => new Models.Restaurant(r.Id, r.Name, r.Zipcode)).ToList();
        }

        public List<string> FindRestaurant(string name)
        {
            var restaurants = context.Restaurants.Where(r => r.Name.Equals(name)).ToList();

            List<string> restaurantList = new List<string>();

            foreach(var restaurant in restaurants)
            {
                restaurantList.Add($"{restaurant.Name} located at {restaurant.Zipcode}");
            }

            return restaurantList;
        }

        public List<Models.Review> GetReviews(string name, int zipcode)
        {
            var restaurant = context.Restaurants.Single(r => r.Name.Equals(name) && r.Zipcode == zipcode);

            var reviews = context.Reviews.Where(r => r.RestaurantId == restaurant.Id).ToList();

            List<Models.Review> result = new List<Models.Review>();

            foreach(var review in reviews)
            {
                result.Add(new Models.Review(review.Review1, review.Stars));
            }

            return result;
        }

        //get the average rating for a restaurant
        public int GetStarRating(string name, int zipcode)
        {
            var restaurant = context.Restaurants.Single(r => r.Name.Equals(name) && r.Zipcode == zipcode);

            var reviews = context.Reviews.Where(r => r.RestaurantId == restaurant.Id).ToList();

            int? result = 0;

            foreach(var rating in reviews)
            {
                result += rating.Stars;
            }

            return (int)(int?)result;
        }
    }
}
