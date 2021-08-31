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

        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Review1 { get; set; }

        public int? RestaurantId { get; set; }

        public int? UserId { get; set; }

        [Required]
        public int? Stars { get; set; }

        public CreatedReview(string review, int stars)
        {
            this.Review1 = review;
            this.Stars = stars;
        }
    }
}
