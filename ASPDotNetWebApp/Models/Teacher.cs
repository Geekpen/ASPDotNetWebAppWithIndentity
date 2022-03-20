using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPDotNetWebApp.Models
{
    public class Teacher
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        public List<StudentTeacher> StudentTeachers { get; set; }
    }
}
