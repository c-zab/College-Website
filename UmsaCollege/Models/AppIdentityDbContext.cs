using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UmsaCollege.Models {
    public class AppIdentityDbContext : IdentityDbContext<AppUser> {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options)
            : base(options) { }
        
        public static async Task CreateAdminAccount(IServiceProvider serviceProvider,
            IConfiguration configuration) {
            UserManager<AppUser> userManager =
                serviceProvider.GetRequiredService<UserManager<AppUser>>();
            RoleManager<IdentityRole> roleManager =
                serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            string username = configuration["Data:AdminUser:Name"];
            string email = configuration["Data:AdminUser:Email"];
            string password = configuration["Data:AdminUser:Password"];
            string role = configuration["Data:AdminUser:Role"];
            if (await userManager.FindByNameAsync(username) == null) {
                if (await roleManager.FindByNameAsync(role) == null) {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
                AppUser user = new AppUser {
                    UserName = username,
                    Email = email
                };
                IdentityResult result = await userManager
                .CreateAsync(user, password);
                if (result.Succeeded) {
                    await userManager.AddToRoleAsync(user, role);
                }
            }
        }

        public static async Task CreateGeneralAccount(IServiceProvider serviceProvider,
            IConfiguration configuration) {
            UserManager<AppUser> userManager =
                serviceProvider.GetRequiredService<UserManager<AppUser>>();
            RoleManager<IdentityRole> roleManager =
                serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            string usernameG = configuration["Data:GeneralUser:Name"];
            string emailG = configuration["Data:GeneralUser:Email"];
            string passwordG = configuration["Data:GeneralUser:Password"];
            string roleG = configuration["Data:GeneralUser:Role"];
            if (await userManager.FindByNameAsync(usernameG) == null) {
                if (await roleManager.FindByNameAsync(roleG) == null) {
                    await roleManager.CreateAsync(new IdentityRole(roleG));
                }
                AppUser userG = new AppUser {
                    UserName = usernameG,
                    Email = emailG
                };
                IdentityResult result = await userManager
                    .CreateAsync(userG, passwordG);
                if (result.Succeeded) {
                    await userManager.AddToRoleAsync(userG, roleG);
                }
            }
        }
    }
}
