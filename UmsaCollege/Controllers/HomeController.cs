using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using UmsaCollege.Models;
using UmsaCollege.Infrastructure;
using Microsoft.AspNetCore.Authorization;

namespace UmsaCollege.Controllers {
    public class HomeController : Controller {

        private IRepository repository;
        
        public HomeController(IRepository repo) {
            repository = repo;
        }

        public IActionResult Index() {
            return View();
        }

        public IActionResult DisplayPage() {
            ViewBag.Title = "Display";
            return View(new CourseListViewModel {
                Courses = repository.Courses
                    .OrderBy(p => p.CourseID)
            });
        }
        //From DataPage
        [HttpPost]
        public IActionResult DisplayPage(ListViewModel course) {
            ViewBag.Title = "Display";
            repository.Update(course.Courses);
            TempData["message"] = $"{course.Courses.Name} has been updated";
            return View(new CourseListViewModel {
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
            return View("DisplayPage", new CourseListViewModel {
                Courses = repository.Courses
                    .OrderBy(p => p.CourseID)
            });
        }
        [Authorize]
        public IActionResult InsertPage() {
            ViewBag.Title = "Insert";
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult InsertPage(Course course) {
            if (ModelState.IsValid) {
                repository.SaveCourse(course);
                return RedirectToAction("DisplayPage");
            } else {
                return RedirectToAction("DisplayPage");
            }
        }

        public IActionResult DataPage() {
            ViewBag.Title = "Data";
            return View();
        }

        public IActionResult ShowCourse(Course course) {
            ViewBag.Title = "Data";
            ListViewModel listV = new ListViewModel {
                Courses = course,
                Students = repository.GetStudents(course.CourseID)
            };
            return View("DataPage",listV);
        }

        [HttpPost]
        public IActionResult DataPage(int id) {
            Course course = repository.GetById(id);
            return RedirectToAction("ShowCourse", course);
        }

        public IActionResult UserPage() {
            ViewBag.Title = "User";
            return View();
        }

        [HttpPost]
        public IActionResult UserPage(int id) {
            ViewBag.Title = "User";
            Student student = new Student {
                Name = "Foo",
                LastName = "Foo",
                StudentCode = "Foo",
                Gender = 'F'
            };
            return View("UserPage", student);
        }

        //[HttpPost]
        //public IActionResult AddStudent(Student student) {
            //if (ModelState.IsValid) {
            //    studentrepository.SaveStudent(student);
            //    Course course = courserepository.GetById(student.CourseID);
            //    return RedirectToAction("ShowCourse", course);
            //} else {
            //    return View("Index");
            //}
        //}
    }
}
