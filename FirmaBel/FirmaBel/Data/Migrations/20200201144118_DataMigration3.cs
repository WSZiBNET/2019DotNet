using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FirmaBel.Data.Migrations
{
    public partial class DataMigration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeGrade_Employees_EmployeeModelID",
                table: "EmployeeGrade");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeRise_Employees_EmployeeModelID",
                table: "EmployeeRise");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeRise_EmployeeModelID",
                table: "EmployeeRise");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeGrade_EmployeeModelID",
                table: "EmployeeGrade");

            migrationBuilder.DropColumn(
                name: "EmployeeModelID",
                table: "EmployeeRise");

            migrationBuilder.DropColumn(
                name: "EmployeeModelID",
                table: "EmployeeGrade");

            migrationBuilder.AlterColumn<string>(
                name: "IDuid",
                table: "Employees",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IDuid",
                table: "EmployeeGrade",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "ApplicationUser",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    SecurityStamp = table.Column<string>(nullable: true),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUser", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_Department",
                table: "Employees",
                column: "Department");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_IDuid",
                table: "Employees",
                column: "IDuid");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeRise_IDEmployee",
                table: "EmployeeRise",
                column: "IDEmployee");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeGrade_IDEmployee",
                table: "EmployeeGrade",
                column: "IDEmployee");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeGrade_IDuid",
                table: "EmployeeGrade",
                column: "IDuid");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeGrade_Employees_IDEmployee",
                table: "EmployeeGrade",
                column: "IDEmployee",
                principalTable: "Employees",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeGrade_ApplicationUser_IDuid",
                table: "EmployeeGrade",
                column: "IDuid",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeRise_Employees_IDEmployee",
                table: "EmployeeRise",
                column: "IDEmployee",
                principalTable: "Employees",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_EmployeeDepartment_Department",
                table: "Employees",
                column: "Department",
                principalTable: "EmployeeDepartment",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_ApplicationUser_IDuid",
                table: "Employees",
                column: "IDuid",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeGrade_Employees_IDEmployee",
                table: "EmployeeGrade");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeGrade_ApplicationUser_IDuid",
                table: "EmployeeGrade");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeRise_Employees_IDEmployee",
                table: "EmployeeRise");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_EmployeeDepartment_Department",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_ApplicationUser_IDuid",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "ApplicationUser");

            migrationBuilder.DropIndex(
                name: "IX_Employees_Department",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_IDuid",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeRise_IDEmployee",
                table: "EmployeeRise");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeGrade_IDEmployee",
                table: "EmployeeGrade");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeGrade_IDuid",
                table: "EmployeeGrade");

            migrationBuilder.AlterColumn<string>(
                name: "IDuid",
                table: "Employees",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeModelID",
                table: "EmployeeRise",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IDuid",
                table: "EmployeeGrade",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EmployeeModelID",
                table: "EmployeeGrade",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeRise_EmployeeModelID",
                table: "EmployeeRise",
                column: "EmployeeModelID");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeGrade_EmployeeModelID",
                table: "EmployeeGrade",
                column: "EmployeeModelID");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeGrade_Employees_EmployeeModelID",
                table: "EmployeeGrade",
                column: "EmployeeModelID",
                principalTable: "Employees",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeRise_Employees_EmployeeModelID",
                table: "EmployeeRise",
                column: "EmployeeModelID",
                principalTable: "Employees",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
