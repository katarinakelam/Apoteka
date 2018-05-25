using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace Apoteka.ViewModels
{
    /// <summary>
    /// Proizvodjac view model
    /// </summary>
    public class ProizvodjacVM
    {
        /// <summary>
        /// Gets or sets the naziv.
        /// </summary>
        /// <value>
        /// The naziv.
        /// </value>
        [Required(ErrorMessage = "Potrebno je unijeti naziv proizvođača")]
        public string Naziv { get; set; }

        /// <summary>
        /// Gets or sets the adresa.
        /// </summary>
        /// <value>
        /// The adresa.
        /// </value>
        [Required(ErrorMessage = "Potrebno je unijeti adresu proizvođača")]
        public string Adresa { get; set; }
    }
}