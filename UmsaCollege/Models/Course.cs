using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UmsaCollege.Models {
    public class Course {
        public int CourseID { get; set; }

        public string Name { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public string Season { get; set; }

        public string Status { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}
