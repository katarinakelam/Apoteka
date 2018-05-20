using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apoteka.Model.Models
{
    public partial class NarudzbenicaLijek
    {
        [Column("narudzbenicaId")]
        public int NarudzbenicaId { get; set; }
        [Column("lijekId")]
        public int LijekId { get; set; }
        [Column("kolicina", TypeName = "nchar(10)")]
        public string Kolicina { get; set; }

        [ForeignKey("LijekId")]
        [InverseProperty("NarudzbenicaLijek")]
        public Lijek Lijek { get; set; }
        [ForeignKey("NarudzbenicaId")]
        [InverseProperty("NarudzbenicaLijek")]
        public Narudzbenica Narudzbenica { get; set; }
    }
}
