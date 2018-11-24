using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UmsaCollege.Models;
using UmsaCollege.Infrastructure;

namespace UmsaCollege.Controllers {
    public class HomeController : Controller {

        private ICourseRepository courserepository;
        private IStudentRepository studentrepository;

        public HomeController(ICourseRepository repocourse, IStudentRepository repostudent) {
            courserepository = repocourse;
            studentrepository = repostudent;
        }

        public IActionResult Index() {
            return View();
        }

        public IActionResult DisplayPage() {
            ViewBag.Title = "Display";
            return View(new CourseListViewModel {
                Courses = courserepository.Courses
                    .OrderBy(p => p.CourseID)
            });
        }

        public IActionResult InsertPage() {
            ViewBag.Title = "Insert";
            return View();
        }

        [HttpPost]
        public IActionResult InsertPage(Course course) {
            if (ModelState.IsValid) {
                courserepository.SaveCourse(course);
                return RedirectToAction("DisplayPage");
            } else {
                return View("DisplayPage");
            }
        }

        public IActionResult DataPage() {
            ViewBag.Title = "Data";
            return View();
        }

        [HttpPost]
        public IActionResult DataPage(int id) {
            ViewBag.Title = "Data";
            Course course = courserepository.GetById(id);
            return View(course);
        }

        public IActionResult UserPage() {
            ViewBag.Title = "User";
            return View();
        }
    }
}
