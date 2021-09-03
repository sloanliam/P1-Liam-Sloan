using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantReviews.Models
{
    public class RegisteredUser
    {
        [Required]
        public string name { get; set; }

        [Required]
        public string username { get; set; }

        [Required]
        public string password { get; set; }

        public RegisteredUser() { }

        public RegisteredUser(string name, string username, string password)
        {
            this.name = name;
            this.username = username;
            this.password = password;
        }
    }
}
