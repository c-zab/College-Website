using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UmsaCollege.Models {
    public class IdentitySeedData {
        private const string adminUser = "Admin";
        private const string adminPassword = "Secret123$";

        private const string generalUser = "General";
        private const string generalPassword = "Secret123$";

        public static async void EnsurePopulated(IApplicationBuilder app) {
            UserManager<IdentityUser> userManager = app.ApplicationServices
                .GetRequiredService<UserManager<IdentityUser>>();

            IdentityUser userAdmin = await userManager.FindByIdAsync(adminUser);
            if (userAdmin == null) {
                userAdmin = new IdentityUser("Admin");
                await userManager.CreateAsync(userAdmin, adminPassword);
            }

            IdentityUser userGeneral = await userManager.FindByIdAsync(generalUser);
            if (userGeneral == null) {
                userGeneral = new IdentityUser("General");
                await userManager.CreateAsync(userGeneral, generalPassword);
            }
        }
    }
}
