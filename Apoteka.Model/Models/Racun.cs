using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apoteka.Model.Models
{
    /// <summary>
    /// Racun database entity
    /// </summary>
    public partial class Racun
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Racun"/> class.
        /// </summary>
        public Racun()
        {
            RacunLijek = new HashSet<RacunLijek>();
        }

        /// <summary>
        /// Gets or sets the racun identifier.
        /// </summary>
        /// <value>
        /// The racun identifier.
        /// </value>
        [Column("racunId")]
        public int RacunId { get; set; }

        /// <summary>
        /// Gets or sets the datum ivrijeme izdavanja.
        /// </summary>
        /// <value>
        /// The datum ivrijeme izdavanja.
        /// </value>
        [Column("datumIVrijemeIzdavanja", TypeName = "datetime")]
        public DateTime? DatumIvrijemeIzdavanja { get; set; }

        /// <summary>
        /// Gets or sets the klijent identifier.
        /// </summary>
        /// <value>
        /// The klijent identifier.
        /// </value>
        [Column("klijentId")]
        public int? KlijentId { get; set; }

        /// <summary>
        /// Gets or sets the korisnik identifier.
        /// </summary>
        /// <value>
        /// The korisnik identifier.
        /// </value>
        [Column("korisnikId")]
        public int? KorisnikId { get; set; }

        /// <summary>
        /// Gets or sets the klijent.
        /// </summary>
        /// <value>
        /// The klijent.
        /// </value>
        [ForeignKey("KlijentId")]
        [InverseProperty("Racun")]
        public Klijent Klijent { get; set; }

        /// <summary>
        /// Gets or sets the korisnik.
        /// </summary>
        /// <value>
        /// The korisnik.
        /// </value>
        [ForeignKey("KorisnikId")]
        [InverseProperty("Racun")]
        public Korisnik Korisnik { get; set; }

        /// <summary>
        /// Gets or sets the racun lijek.
        /// </summary>
        /// <value>
        /// The racun lijek.
        /// </value>
        [InverseProperty("Racun")]
        public ICollection<RacunLijek> RacunLijek { get; set; }
    }
}
