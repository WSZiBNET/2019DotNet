using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CarRent.Models
{
    [Table("Orders")]
    public class OrdersModel
    {
        [Key]
        public int IdOrder { get; set; }
        [ForeignKey("Clients")]
        public int IdClient  { get; set; }
        [ForeignKey("Cars")]
        public int IdCar { get; set; }
        public Decimal Price { get; set; }
        public DateTime OrderDateFrom { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime PayDate { get; set; }
        public byte Score { get; set; }

        public virtual CarsModel Cars { get; set; }
        public virtual ClientModel Clients { get; set; }

    }
}
