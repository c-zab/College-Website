using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UmsaCollege.Models {
    public class Course {
        
        public int CourseID { get; set; }

        [Required(ErrorMessage = "Please enter a course name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter a course code")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Please enter a course description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter a course season")]
        public string Season { get; set; }

        [Required(ErrorMessage = "Please enter a course status")]
        public string Status { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
