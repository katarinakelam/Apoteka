using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apoteka.Model.Models
{
    /// <summary>
    /// Nabavljac database entity
    /// </summary>
    public partial class Nabavljac
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Nabavljac"/> class.
        /// </summary>
        public Nabavljac()
        {
            Narudzbenica = new HashSet<Narudzbenica>();
        }

        /// <summary>
        /// Gets or sets the nabavljac identifier.
        /// </summary>
        /// <value>
        /// The nabavljac identifier.
        /// </value>
        [Column("nabavljacId")]
        public int NabavljacId { get; set; }

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
        /// Gets or sets the adresa.
        /// </summary>
        /// <value>
        /// The adresa.
        /// </value>
        [Column("adresa")]
        [StringLength(200)]
        public string Adresa { get; set; }

        /// <summary>
        /// Gets or sets the iban.
        /// </summary>
        /// <value>
        /// The iban.
        /// </value>
        [Column("IBAN")]
        [StringLength(50)]
        public string Iban { get; set; }

        /// <summary>
        /// Gets or sets the narudzbenica.
        /// </summary>
        /// <value>
        /// The narudzbenica.
        /// </value>
        [InverseProperty("Nabavljac")]
        public ICollection<Narudzbenica> Narudzbenica { get; set; }
    }
}
