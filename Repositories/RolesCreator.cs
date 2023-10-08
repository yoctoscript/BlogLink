using Microsoft.AspNetCore.Identity;

namespace BlogLink.Repositories;

public static class Roles
{
    public static string Administrator {get;} = "Administrator";
    public static string Member {get;} = "Member";
}
// TODO: remove this, only work with claims
public static class RolesCreator
{
    public static async Task CreateRoles(this IServiceProvider services)
    {
        var scope = services.CreateScope();
        var roleManager = (RoleManager<IdentityRole>)scope.ServiceProvider.GetService(typeof(RoleManager<IdentityRole>));
        
        var roles = new List<string>() {Roles.Administrator, Roles.Member};

        foreach(var roleName in roles)
        {
            var roleExists = await roleManager.RoleExistsAsync(roleName);
            if (!roleExists)
            {
                var role = new IdentityRole(roleName);
                await roleManager.CreateAsync(role);
            }
        }
    }
}