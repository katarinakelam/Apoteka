using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apoteka.Model.Models
{
    public partial class Nabavljac
    {
        public Nabavljac()
        {
            Narudzbenica = new HashSet<Narudzbenica>();
        }

        [Column("nabavljacId")]
        public int NabavljacId { get; set; }
        [Column("naziv")]
        [StringLength(50)]
        public string Naziv { get; set; }
        [Column("adresa")]
        [StringLength(200)]
        public string Adresa { get; set; }
        [Column("IBAN")]
        [StringLength(50)]
        public string Iban { get; set; }

        [InverseProperty("Nabavljac")]
        public ICollection<Narudzbenica> Narudzbenica { get; set; }
    }
}
