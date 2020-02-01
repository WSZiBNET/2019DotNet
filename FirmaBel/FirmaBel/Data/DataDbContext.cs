using FirmaBel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirmaBel.Data
{
    public class DataDbContext :DbContext
    {
        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options)
        {

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
