﻿using Avhrm.Identity.Server.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Avhrm.Identity.Server.Seeds;

namespace Avhrm.Identity.Server.Services;

public class AvhrmIdentityContext : IdentityDbContext<ApplicationUser>
{
    public AvhrmIdentityContext()
    {
        Database.Migrate();
    }

    public AvhrmIdentityContext(DbContextOptions<AvhrmIdentityContext> options) : base(options)
    {
        Database.Migrate();
    }

    public DbSet<Permission> Permissions { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.SeedApplicationUserData();
    }
}
