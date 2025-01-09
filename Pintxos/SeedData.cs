using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Pintxos
{
    public static class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider services)
        {
            var roleManager = services
                .GetRequiredService<RoleManager<IdentityRole>>();
            await EnsureRolesAsync(roleManager);

            var userManager = services
                .GetRequiredService<UserManager<IdentityUser>>();
            await EnsureTestAdminAsync(userManager);
            await EnsureTestAdminIsConfirmed(userManager);
        }

        private static async Task EnsureRolesAsync(RoleManager<IdentityRole> roleManager)
        {
            var alreadyExists = await roleManager
                .RoleExistsAsync(Constants.AdministratorRole);
            if (alreadyExists) return;

            await roleManager.CreateAsync(
                new IdentityRole(Constants.AdministratorRole));
        }

        private static async Task EnsureTestAdminAsync(
            UserManager<IdentityUser> userManager)
        {
            var testAdmin = await userManager.Users
                .Where(x => x.UserName == Constants.AdministratorDefaultAccount)
                .SingleOrDefaultAsync();

            if (testAdmin != null) return;

            testAdmin = new IdentityUser
            {
                UserName = Constants.AdministratorDefaultAccount,
                Email = Constants.AdministratorDefaultAccount
            };
            await userManager.CreateAsync(testAdmin, Constants.AdministratorDefaultPassword);
            await userManager.AddToRoleAsync(testAdmin, Constants.AdministratorRole);
        }

        private static async Task EnsureTestAdminIsConfirmed(
            UserManager<IdentityUser> userManager)
        {
            var testAdmin = await userManager.Users
                .Where(x => x.UserName == Constants.AdministratorDefaultAccount)
                .SingleOrDefaultAsync();
            var confirmed = await userManager.IsEmailConfirmedAsync(testAdmin);
            if (confirmed)
                return;
            var token = await userManager.GenerateEmailConfirmationTokenAsync(testAdmin);
            var result = await userManager.ConfirmEmailAsync(testAdmin, token);
        }
    }
}