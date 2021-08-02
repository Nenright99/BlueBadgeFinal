using BlueBadgeFinal.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeFinal.Models
{
    public class MovieCreate
    {
        [Required]
        public string Title { get; set; }
        public GenreType TypeOfGenres { get; set; }
        public DateTime Release { get; set; }
        public MaturityRating Maturity { get; set; }
        public int TheaterId { get; set; }
    }
}
