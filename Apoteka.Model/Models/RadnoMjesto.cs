using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apoteka.Model.Models
{
    /// <summary>
    /// Radno mjesto database entity
    /// </summary>
    public partial class RadnoMjesto
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RadnoMjesto"/> class.
        /// </summary>
        public RadnoMjesto()
        {
            Korisnik = new HashSet<Korisnik>();
        }

        /// <summary>
        /// Gets or sets the radno mjesto identifier.
        /// </summary>
        /// <value>
        /// The radno mjesto identifier.
        /// </value>
        [Column("radnoMjestoId")]
        public int RadnoMjestoId { get; set; }

        /// <summary>
        /// Gets or sets the naziv.
        /// </summary>
        /// <value>
        /// The naziv.
        /// </value>
        [Column("naziv")]
        [StringLength(50)]
        public string Naziv { get; set; }

        /// <summary>
        /// Gets or sets the ovlast narucivanja.
        /// </summary>
        /// <value>
        /// The ovlast narucivanja.
        /// </value>
        [Column("ovlastNarucivanja")]
        public bool? OvlastNarucivanja { get; set; }

        /// <summary>
        /// Gets or sets the korisnik.
        /// </summary>
        /// <value>
        /// The korisnik.
        /// </value>
        [InverseProperty("RadnoMjesto")]
        public ICollection<Korisnik> Korisnik { get; set; }
    }
}
