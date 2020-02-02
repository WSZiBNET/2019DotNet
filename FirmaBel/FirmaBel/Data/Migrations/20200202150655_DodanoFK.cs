using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FirmaBel.Data.Migrations
{
    public partial class DodanoFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IDuid",
                table: "Transactions",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_IDuid",
                table: "Transactions",
                column: "IDuid");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_AspNetUsers_IDuid",
                table: "Transactions",
                column: "IDuid",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_AspNetUsers_IDuid",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_IDuid",
                table: "Transactions");

            migrationBuilder.AlterColumn<string>(
                name: "IDuid",
                table: "Transactions",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
