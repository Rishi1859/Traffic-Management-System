using Bus.DomainModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BusReservationSystem.Models
{
    public class Register : IdentityUser
    {
        [Required]
        [RegularExpression(@"^[A-Za-z\s]+${3,30}", ErrorMessage = "Please enter a valid name")]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9-\s]+$", ErrorMessage = "Address is in wrong format")]
        public string Address { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z-\s]+$", ErrorMessage = "City is in wrong format")]
        public string City { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z-\s]+$", ErrorMessage = "State is in wrong format")]
        public string State { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z-\s]+$", ErrorMessage = "Country is in wrong format")]
        public string Country { get; set; }

        [Required]
        //[MaxLength(6)]
        public int Pincode { get; set; }

        [Required]
        //[Range(18,80)]
        public int Age { get; set; }

        [Required]
        [RegularExpression(@"^[6-9][0-9]{9}$", ErrorMessage = "Contact number format is incorrect")]
        public string ContactNumber { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }
    }
}
