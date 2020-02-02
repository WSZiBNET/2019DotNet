using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FirmaBel.Models;

namespace FirmaBel.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
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
        public DbSet<EmployeeModel> Employees { get; set; }
        public DbSet<EmployeePositionModel> EmployeePositions { get; set; }
        public DbSet<EmployeeDepartmentModel> EmployeeDepartments { get; set; }
        public DbSet<EmployeeGradeModel> EmployeeGrades { get; set; }
        public DbSet<EmployeeRiseModel> EmployeeRises { get; set; }



        public DbSet<ItemModel> Items { get; set; }
        public DbSet<ItemTypeModel> ItemTypes { get; set; }
        public DbSet<ItemCategoryModel> ItemCategories { get; set; }


        public DbSet<TransactionModel> Transactions { get; set; }

    }
}
