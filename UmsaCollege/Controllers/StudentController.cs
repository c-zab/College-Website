using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UmsaCollege.Models;

namespace UmsaCollege.Controllers {
    public class StudentController : Controller {

        private IRepository repository;

        public StudentController(IRepository repo) {
            repository = repo;
        }

        public IActionResult CreateStudent() {
            ViewBag.Title = "User";
            return View();
        }

        [HttpPost]
        public IActionResult CreateStudent(Student student) {
            ViewBag.Title = "User";
            if (ModelState.IsValid) {
                repository.SaveCourse(student);
            }
            return View();
        }
    }
}