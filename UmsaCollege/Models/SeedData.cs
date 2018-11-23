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
            if (!context.Courses.Any()) {
                context.Courses.AddRange(
                    new Course {
                        Name = "Programming II",
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
                    }
                );
            };
            //if (!context.Students.Any()) {
            //    context.SaveChanges();
            //}
        }
    }
}
