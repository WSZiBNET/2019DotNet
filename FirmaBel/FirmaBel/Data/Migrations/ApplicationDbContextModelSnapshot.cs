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
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FirmaBel.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("Nickname");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

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

                    b.Property<int>("IDEmployee");

                    b.Property<string>("IDuid");

                    b.Property<DateTime>("TimeStamp");

                    b.Property<int>("Value");

                    b.HasKey("ID");

                    b.HasIndex("IDEmployee");

                    b.HasIndex("IDuid");

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

                    b.HasIndex("Department");

                    b.HasIndex("IDuid");

                    b.HasIndex("Position");

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

                    b.Property<int>("IDEmployee");

                    b.Property<DateTime>("TimeStamp");

                    b.Property<decimal>("Value");

                    b.HasKey("ID");

                    b.HasIndex("IDEmployee");

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

                    b.HasIndex("Category");

                    b.HasIndex("TypeName");

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

                    b.HasIndex("IDProduct");

                    b.HasIndex("IDuid");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("FirmaBel.Models.EmployeeGradeModel", b =>
                {
                    b.HasOne("FirmaBel.Models.EmployeeModel", "Employees")
                        .WithMany("Grade")
                        .HasForeignKey("IDEmployee")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FirmaBel.Models.ApplicationUser", "AspNetUsers")
                        .WithMany()
                        .HasForeignKey("IDuid");
                });

            modelBuilder.Entity("FirmaBel.Models.EmployeeModel", b =>
                {
                    b.HasOne("FirmaBel.Models.EmployeeDepartmentModel", "EmployeeDepartment")
                        .WithMany()
                        .HasForeignKey("Department")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FirmaBel.Models.ApplicationUser", "AspNetUsers")
                        .WithMany()
                        .HasForeignKey("IDuid");

                    b.HasOne("FirmaBel.Models.EmployeePositionModel", "EmployeePosition")
                        .WithMany()
                        .HasForeignKey("Position")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FirmaBel.Models.EmployeeRiseModel", b =>
                {
                    b.HasOne("FirmaBel.Models.EmployeeModel", "Employees")
                        .WithMany("Rise")
                        .HasForeignKey("IDEmployee")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FirmaBel.Models.ItemModel", b =>
                {
                    b.HasOne("FirmaBel.Models.ItemCategoryModel", "ItemCategory")
                        .WithMany()
                        .HasForeignKey("Category")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FirmaBel.Models.ItemTypeModel", "ItemType")
                        .WithMany()
                        .HasForeignKey("TypeName")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("FirmaBel.Models.TransactionModel", b =>
                {
                    b.HasOne("FirmaBel.Models.ItemModel", "Items")
                        .WithMany()
                        .HasForeignKey("IDProduct")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FirmaBel.Models.ApplicationUser", "AspNetUsers")
                        .WithMany()
                        .HasForeignKey("IDuid");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("FirmaBel.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("FirmaBel.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("FirmaBel.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("FirmaBel.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
