using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UmsaCollege.Models;

namespace UmsaCollege.Controllers {
    public class AdminController : Controller {

        private UserManager<AppUser> userManager;

        public AdminController(UserManager<AppUser> usrMgr) {
            userManager = usrMgr;
        }
        public ViewResult Index() => View(userManager.Users);
    }
}
