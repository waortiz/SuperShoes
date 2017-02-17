namespace SuperShoes.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Information of the article.
    /// </summary>
    public class Article
    {
        /// <summary>
        /// Gets or sets the identifier of the article.
        /// </summary>
        public int IdArticle { get; set; }

        /// <summary>
        /// Gets or sets the name of the article.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the article.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the price of the article.
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// Gets or sets the total in shelf of the article.
        /// </summary>
        public int TotalInShelf { get; set; }

        /// <summary>
        /// Gets or sets the total in vault of the article.
        /// </summary>
        public double TotalInVault { get; set; }

        /// <summary>
        /// Gets or sets the store of the article.
        /// </summary>
        public virtual Store Store { get; set; }
    }
}