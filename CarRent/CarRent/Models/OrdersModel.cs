using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.Models
{
    public class OrdersModel
    {
        [Key]
        public int IdOrder { get; set; }
        public int IdClient  { get; set; }
        public int IdCar { get; set; }
        public Decimal Price { get; set; }
        public DateTime OrderDateFrom { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime PayDate { get; set; }
        public byte Score { get; set; }

    }
}
