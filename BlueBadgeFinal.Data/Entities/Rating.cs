using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeFinal.Data.Entities
{
    public class Rating
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [Range(0, 10)]
        public double MovieRating { get; set; }
        [Required]
        [Range(0, 10)]
        public double TheaterRating { get; set; }
        public Guid AuthorId { get; set; }
        public DateTimeOffset CreatedUtc { get; set; }
        public DateTimeOffset? ModifiedUtc { get; set; }

        [ForeignKey("Movie")]
        public int? MovieID { get; set; }        
        public virtual Movie Movie { get; set; }

        [ForeignKey("Theatre")]
        public int? TheatreID { get; set; }       
        public virtual Theatre Theatre { get; set; }
    }
}
