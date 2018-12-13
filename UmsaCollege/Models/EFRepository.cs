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

        public IQueryable<Enrollment> Enrollments => context.Enrollment;

        public IQueryable<Student> GetStudents(int courseID) {
            var st = (from p in context.Enrollment
                      where p.CourseID == courseID
                      select p.StudentID);
            List<Student> ListStudents = new List<Student>();
            if (st.Count() > 0) {
                foreach (var stu in st) {
                    Student x = context.Set<Student>().Find(stu);
                    ListStudents.Add(x);
                }
                return ListStudents.AsQueryable();
            } else {
                return ListStudents.AsQueryable();
            }
            
        }

        public Student GetStudentById(int id) {
            return context.Set<Student>().Find(id);
        }

        public void SaveCourse(Course course) {
            if (course != null) {
                context.AttachRange(course);
                context.SaveChanges();
            }
        }

        public void SaveStudent(Student student) {
            if (student != null) {
                context.AttachRange(student);
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
