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
        public int ReviewId { get; set; }
        public Guid UserId { get; set; }
        public string TheatreReview { get; set; }
        public string MovieReview { get; set; }

        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }
       
        [ForeignKey("Theatre")]    
        public int? TheatreID { get; set; }
        public virtual Theatre Theatre { get; set; }

        [ForeignKey("Movie")]
        public int? ID { get; set; }
        public virtual Movie Movie { get; set; }

    }
}
