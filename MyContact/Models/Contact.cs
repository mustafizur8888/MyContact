using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyContact.Models
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }

        [Required]
        [StringLength(maximumLength: 255)]
        public string Name { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        [EmailAddress]
        public string Email { get; set; }
        public string Address { get; set; }

        public DateTime? Birthday { get; set; }
        public string ImageUrl { get; set; }
        public bool? Favourite { get; set; }

        public string EntryBy { get; set; }
        public DateTime? EntryDate { get; set; }


    }
}