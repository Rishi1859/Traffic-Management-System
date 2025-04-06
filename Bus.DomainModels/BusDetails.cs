using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Bus.DomainModels
{
    public class BusDetails
    {
        [Key]
        public int BusId { get; set; }

        [Required]
        [RegularExpression(@"^[A-Za-z\s]+${3,20}", ErrorMessage = "Maximum 20 characters only")]
        [StringLength(20)]
        public string BusName { get; set; }

        [Required]
        [EnumDataType(typeof(BusCategory))]
        public BusCategory BusCategory{ get; set; }

        [Required]
        //[Range(1, 30)]
        [RegularExpression(@"^(3[00]|[12][0-9]|[1-9])$", ErrorMessage = "Maximum capacity is 30" )]
        public int Capacity { get; set; }

        public virtual List<Trip> Trips { get; set; }
        
    }
}
