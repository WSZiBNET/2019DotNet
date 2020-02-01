﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.Models
{
    public class CarsModel
    {
        [Key]
        public int IdCar { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public int ProductionYear { get; set; }
        public string Package { get; set; }
        public double Combustion { get; set; }
    }
}
