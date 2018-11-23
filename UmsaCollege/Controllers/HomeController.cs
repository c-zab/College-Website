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

        public HomeController(ICourseRepository repo) {
            courserepository = repo;
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
        public IActionResult InsertPage(CreateCourseViewModel courseVM) {
            if (ModelState.IsValid) {
                courserepository.SaveCourse(courseVM.course);
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
            return View();
        }

        public IActionResult UserPage() {
            ViewBag.Title = "User";
            return View();
        }

    }

}
