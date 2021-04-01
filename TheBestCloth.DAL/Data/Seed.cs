using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TheBestCloth.BLL.Domain;

namespace TheBestCloth.DAL.Data
{
    public class Seed
    {
        public static async Task SeedRoles(
            UserManager<User> userManager, 
            RoleManager<AppRole> roleManager,
            PostgresContext context,
            IConfiguration configuration
            )
        {

            if (await context.Users.AnyAsync()) return;

            var admin = new User
            {
                Email = "admin@admin.com",
                FirstName = "Admin",
                UserName = "admin@admin.com"
            };

            var roles = new List<AppRole>
            {
                new AppRole {Name = "Admin"},
                new AppRole {Name = "Moderator"},
                new AppRole {Name = "Customer"}
            };

            foreach (var role in roles)
            {
                await roleManager.CreateAsync(role);
            }

            await userManager.CreateAsync(
                admin,
                configuration["AdminPassword"]
                ); 
            await userManager.AddToRoleAsync(admin, "Admin");
        }
    }
}
