using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Apoteka.DTO
{
    /// <summary>
    /// Lijek view model
    /// </summary>
    public class LijekDTO
    {
        /// <summary>
        /// Gets or sets the lijek identifier.
        /// </summary>
        /// <value>
        /// The lijek identifier.
        /// </value>
        [JsonIgnore]
        public int LijekId { get; set; }

        /// <summary>
        /// Gets or sets the trgovacko IME.
        /// </summary>
        /// <value>
        /// The trgovacko IME.
        /// </value>
        [DisplayName("Trgovacko ime")]
        [Required(ErrorMessage = "Potrebno je unijeti trgovačko ime lijeka")]
        public string TrgovackoIme { get; set; }

        /// <summary>
        /// Gets or sets the farmaceutsko IME.
        /// </summary>
        /// <value>
        /// The farmaceutsko IME.
        /// </value>
        [DisplayName("Farmaceutsko ime")]
        [Required(ErrorMessage = "Potrebno je unijeti farmaceutsko ime lijeka")]
        public string FarmaceutskoIme { get; set; }

        /// <summary>
        /// Gets or sets the jacina.
        /// </summary>
        /// <value>
        /// The jacina.
        /// </value>
        [Required(ErrorMessage = "Potrebno je unijeti jačinu lijeka")]
        public string Jacina { get; set; }

        /// <summary>
        /// Gets or sets the cijena.
        /// </summary>
        /// <value>
        /// The cijena.
        /// </value>
        [Required(ErrorMessage = "Potrebno je unijeti cijenu lijeka")]
        public double Cijena { get; set; }

        /// <summary>
        /// Gets or sets the referenca uputa.
        /// </summary>
        /// <value>
        /// The referenca uputa.
        /// </value>
        [DisplayName("Referenca na uputu")]
        public string ReferencaUputa { get; set; }

        /// <summary>
        /// Gets or sets the kolicina.
        /// </summary>
        /// <value>
        /// The kolicina.
        /// </value>
        [Required(ErrorMessage = "Potrebno je unijeti količinu lijeka")]
        [DisplayName("Količina")]
        public int Kolicina { get; set; }

        /// <summary>
        /// Gets or sets the name of the proizvodjac.
        /// </summary>
        /// <value>
        /// The name of the proizvodjac.
        /// </value>
        [DisplayName("Naziv proizvođača")]
        [Required(ErrorMessage = "Potrebno je unijeti naziv proizvođača")]
        public string ProizvodjacNaziv { get; set; }
    }
}