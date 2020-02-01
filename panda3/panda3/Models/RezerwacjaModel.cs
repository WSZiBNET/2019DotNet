using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace panda3.Models
{
    [Table ("Rezerwacja")]
    public class Rezerwacja
    {
        [Key]
        public int RezerwacjaID { get; set; }
        [ForeignKey("KomputerID")]
        public int KomputerID { get; set; }
        [ForeignKey("UzytkownikID")]
        public int UzytkownikID { get; set; }
        public DateTime DataRozpoczecia { get; set; }
        public DateTime DataZakonczenia { get; set; }
        public DateTime DataPrzedluzona { get; set; }

    }
}
