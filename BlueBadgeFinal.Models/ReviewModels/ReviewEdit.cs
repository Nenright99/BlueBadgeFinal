using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeFinal.Models.ReviewModels
{
   public class ReviewEdit
    {
        public Guid UserId { get; set; }
        public string MovieReview { get; set; }
        public string TheatreReview { get; set; }
    }
}
