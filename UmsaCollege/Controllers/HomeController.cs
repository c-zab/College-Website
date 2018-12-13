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

        public IActionResult Index() => View(GetData(nameof(Index)));

        [Authorize(Roles = "Users")]
        public IActionResult OtherAction() => View("Index",
            GetData(nameof(OtherAction)));

        private Dictionary<string, object> GetData(string actionName) =>
            new Dictionary<string, object> {
                ["Action"] = actionName,
                ["User"] = HttpContext.User.Identity.Name,
                ["Authenticated"] = HttpContext.User.Identity.IsAuthenticated,
                ["Auth Type"] = HttpContext.User.Identity.AuthenticationType,
                ["In Users Role"] = HttpContext.User.IsInRole("Users")
            };

        public IActionResult DisplayPage() {
            ViewBag.Title = "Display";
            return View(new CourseListViewModel {
                Courses = repository.Courses
                    .OrderBy(p => p.CourseID)
            });
        }
        
        public IActionResult InsertPage() {
            ViewBag.Title = "Insert";
            return View();
        }

        public IActionResult DataPage() {
            ViewBag.Title = "Data";
            return View();
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
