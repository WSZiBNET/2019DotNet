using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FirmaBel.Models
{
    [Table("Transactions")]
    public class TransactionModel
    {
        [Key]
        public int ID { get; set; }
        public DateTime TimeStamp { get; set; }
        [ForeignKey("Items")]
        public int IDProduct { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public decimal TotalPrice { get; set; }
        [ForeignKey("AspNetUsers")]
        public string IDuid { get; set; }

        public virtual ItemModel Items { get; set; }
        public virtual  ApplicationUser AspNetUsers { get; set; }
       
    }
}
