using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.Models
{
    public class CarModel
    {
        public int IdCar { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public int ProductionYear  { get; set; }
        public string Package { get; set; }
        public double Combustion { get; set; }

        public CarModel()
        {

        }

        public CarModel(int idCar, string brand, string type, int productionYear, string package, double combustion)
        {
            IdCar = idCar;
            Brand = brand;
            Type = type;
            ProductionYear = productionYear;
            Package = package;
            Combustion = combustion;

        }

    }
}
