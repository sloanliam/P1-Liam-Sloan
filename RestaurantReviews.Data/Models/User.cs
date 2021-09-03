using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReviews.Data.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string IsAdmin { get; set; }

        public User() { }

        public User(string username)
        {
            this.Username = username;
        }
    }
}
