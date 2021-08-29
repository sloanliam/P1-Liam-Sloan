using RestaurantReviews.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReviews.Data.Models
{
    public class Review
    {

        public Review(string review, int? stars)
        {
            this.Review1 = review;
            this.Stars = stars;
        }

        public int Id { get; set; }
        public string Review1 { get; set; }
        public int? RestaurantId { get; set; }
        public int? UserId { get; set; }
        public int? Stars { get; set; }
    }
}
