using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using scheduler.Areas.Identity.Data;
using scheduler.Models;

namespace scheduler.Data;

public class schedulerContext : IdentityDbContext<schedulerUser>
{
    public schedulerContext(DbContextOptions<schedulerContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

    public DbSet<scheduler.Models.ApointmentModel>? ApointmentModel { get; set; }
}
