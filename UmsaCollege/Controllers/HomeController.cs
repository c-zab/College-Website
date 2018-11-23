using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UmsaCollege.Models;

namespace UmsaCollege.Controllers {
    public class HomeController : Controller {
        public IActionResult Index() {
            return View();
        }

        public IActionResult DisplayPage() {
            ViewBag.Title = "Display";
            EFCourseRepository.AddCourses(new Course {
                Name = "Programming II",
                Code = "COMP-100",
                Description = "COMP100 is an introductory course in programming. It includes programming concepts, logic and program structures.",
                Season = "Winter",
                Status = "Full"
            });
            EFCourseRepository.AddCourses(new Course {
                Name = "Web Development",
                Code = "COMP-110",
                Description = "In this first level web course the student will learn how to access the resources of the Internet, use HTML and CSS to publish high-quality Web documents.",
                Season = "Fall",
                Status = "Open"
            });
            return View(EFCourseRepository.courses);
        }

        public IActionResult InsertPage() {
            ViewBag.Title = "Insert";
            return View();
        }

        [HttpPost]
        public IActionResult InsertPage(Course course) {
            EFCourseRepository.AddCourses(course);
            return View("DisplayPage", EFCourseRepository.courses);
        }

        public IActionResult DataPage() {
            ViewBag.Title = "Data";
            return View();
        }

        public IActionResult UserPage() {
            ViewBag.Title = "User";
            return View();
        }

    }

}
