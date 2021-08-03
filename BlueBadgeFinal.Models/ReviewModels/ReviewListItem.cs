using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeFinal.Models.ReviewModels
{
   public class ReviewListItem
    {
        public Guid UserId { get; set; }
        public string MovieReview { get; set; }
        public string TheatreReview { get; set; }
        public DateTimeOffset CreatedUtc { get; set;}
        public DateTimeOffset? ModifiedUtc { get; set; }

    }
}
