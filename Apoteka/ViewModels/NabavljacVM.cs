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
    /// Nabavljac view model
    /// </summary>
    public class NabavljacVM
    {
        /// <summary>
        /// Gets or sets the nabavljac identifier.
        /// </summary>
        /// <value>
        /// The nabavljac identifier.
        /// </value>
        [JsonIgnore]
        public int NabavljacId { get; set; }

        /// <summary>
        /// Gets or sets the naziv.
        /// </summary>
        /// <value>
        /// The naziv.
        /// </value>
        [Required(ErrorMessage = "Potrebno je unijeti naziv nabavljača")]
        public string Naziv { get; set; }

        /// <summary>
        /// Gets or sets the adresa.
        /// </summary>
        /// <value>
        /// The adresa.
        /// </value>
        [Required(ErrorMessage = "Potrebno je unijeti adresu nabavljača")]
        public string Adresa { get; set; }

        /// <summary>
        /// Gets or sets the iban.
        /// </summary>
        /// <value>
        /// The iban.
        /// </value>
        [Required(ErrorMessage = "Potrebno je unijeti IBAN nabavljača")]
        [DisplayName("IBAN")]
        public string Iban { get; set; }
    }
}