using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using scheduler.Areas.Identity.Data;
using scheduler.Data;
namespace scheduler
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
                        var connectionString = builder.Configuration.GetConnectionString("schedulerContextConnection") ?? throw new InvalidOperationException("Connection string 'schedulerContextConnection' not found.");

                                    builder.Services.AddDbContext<schedulerContext>(options =>
                options.UseSqlServer(connectionString));

                                                builder.Services.AddDefaultIdentity<schedulerUser>()
                .AddEntityFrameworkStores<schedulerContext>();

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
                        app.UseAuthentication();;

            app.MapRazorPages();
            app.UseAuthorization();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}