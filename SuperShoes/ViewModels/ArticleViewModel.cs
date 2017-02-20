using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperShoes.ViewModels
{
    public class ArticleViewModel
    {
        /// <summary>
        /// Gets or sets the identifier of the article.
        /// </summary>
        public string ArticleId { get; set; }

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
        public string Price { get; set; }

        /// <summary>
        /// Gets or sets the total in shelf of the article.
        /// </summary>
        public string TotalInShelf { get; set; }

        /// <summary>
        /// Gets or sets the total in vault of the article.
        /// </summary>
        public string TotalInVault { get; set; }

        /// <summary>
        /// Gets or sets the id of the store.
        /// </summary>
        public string StoreId { get; set; }

        /// <summary>
        /// Gets or sets the list of stores.
        /// </summary>
        public IEnumerable<SelectListItem> Stores { get; set; }
    }
}