namespace SuperShoes.Api.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Class for the articles response.
    /// </summary>
    public class ArticlesResponse : Response
    {
        /// <summary>
        /// Gets or sets the articles.
        /// </summary>
        public List<Article> Articles { get; set; }

        /// <summary>
        /// Gets or sets the total of elements.
        /// </summary>
        public int TotalElements { get; set; }
    }
}