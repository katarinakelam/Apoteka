using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apoteka.Model.Models
{
    public partial class Narudzbenica
    {
        public Narudzbenica()
        {
            NarudzbenicaLijek = new HashSet<NarudzbenicaLijek>();
        }

        [Column("narudzbenicaId")]
        public int NarudzbenicaId { get; set; }
        [Column("datumIVrijemeIzdavanja", TypeName = "datetime")]
        public DateTime? DatumIvrijemeIzdavanja { get; set; }
        [Column("korisnikId")]
        public int? KorisnikId { get; set; }
        [Column("nabavljacId")]
        public int? NabavljacId { get; set; }
        [Column("adresaDostave")]
        [StringLength(200)]
        public string AdresaDostave { get; set; }

        [ForeignKey("KorisnikId")]
        [InverseProperty("Narudzbenica")]
        public Korisnik Korisnik { get; set; }
        [ForeignKey("NabavljacId")]
        [InverseProperty("Narudzbenica")]
        public Nabavljac Nabavljac { get; set; }
        [InverseProperty("Narudzbenica")]
        public ICollection<NarudzbenicaLijek> NarudzbenicaLijek { get; set; }
    }
}
