using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;
using Newtonsoft.Json;

namespace Apoteka.ViewModels
{
    /// <summary>
    /// Klijent view model
    /// </summary>
    public class KlijentVM
    {
        /// <summary>
        /// Gets or sets the klijent identifier.
        /// </summary>
        /// <value>
        /// The klijent identifier.
        /// </value>
        [JsonIgnore]
        public int KlijentId { get; set; }

        /// <summary>
        /// Gets or sets the IME.
        /// </summary>
        /// <value>
        /// The IME.
        /// </value>
        [Required(ErrorMessage = "Potrebno je unijeti ime klijenta")]
        public string Ime { get; set; }

        /// <summary>
        /// Gets or sets the prezime.
        /// </summary>
        /// <value>
        /// The prezime.
        /// </value>
        [Required(ErrorMessage = "Potrebno je unijeti prezime klijenta")]
        public string Prezime { get; set; }

        /// <summary>
        /// Gets or sets the datum rodjenja.
        /// </summary>
        /// <value>
        /// The datum rodjenja.
        /// </value>
        [Required(ErrorMessage = "Potrebno je unijeti datum rođenja")]
        [DisplayName("Datum rođenja")]
        public DateTime DatumRodjenja { get; set; }

        /// <summary>
        /// Gets or sets the broj zdravstvene iskaznice.
        /// </summary>
        /// <value>
        /// The broj zdravstvene iskaznice.
        /// </value>
        [Required(ErrorMessage = "Potrebno je unijeti broj zdravstvene iskaznice")]
        [DisplayName("Broj zdravstvene iskaznice")]
        public int BrojZdravstveneIskaznice { get; set; }
    }
}