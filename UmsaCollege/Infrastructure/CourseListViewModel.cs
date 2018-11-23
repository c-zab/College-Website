using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UmsaCollege.Models;

namespace UmsaCollege.Infrastructure {
    public class CourseListViewModel {
        public IEnumerable<Course> Courses { get; set; }
    }
}
