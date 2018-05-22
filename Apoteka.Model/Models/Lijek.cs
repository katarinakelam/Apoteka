using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apoteka.Model.Models
{
    /// <summary>
    /// Lijek database entity
    /// </summary>
    public partial class Lijek
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Lijek"/> class.
        /// </summary>
        public Lijek()
        {
            NarudzbenicaLijek = new HashSet<NarudzbenicaLijek>();
            RacunLijek = new HashSet<RacunLijek>();
        }

        /// <summary>
        /// Gets or sets the lijek identifier.
        /// </summary>
        /// <value>
        /// The lijek identifier.
        /// </value>
        [Column("lijekId")]
        public int LijekId { get; set; }

        /// <summary>
        /// Gets or sets the trgovacko IME.
        /// </summary>
        /// <value>
        /// The trgovacko IME.
        /// </value>
        [Column("trgovackoIme")]
        [StringLength(100)]
        public string TrgovackoIme { get; set; }

        /// <summary>
        /// Gets or sets the farmaceutsko IME.
        /// </summary>
        /// <value>
        /// The farmaceutsko IME.
        /// </value>
        [Column("farmaceutskoIme")]
        [StringLength(100)]
        public string FarmaceutskoIme { get; set; }

        /// <summary>
        /// Gets or sets the jacina.
        /// </summary>
        /// <value>
        /// The jacina.
        /// </value>
        [Column("jacina")]
        [StringLength(50)]
        public string Jacina { get; set; }

        /// <summary>
        /// Gets or sets the cijena.
        /// </summary>
        /// <value>
        /// The cijena.
        /// </value>
        [Column("cijena")]
        public double? Cijena { get; set; }

        /// <summary>
        /// Gets or sets the referenca uputa.
        /// </summary>
        /// <value>
        /// The referenca uputa.
        /// </value>
        [Column("referencaUputa")]
        [StringLength(200)]
        public string ReferencaUputa { get; set; }

        /// <summary>
        /// Gets or sets the kolicina.
        /// </summary>
        /// <value>
        /// The kolicina.
        /// </value>
        [Column("kolicina")]
        public int? Kolicina { get; set; }

        /// <summary>
        /// Gets or sets the proizvodjac identifier.
        /// </summary>
        /// <value>
        /// The proizvodjac identifier.
        /// </value>
        [Column("proizvodjacId")]
        public int? ProizvodjacId { get; set; }

        /// <summary>
        /// Gets or sets the proizvodjac.
        /// </summary>
        /// <value>
        /// The proizvodjac.
        /// </value>
        [ForeignKey("ProizvodjacId")]
        [InverseProperty("Lijek")]
        public Proizvodjac Proizvodjac { get; set; }

        /// <summary>
        /// Gets or sets the narudzbenica lijek.
        /// </summary>
        /// <value>
        /// The narudzbenica lijek.
        /// </value>
        [InverseProperty("Lijek")]
        public ICollection<NarudzbenicaLijek> NarudzbenicaLijek { get; set; }

        /// <summary>
        /// Gets or sets the racun lijek.
        /// </summary>
        /// <value>
        /// The racun lijek.
        /// </value>
        [InverseProperty("Lijek")]
        public ICollection<RacunLijek> RacunLijek { get; set; }
    }
}
