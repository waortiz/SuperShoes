namespace SuperShoes.Api.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Class for the stores response.
    /// </summary>
    public class StoresResponse : Response
    {
        /// <summary>
        /// Gets or sets the stores.
        /// </summary>
        public List<Store> Stores { get; set; }

        /// <summary>
        /// Gets or sets the total of elements.
        /// </summary>
        public int TotalElements { get; set; }
    }
}