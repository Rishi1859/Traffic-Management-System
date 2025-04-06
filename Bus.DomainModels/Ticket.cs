using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Bus.DomainModels
{
    public class Ticket
    {
        [Key]
        public int TicketId { get; set; }

        [Required]
        public int PassengerCount { get; set; }

        [Required]
        public int TripId { get; set; }
        public virtual Trip Trip { get; set; }
    }
}
