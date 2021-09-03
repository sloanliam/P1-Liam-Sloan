using RestaurantReviews.Data.Entities;
using RestaurantReviews.Data.Models;
using Serilog;
using Serilog.Sinks.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReviews.Data
{
    public class AppRepo : IRepository
    {
        /// <summary>
        /// 
        /// </summary>

        /// <dependencies>
        /// Ef Core SqlServer
        /// Ef Core Design
        /// Ef Core Tools
        /// </dependencies>
        /// 
        private revtrainingdbContext context;

        public AppRepo(revtrainingdbContext loadedcontext)
        {
            context = loadedcontext;
        }

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

                if(user.IsAdmin != null)
                {
                    return true;
                } else
                {
                    return false;
                }
            } catch(System.InvalidOperationException e)
            {
                return false;
            }
        }


        // Log into the app
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


        // create a new account
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

        
        //return restaurant's name from given Id
        public string GetRestaurantById(int id)
        {
            var restaurant = context.Restaurants.Single(r => r.Id == id);

            return $"{restaurant.Name}";
        }


        //return a collection of restaurant Id's
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

        
        //fetches the id of a restaurant from it's name and zipcode
        public int GetRestaurantId(string name, int zipcode)
        {
            var restaurants = context.Restaurants.Single(r => r.Name.Equals(name) && r.Zipcode == zipcode);

            int restaurantId = restaurants.Id;

            return restaurantId;
        }


        // Will return a List of restaurants
        public List<Models.Restaurant> ListRestaurants()
        {
            return context.Restaurants.Select(r => new Models.Restaurant(r.Id, r.Name, r.Zipcode)).ToList();
        }


        // find a restaurant by name (will include all from name, no specifications on zipcode)
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


        // List reviews for a restaurant
        public List<Models.Review> GetReviews(string name, int zipcode)
        {
            try
            {
                var restaurant = context.Restaurants.Single(r => r.Name.Equals(name) && r.Zipcode == zipcode);

                var reviews = context.Reviews.Where(r => r.RestaurantId == restaurant.Id).ToList();

                List<Models.Review> result = new List<Models.Review>();

                foreach (var review in reviews)
                {
                    result.Add(new Models.Review(review.Review1, review.Stars));
                }

                return result;
            }
            catch (System.InvalidOperationException e)
            {
                return null;
            }
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


        public int GetUserId(string username)
        {
            var userId = context.Users.Single(u => u.Username.Equals(username));
            int userIdResult = userId.Id;
            return userIdResult;
        }

        // Write a review
        public void WriteReview(string username, string restaurant, int zipcode, string review, int stars)
        {
            try
            {

                context.Add(new Entities.Review
                {
                    RestaurantId = GetRestaurantId(restaurant, zipcode),
                    UserId = GetUserId(username),
                    Review1 = review,
                    Stars = stars
                });
                context.SaveChanges();

            } catch (System.InvalidOperationException e)
            {
                context.Add(new Entities.Restaurant
                {
                    Name = restaurant,
                    Zipcode = zipcode
                });

                context.SaveChanges();

                context.Add(new Entities.Review
                {
                    RestaurantId = GetRestaurantId(restaurant, zipcode),
                    UserId = GetUserId(username),
                    Review1 = review,
                    Stars = stars
                });
                
                context.SaveChanges();
            }
        }

        public List<Models.User> ListAllUsers()
        {
            return context.Users.Select(u =>
            new Models.User(u.Username)).ToList();
        }
    }
}
