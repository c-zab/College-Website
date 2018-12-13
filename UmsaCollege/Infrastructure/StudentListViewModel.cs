using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UmsaCollege.Models;

namespace UmsaCollege.Infrastructure {
    public class StudentListViewModel {
        public IEnumerable<Student> Students { get; set; }
        public Course Courses { get; set; }
    }
}
