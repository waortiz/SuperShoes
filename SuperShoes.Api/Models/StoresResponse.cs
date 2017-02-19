namespace SuperShoes.Api.Models
{
    using Newtonsoft.Json;
    using SuperShoes.Domain;
    using System.Collections.Generic;

    /// <summary>
    /// Class for the stores response.
    /// </summary>
    public class StoresResponse : Response
    {
        /// <summary>
        /// Gets or sets the stores.
        /// </summary>
        [JsonProperty(PropertyName = "stores")]
        public List<Store> Stores { get; set; }

        /// <summary>
        /// Gets or sets the total of elements.
        /// </summary>
        [JsonProperty(PropertyName = "total_elements")]
        public int TotalElements { get; set; }
    }
}