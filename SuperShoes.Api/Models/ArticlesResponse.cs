namespace SuperShoes.Api.Models
{
    using Newtonsoft.Json;
    using SuperShoes.Domain;
    using System.Collections.Generic;

    /// <summary>
    /// Class for the articles response.
    /// </summary>
    public class ArticlesResponse : Response
    {
        /// <summary>
        /// Gets or sets the articles.
        /// </summary>
        [JsonProperty(PropertyName = "articles")]
        public List<Article> Articles { get; set; }

        /// <summary>
        /// Gets or sets the total of elements.
        /// </summary>
        [JsonProperty(PropertyName = "total_elements")]
        public int TotalElements { get; set; }
    }
}