using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UmsaCollege.Infrastructure;
using UmsaCollege.Models;

namespace UmsaCollege.Controllers {
    [Authorize(Roles = "Admins")]
    public class CourseController : Controller {
        private IRepository repository;

        public CourseController(IRepository repo) {
            repository = repo;
        }

        [HttpPost]
        public IActionResult DataPage(int id) {
            Course course = repository.GetById(id);
            ListViewModel listV = new ListViewModel {
                Courses = course,
                Students = repository.GetStudents(course.CourseID)
            };
            ViewBag.Title = "Data";
            return View(listV);
        }

        [HttpPost]
        public IActionResult UpdateCourse(ListViewModel course) {
            ViewBag.Title = "Display";
            repository.Update(course.Courses);
            TempData["message"] = $"{course.Courses.Name} has been updated";
            return RedirectToAction("DisplayPage", "Home", new CourseListViewModel {
                Courses = repository.Courses
                    .OrderBy(p => p.CourseID)
            });
        }

        [HttpPost]
        public IActionResult DeleteCourse(int id) {
            ViewBag.Title = "Display";
            Course course = repository.GetById(id);
            repository.Delete(course);
            if (course != null) {
                TempData["messageDanger"] = $"{course.Name} was deleted";
            }
            return RedirectToAction("DisplayPage", "Home", new CourseListViewModel {
                Courses = repository.Courses
                    .OrderBy(p => p.CourseID)
            });
        }

        [HttpPost]
        public IActionResult InsertCourse(Course course) {
            if (ModelState.IsValid) {
                repository.SaveCourse(course);
            }
            return RedirectToAction("DisplayPage", "Home");
        }
    }
}