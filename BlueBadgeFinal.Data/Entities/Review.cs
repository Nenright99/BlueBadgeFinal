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
        [Key]
        public Guid UserId { get; set; }
        [ForeignKey(nameof(Movie))]
        public string MovieReview { get; set; }
        public virtual Movie Movie { get; set; }
        [ForeignKey(nameof(Theatre))]
        public string TheatreReview { get; set; }
        public virtual Theatre Theatre { get; set; }


        [Required]
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
        public int ReviewId { get; set; }
    }
}
