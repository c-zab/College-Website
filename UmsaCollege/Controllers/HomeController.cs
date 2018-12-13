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
        
        [Authorize(Roles = "Admins,General")]
        public IActionResult DisplayPage() {
            ViewBag.Title = "Display";
            return View(new CourseListViewModel {
                Courses = repository.Courses
                    .OrderBy(p => p.CourseID)
            });
        }

        [Authorize(Roles = "Admins")]
        public IActionResult InsertPage() {
            ViewBag.Title = "Insert";
            return View();
        }

        [Authorize(Roles = "Admins")]
        public IActionResult DataPage() {
            ViewBag.Title = "Data";
            return View();
        }

        [Authorize(Roles = "Admins,General")]
        public IActionResult UserPage() {
            ViewBag.Title = "User";
            StudentListViewModel listV = new StudentListViewModel {
                Students = repository.Students
            };
            return View(listV);
        }
    }
}
