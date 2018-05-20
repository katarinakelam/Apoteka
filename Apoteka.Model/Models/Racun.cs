using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apoteka.Model.Models
{
    public partial class Racun
    {
        public Racun()
        {
            RacunLijek = new HashSet<RacunLijek>();
        }

        [Column("racunId")]
        public int RacunId { get; set; }
        [Column("datumIVrijemeIzdavanja", TypeName = "datetime")]
        public DateTime? DatumIvrijemeIzdavanja { get; set; }
        [Column("klijentId")]
        public int? KlijentId { get; set; }
        [Column("korisnikId")]
        public int? KorisnikId { get; set; }

        [ForeignKey("KlijentId")]
        [InverseProperty("Racun")]
        public Klijent Klijent { get; set; }
        [ForeignKey("KorisnikId")]
        [InverseProperty("Racun")]
        public Korisnik Korisnik { get; set; }
        [InverseProperty("Racun")]
        public ICollection<RacunLijek> RacunLijek { get; set; }
    }
}
