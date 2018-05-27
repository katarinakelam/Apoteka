using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Apoteka.DTO
{
    /// <summary>
    /// Racun view model
    /// </summary>
    public class RacunDTO
    {
        /// <summary>
        /// Gets or sets the racun identifier.
        /// </summary>
        /// <value>
        /// The racun identifier.
        /// </value>
        [JsonIgnore]
        public int RacunId { get; set; }

        /// <summary>
        /// Gets or sets the datum ivrijeme izdavanja.
        /// </summary>
        /// <value>
        /// The datum ivrijeme izdavanja.
        /// </value>
        [Required(ErrorMessage = "Potrebno je unijeti datum i vrijeme izdavanja")]
        [DisplayName("Datum i vrijeme izdavanja")]
        public DateTime DatumIvrijemeIzdavanja { get; set; }

        /// <summary>
        /// Gets or sets the korisnik.
        /// </summary>
        /// <value>
        /// The korisnik.
        /// </value>
        [Required(ErrorMessage = "Potrebno je unijeti korisnika")]
        [DisplayName("Korisnik")]
        public string KorisnikNaziv { get; set; }

        /// <summary>
        /// Gets or sets the klijent.
        /// </summary>
        /// <value>
        /// The klijent.
        /// </value>
        [Required(ErrorMessage = "Potrebno je unijeti klijenta")]
        [DisplayName("Klijent")]
        public string KlijentNaziv { get; set; }
    }
}