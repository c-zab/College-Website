using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace UmsaCollege.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DisplayPage()
        {
            ViewBag.Title = "Display";
            return View();
        }
        public IActionResult InsertPage()
        {
            ViewBag.Title = "Insert";
            return View();
        }
        public IActionResult DataPage()
        {
            ViewBag.Title = "Data";
            return View();
        }
        public IActionResult UserPage()
        {
            ViewBag.Title = "User";
            return View();
        }

    }

}