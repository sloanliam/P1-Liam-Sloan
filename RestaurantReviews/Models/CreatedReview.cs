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

        public int? RestaurantId { get; set; }
        public int? UserId { get; set; }
        public int? Stars { get; set; }
    }
}
