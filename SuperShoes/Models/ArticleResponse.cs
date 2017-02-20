namespace SuperShoes.Api.Models
{
    /// <summary>
    /// Class for the article response.
    /// </summary>
    public class ArticleResponse : Response
    {
        /// <summary>
        /// Gets or sets the article.
        /// </summary>
        public Article Article { get; set; }
    }
}