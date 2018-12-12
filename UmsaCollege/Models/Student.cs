using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UmsaCollege.Models {
    public class Student {
        public int StudentID { get; set; }

        [Required(ErrorMessage = "Please enter a student name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a student last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter a student code")]
        public string StudentCode { get; set; }

        [Required(ErrorMessage = "Please enter a course student gender")]
        public char Gender { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
