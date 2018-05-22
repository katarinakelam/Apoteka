using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apoteka.Model.Models
{
    /// <summary>
    /// Narudzbenica database entity
    /// </summary>
    public partial class NarudzbenicaLijek
    {
        /// <summary>
        /// Gets or sets the narudzbenica identifier.
        /// </summary>
        /// <value>
        /// The narudzbenica identifier.
        /// </value>
        [Column("narudzbenicaId")]
        public int NarudzbenicaId { get; set; }

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
        [Column("kolicina", TypeName = "nchar(10)")]
        public string Kolicina { get; set; }

        /// <summary>
        /// Gets or sets the lijek.
        /// </summary>
        /// <value>
        /// The lijek.
        /// </value>
        [ForeignKey("LijekId")]
        [InverseProperty("NarudzbenicaLijek")]
        public Lijek Lijek { get; set; }

        /// <summary>
        /// Gets or sets the narudzbenica.
        /// </summary>
        /// <value>
        /// The narudzbenica.
        /// </value>
        [ForeignKey("NarudzbenicaId")]
        [InverseProperty("NarudzbenicaLijek")]
        public Narudzbenica Narudzbenica { get; set; }
    }
}
