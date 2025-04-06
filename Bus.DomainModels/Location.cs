using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bus.DomainModels
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }

        [Required]
        public string JourneyLocation { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public string ShortDescription { get; set; }

        [Required]
        public int RouteId { get; set; }
        public virtual Route Route { get; set; }

    }
}
