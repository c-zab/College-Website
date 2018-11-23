using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UmsaCollege.Models {
    public class EFCourseRepository : ICourseRepository{
        private ApplicationDbContext context;

        public EFCourseRepository(ApplicationDbContext ctx) {
            context = ctx;
        }

        public IQueryable<Course> Courses => context.Courses;

        public void SaveCourse(Course course) {
            context.AttachRange(course);
            if (course.CourseID == 0) {
                context.Courses.Add(course);
            }
            context.SaveChanges();
        }

        public Course GetById(int id) {
            return context.Set<Course>().Find(id);
        }

        public void Update(Course course) {
            context.Entry(course).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(Course course) {
            context.Remove(course);
            context.SaveChanges();
        }
    }
}
