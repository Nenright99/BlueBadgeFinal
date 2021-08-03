using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueBadgeFinal.Models.TheatreModels
{
    public class TheatreDetail
    {
        public int TheatreID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        [Display(Name="Created")]
        public DateTimeOffset CreatedUTC { get; set; }
        [Display(Name="Modified")]
        public DateTimeOffset? ModifiedUTC { get; set; }
    }
}
