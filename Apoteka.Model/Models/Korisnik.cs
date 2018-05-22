using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apoteka.Model.Models
{
    /// <summary>
    /// Korisnik database entity
    /// </summary>
    public partial class Korisnik
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Korisnik"/> class.
        /// </summary>
        public Korisnik()
        {
            Narudzbenica = new HashSet<Narudzbenica>();
            Racun = new HashSet<Racun>();
        }

        /// <summary>
        /// Gets or sets the korisnik identifier.
        /// </summary>
        /// <value>
        /// The korisnik identifier.
        /// </value>
        [Column("korisnikId")]
        public int KorisnikId { get; set; }

        /// <summary>
        /// Gets or sets the IME.
        /// </summary>
        /// <value>
        /// The IME.
        /// </value>
        [Column("ime")]
        [StringLength(50)]
        public string Ime { get; set; }

        /// <summary>
        /// Gets or sets the prezime.
        /// </summary>
        /// <value>
        /// The prezime.
        /// </value>
        [Column("prezime")]
        [StringLength(50)]
        public string Prezime { get; set; }

        /// <summary>
        /// Gets or sets the datum rodjenja.
        /// </summary>
        /// <value>
        /// The datum rodjenja.
        /// </value>
        [Column("datumRodjenja", TypeName = "date")]
        public DateTime? DatumRodjenja { get; set; }

        /// <summary>
        /// Gets or sets the radno mjesto identifier.
        /// </summary>
        /// <value>
        /// The radno mjesto identifier.
        /// </value>
        [Column("radnoMjestoId")]
        public int? RadnoMjestoId { get; set; }

        /// <summary>
        /// Gets or sets the radno mjesto.
        /// </summary>
        /// <value>
        /// The radno mjesto.
        /// </value>
        [ForeignKey("RadnoMjestoId")]
        [InverseProperty("Korisnik")]
        public RadnoMjesto RadnoMjesto { get; set; }

        /// <summary>
        /// Gets or sets the narudzbenica.
        /// </summary>
        /// <value>
        /// The narudzbenica.
        /// </value>
        [InverseProperty("Korisnik")]
        public ICollection<Narudzbenica> Narudzbenica { get; set; }

        /// <summary>
        /// Gets or sets the racun.
        /// </summary>
        /// <value>
        /// The racun.
        /// </value>
        [InverseProperty("Korisnik")]
        public ICollection<Racun> Racun { get; set; }
    }
}
