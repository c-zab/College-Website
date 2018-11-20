using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UmsaCollege.Models {
    public class CourseRepository {
        private static List<Course> Courses = new List<Course>();

        public static IEnumerable<Course> courses {
            get {
                return Courses;
            }
        }
        public static void AddCourses(Course course) {
            Courses.Add(course);
        }
        public static void EditCourses(Course course) {
            Courses.Add(course);
        }
    }
}
