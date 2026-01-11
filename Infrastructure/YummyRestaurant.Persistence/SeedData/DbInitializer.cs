using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using YummyRestaurant.Domain.Entities;

namespace YummyRestaurant.Persistence.SeedData;

public static class DbInitializer
{
    public static async Task Initialize(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<AppRole>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<AppUser>>();

        string[] roleNames = { "Admin", "Member" };

        foreach (var roleName in roleNames)
        {
            var roleExist = await roleManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                await roleManager.CreateAsync(new AppRole { Name = roleName });
            }
        }

        var user = await userManager.FindByNameAsync("admin");
        if (user == null)
        {
            user = new AppUser
            {
                UserName = "admin",
                Email = "admin@yummy.com",
                Name = "Admin",
                Surname = "User"
            };
            var result = await userManager.CreateAsync(user, "Password12*");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "Admin");
            }
        }
    }
}
