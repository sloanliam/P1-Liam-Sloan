using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReviews.Data.Models
{
    public class Restaurant
    {
        public Restaurant()
        {
            Reviews = new HashSet<Review>();
        }

        public Restaurant(int id, string name, int zipcode)
        {
            this.Id = id;
            this.Name = name;
            this.Zipcode = zipcode;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Zipcode { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }
    }
}
