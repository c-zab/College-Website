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
            return View();
        }

        public IActionResult InsertPage() {
            ViewBag.Title = "Insert";
            return View();
        }

        [HttpPost]
        public IActionResult InsertPage(Course course) {
            //EFCourseRepository.AddCourses(course);
            return View("DisplayPage"/*, EFCourseRepository.courses*/);
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
