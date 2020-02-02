using CarRent.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.Data
{
    public class CarDataContext : DbContext
    {
        public CarDataContext(DbContextOptions<CarDataContext> options) : base(options)
        {

        }
        public DbSet<CarsModel> Cars {get; set;}
        public DbSet<CarRent.Models.ClientModel> ClientModel { get; set; }
        public DbSet<CarRent.Models.OrdersModel> OrdersModel { get; set; }
    }
}
