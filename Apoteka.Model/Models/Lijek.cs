using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apoteka.Model.Models
{
    public partial class Lijek
    {
        public Lijek()
        {
            NarudzbenicaLijek = new HashSet<NarudzbenicaLijek>();
            RacunLijek = new HashSet<RacunLijek>();
        }

        [Column("lijekId")]
        public int LijekId { get; set; }
        [Column("trgovackoIme")]
        [StringLength(100)]
        public string TrgovackoIme { get; set; }
        [Column("farmaceutskoIme")]
        [StringLength(100)]
        public string FarmaceutskoIme { get; set; }
        [Column("jacina")]
        [StringLength(50)]
        public string Jacina { get; set; }
        [Column("cijena")]
        public double? Cijena { get; set; }
        [Column("referencaUputa")]
        [StringLength(200)]
        public string ReferencaUputa { get; set; }
        [Column("kolicina")]
        public int? Kolicina { get; set; }
        [Column("proizvodjacId")]
        public int? ProizvodjacId { get; set; }

        [ForeignKey("ProizvodjacId")]
        [InverseProperty("Lijek")]
        public Proizvodjac Proizvodjac { get; set; }
        [InverseProperty("Lijek")]
        public ICollection<NarudzbenicaLijek> NarudzbenicaLijek { get; set; }
        [InverseProperty("Lijek")]
        public ICollection<RacunLijek> RacunLijek { get; set; }
    }
}
