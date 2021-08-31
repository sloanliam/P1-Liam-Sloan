using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantReviews.Models
{
    public class CreatedReview
    {
        public int Id { get; set; }

        [Required]
        public string Review1 { get; set; }

        [Required]
        public string Restaurant { get; set; }

        [Required]
        public int Zipcode { get; set; }

        [Required]
        public int Stars { get; set; }

        public CreatedReview() { }

        public CreatedReview(string name, int zipcode, string review, int stars)
        {
            this.Stars = stars;
            this.Restaurant = name;
            this.Zipcode = zipcode;
            this.Review1 = review;
        }
    }
}
