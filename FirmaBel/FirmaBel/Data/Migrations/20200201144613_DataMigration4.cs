using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace FirmaBel.Data.Migrations
{
    public partial class DataMigration4 : Migration
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
                name: "IX_Transactions_IDProduct",
                table: "Transactions",
                column: "IDProduct");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_IDuid",
                table: "Transactions",
                column: "IDuid");

            migrationBuilder.CreateIndex(
                name: "IX_Items_Category",
                table: "Items",
                column: "Category");

            migrationBuilder.CreateIndex(
                name: "IX_Items_TypeName",
                table: "Items",
                column: "TypeName");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_ItemCategory_Category",
                table: "Items",
                column: "Category",
                principalTable: "ItemCategory",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_ItemType_TypeName",
                table: "Items",
                column: "TypeName",
                principalTable: "ItemType",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Items_IDProduct",
                table: "Transactions",
                column: "IDProduct",
                principalTable: "Items",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_ApplicationUser_IDuid",
                table: "Transactions",
                column: "IDuid",
                principalTable: "ApplicationUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_ItemCategory_Category",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_ItemType_TypeName",
                table: "Items");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Items_IDProduct",
                table: "Transactions");

            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_ApplicationUser_IDuid",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_IDProduct",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_IDuid",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Items_Category",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_TypeName",
                table: "Items");

            migrationBuilder.AlterColumn<string>(
                name: "IDuid",
                table: "Transactions",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
