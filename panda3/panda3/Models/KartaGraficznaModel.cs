using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace panda3.Models
{
    [Table("KartaGraficzna")]
    public class KartaGraficznaModel
    {
        [Key]
        public int ProcesorID { get; set; }
        public string Nazwa { get; set; }
    }
}
