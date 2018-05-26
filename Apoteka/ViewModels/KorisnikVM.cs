using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Apoteka.ViewModels
{
    /// <summary>
    /// Korisnik view model
    /// </summary>
    public class KorisnikVM
    {
        /// <summary>
        /// Gets or sets the korisnik identifier.
        /// </summary>
        /// <value>
        /// The korisnik identifier.
        /// </value>
        [JsonIgnore]
        public int KorisnikId { get; set; }

        /// <summary>
        /// Gets or sets the IME.
        /// </summary>
        /// <value>
        /// The IME.
        /// </value>
        [Required(ErrorMessage = "Potrebno je unijeti ime korisnika")]
        public string Ime { get; set; }

        /// <summary>
        /// Gets or sets the prezime.
        /// </summary>
        /// <value>
        /// The prezime.
        /// </value>
        [Required(ErrorMessage = "Potrebno je unijeti prezime korisnika")]
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
        /// Gets or sets the radno mjesto.
        /// </summary>
        /// <value>
        /// The radno mjesto.
        /// </value>
        [Required(ErrorMessage = "Potrebno je unijeti naziv radnog mjesta")]
        [DisplayName("Radno mjesto")]
        public string RadnoMjestoNaziv { get; set; }
    }
}