using Apoteka.BLL.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apoteka.ViewModels
{
    /// <summary>
    /// Klijent view model
    /// </summary>
    public class KlijentVM
    {
        /// <summary>
        /// Gets or sets the klijenti.
        /// </summary>
        /// <value>
        /// The klijenti.
        /// </value>
        public List<KlijentDTO> Klijenti { get; set; }

        /// <summary>
        /// Gets or sets the paging information.
        /// </summary>
        /// <value>
        /// The paging information.
        /// </value>
        public PagingInfo PagingInfo { get; set; }
    }
}