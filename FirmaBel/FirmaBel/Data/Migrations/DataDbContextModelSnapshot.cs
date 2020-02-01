﻿// <auto-generated />
using FirmaBel.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace FirmaBel.Data.Migrations
{
    [DbContext(typeof(DataDbContext))]
    partial class DataDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FirmaBel.Models.EmployeeDepartmentModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DepartmentName");

                    b.HasKey("ID");

                    b.ToTable("EmployeeDepartment");
                });

            modelBuilder.Entity("FirmaBel.Models.EmployeeGradeModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("EmployeeModelID");

                    b.Property<int>("IDEmployee");

                    b.Property<string>("IDuid");

                    b.Property<DateTime>("TimeStamp");

                    b.Property<int>("Value");

                    b.HasKey("ID");

                    b.HasIndex("EmployeeModelID");

                    b.ToTable("EmployeeGrade");
                });

            modelBuilder.Entity("FirmaBel.Models.EmployeeModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<int>("Age");

                    b.Property<string>("City");

                    b.Property<int>("Department");

                    b.Property<string>("IDuid");

                    b.Property<string>("Name");

                    b.Property<int>("Position");

                    b.Property<decimal>("Salary");

                    b.Property<string>("Surname");

                    b.HasKey("ID");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("FirmaBel.Models.EmployeePositionModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("PositionName");

                    b.HasKey("ID");

                    b.ToTable("EmployeePosition");
                });

            modelBuilder.Entity("FirmaBel.Models.EmployeeRiseModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("EmployeeModelID");

                    b.Property<int>("IDEmployee");

                    b.Property<DateTime>("TimeStamp");

                    b.Property<decimal>("Value");

                    b.HasKey("ID");

                    b.HasIndex("EmployeeModelID");

                    b.ToTable("EmployeeRise");
                });

            modelBuilder.Entity("FirmaBel.Models.ItemCategoryModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryName");

                    b.HasKey("ID");

                    b.ToTable("ItemCategory");
                });

            modelBuilder.Entity("FirmaBel.Models.ItemModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Category");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.Property<int>("TypeName");

                    b.HasKey("ID");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("FirmaBel.Models.ItemTypeModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("TypeName");

                    b.HasKey("ID");

                    b.ToTable("ItemType");
                });

            modelBuilder.Entity("FirmaBel.Models.TransactionModel", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Amount");

                    b.Property<int>("IDProduct");

                    b.Property<string>("IDuid");

                    b.Property<decimal>("Price");

                    b.Property<DateTime>("TimeStamp");

                    b.Property<decimal>("TotalPrice");

                    b.HasKey("ID");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("FirmaBel.Models.EmployeeGradeModel", b =>
                {
                    b.HasOne("FirmaBel.Models.EmployeeModel")
                        .WithMany("Grade")
                        .HasForeignKey("EmployeeModelID");
                });

            modelBuilder.Entity("FirmaBel.Models.EmployeeRiseModel", b =>
                {
                    b.HasOne("FirmaBel.Models.EmployeeModel")
                        .WithMany("Rise")
                        .HasForeignKey("EmployeeModelID");
                });
#pragma warning restore 612, 618
        }
    }
}
