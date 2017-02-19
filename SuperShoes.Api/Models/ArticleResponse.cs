namespace SuperShoes.Api.Models
{
    using Newtonsoft.Json;
    using SuperShoes.Domain;

    /// <summary>
    /// Class for the article response.
    /// </summary>
    public class ArticleResponse : Response
    {
        /// <summary>
        /// Gets or sets the article.
        /// </summary>
        [JsonProperty(PropertyName = "article")]
        public Article Article { get; set; }
    }
}