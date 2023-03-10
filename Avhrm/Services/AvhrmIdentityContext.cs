using Avhrm.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Avhrm.Identity.Services;

public class AvhrmIdentityContext : IdentityDbContext<ApplicationUser>
{
    public AvhrmIdentityContext(DbContextOptions<AvhrmIdentityContext> options) : base(options)
    {
        Database.Migrate();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
