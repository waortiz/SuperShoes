namespace SuperShoes.Api.Models
{
    using Newtonsoft.Json;
    using SuperShoes.Domain;

    /// <summary>
    /// Class for the store response.
    /// </summary>
    public class StoreResponse : Response
    {
        /// <summary>
        /// Gets or sets the store.
        /// </summary>
        [JsonProperty(PropertyName = "store")]
        public Store Store { get; set; }
    }
}