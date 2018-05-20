using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apoteka.Model.Models
{
    public partial class RacunLijek
    {
        [Column("racunId")]
        public int RacunId { get; set; }
        [Column("lijekId")]
        public int LijekId { get; set; }
        [Column("kolicina")]
        public int? Kolicina { get; set; }

        [ForeignKey("LijekId")]
        [InverseProperty("RacunLijek")]
        public Lijek Lijek { get; set; }
        [ForeignKey("RacunId")]
        [InverseProperty("RacunLijek")]
        public Racun Racun { get; set; }
    }
}
