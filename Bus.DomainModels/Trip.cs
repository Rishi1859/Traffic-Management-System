using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bus.DomainModels
{
    public class Trip
    { 
        [Key]
        public int TripId { get; set; }

        [Required]
        public string JourneyDate { get; set; }

        [Display(Name = "Available Seats")]
        [RegularExpression(@"^(3[00]|[12][0-9]|[1-9])$", ErrorMessage = "Maximum capacity is 30")]
        public string AvailableSeats { get; set; }

        [Required]
        public int RouteId { get; set; }
        public virtual Route Route { get; set; }

        [Required]
        public int BusId { get; set; }
        public virtual BusDetails Bus { get; set; }

        public virtual List<Ticket> Tickets { get; set; }
    }
}
