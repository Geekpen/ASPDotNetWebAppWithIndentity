using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPDotNetWebApp.Models
{
    public class ContactInfo
    {
        public int ID { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
            ErrorMessage = "Not a valid phone number")]
        public string PhoneNumber { get; set; }

        public int StudentID { get; set; }

        public Student Student { get; set; }
    }
}
