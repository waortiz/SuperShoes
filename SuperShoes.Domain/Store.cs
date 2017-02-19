namespace SuperShoes.Domain
{
    using Newtonsoft.Json;
    using System.Collections.Generic;

    /// <summary>
    /// Information of the store.
    /// </summary>
    public class Store
    {
        /// <summary>
        /// Gets or sets the identifier of the store.
        /// </summary>
        [JsonProperty(PropertyName = "storeId")]
        public int StoreId { get; set; }

        /// <summary>
        /// Gets or sets the name of the store.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the address of the store.
        /// </summary>
        [JsonProperty(PropertyName = "address")]
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the address of the store.
        [JsonProperty(PropertyName = "articles")]
        public virtual ICollection<Article> Articles { get; set; }
    }
}