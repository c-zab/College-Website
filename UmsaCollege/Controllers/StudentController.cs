using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UmsaCollege.Infrastructure;
using UmsaCollege.Models;

namespace UmsaCollege.Controllers {

    [Authorize(Roles = "Admins,General")]
    public class StudentController : Controller {

        private IRepository repository;

        public StudentController(IRepository repo) {
            repository = repo;
        }

        [HttpPost]
        public IActionResult EnrrollStudent(int courseId) {
            ViewBag.Title = "User";
            Course course = repository.GetById(courseId);
            StudentListViewModel listV = new StudentListViewModel {
                Courses = course,
                Students = repository.Students
            };
            return View("List", listV);
        }

        public IActionResult CreateStudent() {
            ViewBag.Title = "User";
            return View();
        }

        [HttpPost]
        public IActionResult CreateStudents(Student student) {
            ViewBag.Title = "User";
            if (ModelState.IsValid) {
                repository.SaveStudent(student);
            }
            StudentListViewModel listV = new StudentListViewModel { 
                Students = repository.Students
            };
            return View("List", listV);
        }
    }
}