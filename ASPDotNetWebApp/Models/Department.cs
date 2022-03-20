using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPDotNetWebApp.Models
{
    public class Department
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Department Name")]
        public string DepartmentName { get; set; }

        [Required]
        [Display(Name = "Head of Department")]
        public string HOD { get; set; }

        public List<Student> Students { get; set; }
    }
}
