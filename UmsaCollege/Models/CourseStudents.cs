using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UmsaCollege.Models {
    public class CourseStudents {
        public int CourseID { get; set; }
        public Course course { get; set; }
        public int StudentID { get; set; }
        public Student student { get; set; }
    }
}
