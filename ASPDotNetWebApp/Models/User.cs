using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ASPDotNetWebApp.Models
{
    [Table("User")]
    public class User
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [StringLength(128, MinimumLength = 8)]
        [Required]
        public string Password { get; set; }

        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
            ErrorMessage = "Not a valid phone number")]
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }
    }
}
