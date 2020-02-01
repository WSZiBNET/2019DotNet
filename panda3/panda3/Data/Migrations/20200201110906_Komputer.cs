using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace panda3.Data.Migrations
{
    public partial class Komputer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KartaGraficzna",
                columns: table => new
                {
                    ProcesorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nazwa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KartaGraficzna", x => x.ProcesorID);
                });

            migrationBuilder.CreateTable(
                name: "Komputer",
                columns: table => new
                {
                    KomputerID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cena = table.Column<decimal>(nullable: false),
                    DataProdukcji = table.Column<DateTime>(nullable: false),
                    KartagraficznaID = table.Column<int>(nullable: false),
                    Model = table.Column<string>(nullable: true),
                    PlytaglownaID = table.Column<int>(nullable: false),
                    ProcesorID = table.Column<int>(nullable: false),
                    Producent = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Komputer", x => x.KomputerID);
                });

            migrationBuilder.CreateTable(
                name: "PlytaGlowna",
                columns: table => new
                {
                    PlytaGlownaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nazwa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlytaGlowna", x => x.PlytaGlownaId);
                });

            migrationBuilder.CreateTable(
                name: "Procesor",
                columns: table => new
                {
                    ProcesorID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nazwa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Procesor", x => x.ProcesorID);
                });

            migrationBuilder.CreateTable(
                name: "Rezerwacja",
                columns: table => new
                {
                    RezerwacjaID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataPrzedluzona = table.Column<DateTime>(nullable: false),
                    DataRozpoczecia = table.Column<DateTime>(nullable: false),
                    DataZakonczenia = table.Column<DateTime>(nullable: false),
                    KomputerID = table.Column<int>(nullable: false),
                    UzytkownikID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rezerwacja", x => x.RezerwacjaID);
                });

            migrationBuilder.CreateTable(
                name: "Uzytkownicy",
                columns: table => new
                {
                    UzytkownikId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CzyAdmin = table.Column<bool>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Haslo = table.Column<string>(nullable: true),
                    Login = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uzytkownicy", x => x.UzytkownikId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KartaGraficzna");

            migrationBuilder.DropTable(
                name: "Komputer");

            migrationBuilder.DropTable(
                name: "PlytaGlowna");

            migrationBuilder.DropTable(
                name: "Procesor");

            migrationBuilder.DropTable(
                name: "Rezerwacja");

            migrationBuilder.DropTable(
                name: "Uzytkownicy");
        }
    }
}
