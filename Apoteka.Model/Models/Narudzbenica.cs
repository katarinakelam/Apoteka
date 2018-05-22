using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apoteka.Model.Models
{
    /// <summary>
    /// Narudzbenica database entity
    /// </summary>
    public partial class Narudzbenica
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Narudzbenica"/> class.
        /// </summary>
        public Narudzbenica()
        {
            NarudzbenicaLijek = new HashSet<NarudzbenicaLijek>();
        }

        /// <summary>
        /// Gets or sets the narudzbenica identifier.
        /// </summary>
        /// <value>
        /// The narudzbenica identifier.
        /// </value>
        [Column("narudzbenicaId")]
        public int NarudzbenicaId { get; set; }

        /// <summary>
        /// Gets or sets the datum ivrijeme izdavanja.
        /// </summary>
        /// <value>
        /// The datum ivrijeme izdavanja.
        /// </value>
        [Column("datumIVrijemeIzdavanja", TypeName = "datetime")]
        public DateTime? DatumIvrijemeIzdavanja { get; set; }

        /// <summary>
        /// Gets or sets the korisnik identifier.
        /// </summary>
        /// <value>
        /// The korisnik identifier.
        /// </value>
        [Column("korisnikId")]
        public int? KorisnikId { get; set; }

        /// <summary>
        /// Gets or sets the nabavljac identifier.
        /// </summary>
        /// <value>
        /// The nabavljac identifier.
        /// </value>
        [Column("nabavljacId")]
        public int? NabavljacId { get; set; }

        /// <summary>
        /// Gets or sets the adresa dostave.
        /// </summary>
        /// <value>
        /// The adresa dostave.
        /// </value>
        [Column("adresaDostave")]
        [StringLength(200)]
        public string AdresaDostave { get; set; }

        /// <summary>
        /// Gets or sets the korisnik.
        /// </summary>
        /// <value>
        /// The korisnik.
        /// </value>
        [ForeignKey("KorisnikId")]
        [InverseProperty("Narudzbenica")]
        public Korisnik Korisnik { get; set; }

        /// <summary>
        /// Gets or sets the nabavljac.
        /// </summary>
        /// <value>
        /// The nabavljac.
        /// </value>
        [ForeignKey("NabavljacId")]
        [InverseProperty("Narudzbenica")]
        public Nabavljac Nabavljac { get; set; }

        /// <summary>
        /// Gets or sets the narudzbenica lijek.
        /// </summary>
        /// <value>
        /// The narudzbenica lijek.
        /// </value>
        [InverseProperty("Narudzbenica")]
        public ICollection<NarudzbenicaLijek> NarudzbenicaLijek { get; set; }
    }
}
