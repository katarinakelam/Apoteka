using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apoteka.Model.Models
{
    /// <summary>
    /// Klijent database entity
    /// </summary>
    public partial class Klijent
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="Klijent"/> class.
        /// </summary>
        public Klijent()
        {
            Racun = new HashSet<Racun>();
        }

        /// <summary>
        /// Gets or sets the klijent identifier.
        /// </summary>
        /// <value>
        /// The klijent identifier.
        /// </value>
        [Column("klijentId")]
        public int KlijentId { get; set; }

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
        /// Gets or sets the broj zdravstvene iskaznice.
        /// </summary>
        /// <value>
        /// The broj zdravstvene iskaznice.
        /// </value>
        [Column("brojZdravstveneIskaznice")]
        public int? BrojZdravstveneIskaznice { get; set; }

        /// <summary>
        /// Gets or sets the racun.
        /// </summary>
        /// <value>
        /// The racun.
        /// </value>
        [InverseProperty("Klijent")]
        public ICollection<Racun> Racun { get; set; }
    }
}
