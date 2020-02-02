using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CarRent.Models
{
    public class ClientModel
    {
        [Key]
        public int IdClient { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public double Discount { get; set; }
    }
}
