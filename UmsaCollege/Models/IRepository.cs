using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UmsaCollege.Models {
    public interface IRepository {
        IQueryable<Course> Courses { get; }

        IQueryable<Student> Students { get; }

        IEnumerable<Student> GetStudents(int courseID);

        void SaveCourse(Course course);

        void Update(Course course);

        Course GetById(int id);

        void Delete(Course course);
    }
}
