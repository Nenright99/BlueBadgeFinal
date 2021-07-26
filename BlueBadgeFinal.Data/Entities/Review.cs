using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeFinal.Data.Entities
{
   public class Review
    {
        [ForeignKey(nameof(Movie))]
        public string MovieReview { get; set; }
        [ForeignKey(nameof(Theatre))]
        public string TheatreReview { get; set; }
        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
        [Key]
        public Guid UserId { get; set; }
        public int ReviewId { get; set; }
    }
}
