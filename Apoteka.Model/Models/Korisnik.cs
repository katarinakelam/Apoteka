using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apoteka.Model.Models
{
    public partial class Korisnik
    {
        public Korisnik()
        {
            Narudzbenica = new HashSet<Narudzbenica>();
            Racun = new HashSet<Racun>();
        }

        [Column("korisnikId")]
        public int KorisnikId { get; set; }
        [Column("ime")]
        [StringLength(50)]
        public string Ime { get; set; }
        [Column("prezime")]
        [StringLength(50)]
        public string Prezime { get; set; }
        [Column("datumRodjenja", TypeName = "date")]
        public DateTime? DatumRodjenja { get; set; }
        [Column("radnoMjestoId")]
        public int? RadnoMjestoId { get; set; }

        [ForeignKey("RadnoMjestoId")]
        [InverseProperty("Korisnik")]
        public RadnoMjesto RadnoMjesto { get; set; }
        [InverseProperty("Korisnik")]
        public ICollection<Narudzbenica> Narudzbenica { get; set; }
        [InverseProperty("Korisnik")]
        public ICollection<Racun> Racun { get; set; }
    }
}
