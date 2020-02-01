using Microsoft.EntityFrameworkCore;
using panda3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace panda3.Data
{
    public class KomputerDbContext : DbContext
    {
        public KomputerDbContext(DbContextOptions<KomputerDbContext> options) : base(options)
        {

        }

        public DbSet<KomputerModel> Komputer { get; set; }
        public DbSet<KartaGraficznaModel> KartaGraficzna { get; set; }
        public DbSet<PlytaGlownaModel> PlytaGlowna { get; set; }
        public DbSet<ProcesorModel> Procesor { get; set; }
        public DbSet<UzytkownicyModel> Uzytkownicy { get; set; }
        public DbSet<RezerwacjaModel> Rezerwacja { get; set; }
        public DbSet<panda3.Models.RezerwacjaModelNOwy> RezerwacjaModelNOwy { get; set; }
        public DbSet<panda3.Models.OcenaModel> OcenaModel { get; set; }

    }
}
