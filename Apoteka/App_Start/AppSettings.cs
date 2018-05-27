using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Apoteka
{
    /// <summary>
    /// Application settings class
    /// </summary>
    public class AppSettings
    {
        /// <summary>
        /// Gets or sets the size of the page.
        /// </summary>
        /// <value>
        /// The size of the page.
        /// </value>
        public int PageSize { get; set; } = 50;

        /// <summary>
        /// Gets or sets the page offset.
        /// </summary>
        /// <value>
        /// The page offset.
        /// </value>
        public int PageOffset { get; set; } = 50;
    }
}
