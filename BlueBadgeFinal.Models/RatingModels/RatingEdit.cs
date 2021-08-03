using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRater.Models
{
    public class RatingEdit
    {
        public int ID { get; set; }
        public double MovieRating { get; set; }
        public double TheaterRating { get; set; }

    }
}