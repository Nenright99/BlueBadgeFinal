using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeFinal.Models.ReviewModels
{
   public class ReviewCreate
    {
        public Guid UserId { get; set; }
        [Required]
        [MinLength(2,ErrorMessage ="Please enter at least 2 characters")]
        [MaxLength(1000,ErrorMessage ="Review is to long please edit your posting must be under 1000 characters")]
        public string MovieReview { get; set; }
        public string TheatreReview { get; set; }
    }
}
