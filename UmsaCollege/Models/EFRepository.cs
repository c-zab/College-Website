using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UmsaCollege.Models {
    public class EFRepository : IRepository {
        private ApplicationDbContext context;

        public EFRepository(ApplicationDbContext ctx) {
            context = ctx;
        }

        public IQueryable<Course> Courses => context.Courses;

        public IQueryable<Student> Students => context.Students;

        public IEnumerable<Student> GetStudents(int courseID) {
            //var customerOrders =
            //      from o in context.Students
            //      join c in context.Courses on o. equals c.CourseID
            //      select new { OrderID = o.ID, CustomerName = c.Name };
            return context.Students.Where<Student>(p => p.StudentID == courseID);

        }

        //public Student GetById(int id) {
        //    return context.Set<Student>().Find(id);
        //}

        //public IEnumerable<Student> getStudents(Course course) {
        //    return course.Students;
        //}

        public void SaveCourse(Course course) {
            if (course.Description != null & course.Name != null) {
                context.AttachRange(course);
                if (course.CourseID == 0) {
                    context.Courses.Add(course);
                }
                context.SaveChanges();
            }
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
