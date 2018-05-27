using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Apoteka.ViewModels
{
    /// <summary>
    /// Narudzbenica view model
    /// </summary>
    public class NarudzbenicaDTO
    {
        /// <summary>
        /// Gets or sets the narudzbenica identifier.
        /// </summary>
        /// <value>
        /// The narudzbenica identifier.
        /// </value>
        [JsonIgnore]
        public int NarudzbenicaId { get; set; }

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
        /// Gets or sets the adresa dostave.
        /// </summary>
        /// <value>
        /// The adresa dostave.
        /// </value>
        [Required(ErrorMessage = "Potrebno je unijeti adresu dostave")]
        [DisplayName("Adresa dostave")]
        public string AdresaDostave { get; set; }

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
        /// Gets or sets the nabavljac.
        /// </summary>
        /// <value>
        /// The nabavljac.
        /// </value>
        [Required(ErrorMessage = "Potrebno je unijeti nabavljača")]
        [DisplayName("Nabavljač")]
        public string NabavljacNaziv { get; set; }
    }
}