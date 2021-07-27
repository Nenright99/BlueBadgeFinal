using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeFinal.Data.Entities
{
    class Theatre
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Address { get; set; }
        [ForeignKey(nameof(Movie))]
        public virtual Movie MovieAddress { get; set; }
        public ICollection<Movie> MovieList { get; set; }
        public ICollection<Review> ReviewList { get; set; }
    }
}
