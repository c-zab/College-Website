using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UmsaCollege.Models {
    public class Student {
        public int StudentID { get; set; }

        public string Name { get; set; }

        public string LastName { get; set; }

        public string StudentCode { get; set; }

        public char Gender { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
