using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apoteka.Model.Models
{
    /// <summary>
    /// RacunLijek database entity
    /// </summary>
    public partial class RacunLijek
    {
        /// <summary>
        /// Gets or sets the racun identifier.
        /// </summary>
        /// <value>
        /// The racun identifier.
        /// </value>
        [Column("racunId")]
        public int RacunId { get; set; }

        /// <summary>
        /// Gets or sets the lijek identifier.
        /// </summary>
        /// <value>
        /// The lijek identifier.
        /// </value>
        [Column("lijekId")]
        public int LijekId { get; set; }

        /// <summary>
        /// Gets or sets the kolicina.
        /// </summary>
        /// <value>
        /// The kolicina.
        /// </value>
        [Column("kolicina")]
        public int? Kolicina { get; set; }

        /// <summary>
        /// Gets or sets the lijek.
        /// </summary>
        /// <value>
        /// The lijek.
        /// </value>
        [ForeignKey("LijekId")]
        [InverseProperty("RacunLijek")]
        public Lijek Lijek { get; set; }

        /// <summary>
        /// Gets or sets the racun.
        /// </summary>
        /// <value>
        /// The racun.
        /// </value>
        [ForeignKey("RacunId")]
        [InverseProperty("RacunLijek")]
        public Racun Racun { get; set; }
    }
}
