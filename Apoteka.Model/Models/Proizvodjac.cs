using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apoteka.Model.Models
{
    public partial class Proizvodjac
    {
        public Proizvodjac()
        {
            Lijek = new HashSet<Lijek>();
        }

        [Column("proizvodjacId")]
        public int ProizvodjacId { get; set; }
        [Column("naziv")]
        [StringLength(100)]
        public string Naziv { get; set; }
        [Column("adresa")]
        [StringLength(100)]
        public string Adresa { get; set; }

        [InverseProperty("Proizvodjac")]
        public ICollection<Lijek> Lijek { get; set; }
    }
}
