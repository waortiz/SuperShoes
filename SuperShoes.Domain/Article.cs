namespace SuperShoes.Domain
{
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Information of the article.
    /// </summary>
    public class Article
    {
        /// <summary>
        /// Gets or sets the identifier of the article.
        /// </summary>
        [JsonProperty(PropertyName = "articleId")]
        public int ArticleId { get; set; }

        /// <summary>
        /// Gets or sets the name of the article.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the article.
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the price of the article.
        /// </summary>
        [JsonProperty(PropertyName = "price")]
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the total in shelf of the article.
        /// </summary>
        [JsonProperty(PropertyName = "total_in_shelf")]
        public int TotalInShelf { get; set; }

        /// <summary>
        /// Gets or sets the total in vault of the article.
        /// </summary>
        [JsonProperty(PropertyName = "total_in_vault")]
        public decimal TotalInVault { get; set; }

        /// <summary>
        /// Gets or sets the store of the article.
        /// </summary>
        [JsonProperty(PropertyName = "store")]
        public virtual Store Store { get; set; }

        /// <summary>
        /// gets or sets the store name.
        /// </summary>
        [JsonProperty(PropertyName = "store_name")]
        [NotMapped]
        public string StoreName { get; set; }
    }
}