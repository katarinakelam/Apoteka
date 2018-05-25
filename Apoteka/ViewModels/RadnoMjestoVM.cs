using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Apoteka.ViewModels
{
    /// <summary>
    /// Radno mjesto view model
    /// </summary>
    public class RadnoMjestoVM
    {
        /// <summary>
        /// Gets or sets the naziv.
        /// </summary>
        /// <value>
        /// The naziv.
        /// </value>
        [Required(ErrorMessage = "Potrebno je unijeti naziv radnog mjesta")]
        public string Naziv { get; set; }

        /// <summary>
        /// Gets or sets the ovlast narucivanja.
        /// </summary>
        /// <value>
        /// The ovlast narucivanja.
        /// </value>
        [Required(ErrorMessage = "Potrebno je unijeti ovlast naručivanja")]
        public bool OvlastNarucivanja { get; set; }
    }
}