

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Models;
using System.Data.Entity.Migrations;

namespace Context
{ 
    public class CompanyContext:IdentityDbContext<ApplicationUser>
    {
        public DbSet<Employee> Employees { set; get; }
        public DbSet<Department> Departments { set; get; }
        public CompanyContext(DbContextOptions<CompanyContext>options):base(options)
        {
            
        }
        // public DbSet<Project> Projects{ set; get; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-TBIFCVN\\SQLEXPRESS;Initial Catalog=NewElSherka;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

            base.OnConfiguring(optionsBuilder);
        }
    }

    //public class CompanyContext:IdentityDbContext<ApplicationUser>
    //{
    //    // public CompanyContext(DbContextOptions<CompanyContext> dbContextOptions) : base(dbContextOptions) { }
    //    //public CompanyContext(DbContextOptions<CompanyContext> option) : base(option)
    //    //{
    //    //}
    //    //DbContext
    //    public CompanyContext(DbContextOptions<CompanyContext> options) : base(options)
    //    {


    //    }

    //    public DbSet<Employee>Employees { set; get; }
    //    public DbSet<Department> Departments { set; get; }
    //    public DbSet<Project> Projects{ set; get; }
    //    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    //{
    //    //   // optionsBuilder.UseSqlServer("Data Source=DESKTOP-TBIFCVN\\SQLEXPRESS;Initial Catalog=NewElSherka;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

    //    //}

    //    protected override void OnModelCreating(ModelBuilder modelBuilder)
    //    {
    //        // Employee - Department relationship (Many-to-1)
    //        modelBuilder.Entity<Employee>()
    //            .HasOne(e => e.department)
    //            .WithMany(d => d.Employees)
    //            .HasForeignKey(e => e.DepartmentId)
    //            .OnDelete(DeleteBehavior.Restrict); // Prevent cascading deletes

    //        // Project - Employee relationship (Many-to-1)
    //        modelBuilder.Entity<Project>()
    //            .HasOne(p => p.Employee)
    //            .WithMany(e => e.Projects)
    //            .HasForeignKey(p => p.EmployeeId)
    //            .OnDelete(DeleteBehavior.Restrict); // Prevent cascading deletes

    //        // Project - Department relationship (Many-to-1)
    //        modelBuilder.Entity<Project>()
    //            .HasOne(p => p.department)
    //            .WithMany(d => d.Projects)
    //            .HasForeignKey(p => p.DepartmentId)
    //            .OnDelete(DeleteBehavior.Restrict); // Prevent cascading deletes

    //        base.OnModelCreating(modelBuilder);
    //    }


    //}

}
