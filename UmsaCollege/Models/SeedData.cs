using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UmsaCollege.Models {
    public class SeedData {
        public static void EnsurePopulated(IApplicationBuilder app) {
            ApplicationDbContext context = app.ApplicationServices
            .GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();

            if (!context.Students.Any()) {
                var students = new Student[]{
                    new Student {
                        Name = "Carlos",
                        LastName = "Zabaleta",
                        StudentCode = "1111",
                        Gender = 'M'
                    },
                    new Student {
                        Name = "Sergio",
                        LastName = "Apaza",
                        StudentCode = "1112",
                        Gender = 'M'
                    },
                    new Student {
                        Name = "Juliana",
                        LastName = "Perez",
                        StudentCode = "1113",
                        Gender = 'F'
                    },
                    new Student {
                        Name = "Diego",
                        LastName = "Joaco",
                        StudentCode = "1114",
                        Gender = 'M'
                    },
                    new Student {
                        Name = "Adrian",
                        LastName = "Copa",
                        StudentCode = "1115",
                        Gender = 'M'
                    },
                    new Student {
                        Name = "Diana",
                        LastName = "Sady",
                        StudentCode = "1116",
                        Gender = 'F'
                    },
                    new Student {
                        Name = "Martha",
                        LastName = "Rodriguez",
                        StudentCode = "1117",
                        Gender = 'F'
                    },
                    new Student {
                        Name = "Santiago",
                        LastName = "Perez",
                        StudentCode = "1118",
                        Gender = 'M'
                    }};
                foreach (Student s in students) {
                    context.Students.Add(s);
                }
                context.SaveChanges();
            };

            if (!context.Courses.Any()) {
                var courses = new Course[]
                {
                    new Course {
                        Name = "Programming I",
                        Code = "COMP-100",
                        Description = "COMP100 is an introductory course in programming. It includes programming concepts, logic and program structures.",
                        Season = "Winter",
                        Status = "Full"
                    },
                    new Course {
                        Name = "Web Development",
                        Code = "COMP-110",
                        Description = "In this first level web course the student will learn how to access the resources of the Internet, use HTML and CSS to publish high-quality Web documents.",
                        Season = "Fall",
                        Status = "Open"
                    },
                    new Course {
                        Name = "Programming II",
                        Code = "COMP-200",
                        Description = "Is a programming course incluides logic and program structures.",
                        Season = "Winter",
                        Status = "Open"
                    }
                };
                foreach (Course c in courses) {
                    context.Courses.Add(c);
                }
                context.SaveChanges();
            };

            if (!context.Enrollment.Any()) {
                var enrollments = new Enrollment[]
                {
                    new Enrollment{StudentID=1,CourseID=1},
                    new Enrollment{StudentID=1,CourseID=2},
                    new Enrollment{StudentID=8,CourseID=1},
                    new Enrollment{StudentID=2,CourseID=2},
                    new Enrollment{StudentID=2,CourseID=1},
                    new Enrollment{StudentID=8,CourseID=2},
                    new Enrollment{StudentID=3,CourseID=3},
                    new Enrollment{StudentID=4,CourseID=3},
                    new Enrollment{StudentID=4,CourseID=1},
                    new Enrollment{StudentID=5,CourseID=1},
                    new Enrollment{StudentID=6,CourseID=2},
                    new Enrollment{StudentID=7,CourseID=3},
                };
                foreach (Enrollment e in enrollments) {
                    context.Enrollment.Add(e);
                }
                context.SaveChanges();
            };
        }
    }
}