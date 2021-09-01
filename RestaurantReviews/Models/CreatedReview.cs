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
        [StringLength(maximumLength: 200, MinimumLength =10)]
        [Display(Name ="review")]
        public string Review1 { get; set; }

        [Required]
        public string Restaurant { get; set; }

        [Required]
        [Range(10000, 99999, ErrorMessage = "That is not a valid zipcode.")]
        public int Zipcode { get; set; }

        [Required]
        [Range(1, 5)]
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
