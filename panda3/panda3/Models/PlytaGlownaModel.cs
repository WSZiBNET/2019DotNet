using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace panda3.Models
{
    [Table("PlytaGlowna")]
    public class PlytaGlownaModel
    {
        [Key]
        public int PlytaGlownaId { get; set; }
        public string Nazwa { get; set; }
    }
}
