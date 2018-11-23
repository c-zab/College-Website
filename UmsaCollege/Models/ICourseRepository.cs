using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UmsaCollege.Models {
    public interface ICourseRepository {
        IQueryable<Course> Courses { get; }

        void SaveCourse(Course course);

        void Update(Course course);

        Course GetById(int id);

        void Delete(Course course);
    }
}
