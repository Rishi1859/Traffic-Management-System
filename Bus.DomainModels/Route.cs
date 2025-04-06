using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bus.DomainModels
{
    public class Route
    {
        [Key]
        public int RouteId { get; set; }

        [Required]
        [MaxLength(30)]
        public string FromLocation { get; set; }

        [Required]
        [MaxLength(30)]
        public string ToLocation { get; set; }

        [Required]
        [Range(0, Double.MaxValue)]
        public double Price { get; set; }

    }
}
