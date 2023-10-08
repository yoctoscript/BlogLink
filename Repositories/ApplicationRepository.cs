using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlogLink.Repositories;

public class ApplicationRepository : IdentityDbContext<IdentityUser>
{
    public ApplicationRepository(DbContextOptions<ApplicationRepository> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}