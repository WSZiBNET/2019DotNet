using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace panda3.Models
{
    [Table("Komputer")]
    public class KomputerModel
    {
        [Key]
        public int KomputerID { get; set; }
        public string Model { get; set; }
        public string Producent { get; set; }
        public decimal Cena { get; set; }
        public DateTime DataProdukcji { get; set; }
        [ForeignKey("KartaGraficzna")]
        public int KartagraficznaID { get; set; }
        [ForeignKey("Procesor")]
        public int ProcesorID { get; set; }
        [ForeignKey("PlytaGlowna")]
        public int PlytaglownaID { get; set; }
    }
}
