using Application.Contract;
using Application.Mapper;
using Application.Service;
using Context;
using Infrastructure;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Models;
using Presentation.Filters;
using Presentation.MiddleWare;
using System.Configuration;

namespace Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            #region trys
            // Add services to the container.
            //var connectionString = builder.Configuration
            //    .GetConnectionString("Db") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            //builder.Services.AddDbContext<CompanyContext>(options =>
            //    options.UseSqlServer(connectionString));
            // builder.Services.AddDatabaseDeveloperPageExceptionFilter();



            // Add services to the container.
            //builder.Services.AddControllersWithViews(options =>
            //{
            //    options.Filters.Add(new HandleExceptionAttribute());
            //}); 
            //builder.Services.AddControllersWithViews(options =>
            //{
            //    options.Filters.Add(new MyCustomAttribute());
            //});

            //builder.Services.AddDbContext<CompanyContext>(op =>
            //{
            //    op.UseSqlServer(builder.Configuration.GetConnectionString("Db"));
            //});

            //builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
            //    .AddRoles<IdentityRole>()
            //    .AddEntityFrameworkStores<ApplicationDbContext>(); 
            #endregion
            builder.Services.AddDbContext<CompanyContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("Db")));




            builder.Services.AddScoped<IDepartmentService, DepartmentService>();
            builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();

            builder.Services.AddScoped<IEmployeeService, EmployeeService>();
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            builder.Services.AddScoped<IProjectService, ProjectService>();
            builder.Services.AddScoped<IProjectRepository, ProjectRepository>();

            builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
            builder.Services.AddControllersWithViews();


            builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<CompanyContext>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            //app.UseMiddleware<CustomMiddleware>();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
