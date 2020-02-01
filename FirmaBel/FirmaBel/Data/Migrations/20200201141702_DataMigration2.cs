using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FirmaBel.Data.Migrations
{
    public partial class DataMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Employees_Position",
                table: "Employees",
                column: "Position");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_EmployeePosition_Position",
                table: "Employees",
                column: "Position",
                principalTable: "EmployeePosition",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_EmployeePosition_Position",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_Position",
                table: "Employees");
        }
    }
}
