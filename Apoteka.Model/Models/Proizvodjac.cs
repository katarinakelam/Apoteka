using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apoteka.Model.Models
{
    /// <summary>
    /// Proizvodjac database entity
    /// </summary>
    public partial class Proizvodjac
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Proizvodjac"/> class.
        /// </summary>
        public Proizvodjac()
        {
            Lijek = new HashSet<Lijek>();
        }

        /// <summary>
        /// Gets or sets the proizvodjac identifier.
        /// </summary>
        /// <value>
        /// The proizvodjac identifier.
        /// </value>
        [Column("proizvodjacId")]
        public int ProizvodjacId { get; set; }

        /// <summary>
        /// Gets or sets the naziv.
        /// </summary>
        /// <value>
        /// The naziv.
        /// </value>
        [Column("naziv")]
        [StringLength(100)]
        public string Naziv { get; set; }

        /// <summary>
        /// Gets or sets the adresa.
        /// </summary>
        /// <value>
        /// The adresa.
        /// </value>
        [Column("adresa")]
        [StringLength(100)]
        public string Adresa { get; set; }

        /// <summary>
        /// Gets or sets the lijek.
        /// </summary>
        /// <value>
        /// The lijek.
        /// </value>
        [InverseProperty("Proizvodjac")]
        public ICollection<Lijek> Lijek { get; set; }
    }
}
