using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UmsaCollege.Models {
    public class ICourseRepository {
        IQueryable<Course> Courses { get; }

        void SaveCourse(Student student);

        void Update(Student student);

        Student GetById(int id);

        void Delete(Student student);
    }
}
