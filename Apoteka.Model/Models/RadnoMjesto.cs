using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apoteka.Model.Models
{
    public partial class RadnoMjesto
    {
        public RadnoMjesto()
        {
            Korisnik = new HashSet<Korisnik>();
        }

        [Column("radnoMjestoId")]
        public int RadnoMjestoId { get; set; }
        [Column("naziv")]
        [StringLength(50)]
        public string Naziv { get; set; }
        [Column("ovlastNarucivanja")]
        public bool? OvlastNarucivanja { get; set; }

        [InverseProperty("RadnoMjesto")]
        public ICollection<Korisnik> Korisnik { get; set; }
    }
}
