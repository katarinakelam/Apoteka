using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apoteka.Model.Models
{
    public partial class Klijent
    {
        public Klijent()
        {
            Racun = new HashSet<Racun>();
        }

        [Column("klijentId")]
        public int KlijentId { get; set; }
        [Column("ime")]
        [StringLength(50)]
        public string Ime { get; set; }
        [Column("prezime")]
        [StringLength(50)]
        public string Prezime { get; set; }
        [Column("datumRodjenja", TypeName = "date")]
        public DateTime? DatumRodjenja { get; set; }
        [Column("brojZdravstveneIskaznice")]
        public int? BrojZdravstveneIskaznice { get; set; }

        [InverseProperty("Klijent")]
        public ICollection<Racun> Racun { get; set; }
    }
}
