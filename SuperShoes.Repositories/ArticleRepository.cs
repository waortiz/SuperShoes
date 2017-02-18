namespace SuperShoes.Repositories
{
    using Exceptions;
    using SuperShoes.Domain;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Class for managing the repository of the article
    /// </summary>
    public class ArticleRepository : BaseRepository, IArticleRepository
    {
        /// <summary>
        /// Constructor of the class.
        /// </summary>
        /// <param name="superShoesContext">Context for database operations</param>
        public ArticleRepository(SuperShoesContext superShoesContext) : base(superShoesContext)
        {

        }

        /// <summary>
        /// Get all the articles stored.
        /// </summary>
        /// <returns>List of the articles.</returns>
        public List<Article> GetArticles()
        {
            return superShoesContext.Articles.ToList();
        }
        
        /// <summary>
        /// Get all the articles of the one store.
        /// </summary>
        /// <param name="storeId">Id of the store.</param>
        /// <returns>List the articles of the one store.</returns>
        public List<Article> GetArticles(int storeId)
        {
            return superShoesContext.Articles.Where(a=>a.Store.StoreId == storeId).ToList();
        }

        /// <summary>
        /// Get an article.
        /// </summary>
        /// <param name="articleId">Id of the article to get.</param>
        /// <returns>An article.</returns>
        public Article GetArticle(int articleId)
        {
            var current = superShoesContext.Articles.Find(articleId);
            if (current == null)
            {
                throw new RecordNotFoudException(string.Format("Article {0} not found", articleId));
            }

            return current;
        }
        
        /// <summary>
        /// Save an article.
        /// </summary>
        /// <param name="article">Article to save.</param>
        public void SaveArticle(Article article)
        {
            superShoesContext.Articles.Add(article);
            superShoesContext.SaveChanges();
        }

        /// <summary>
        /// Update an article.
        /// </summary>
        /// <param name="article">Article to update.</param>
        public void UpdateArticle(Article article)
        {
            var current = superShoesContext.Articles.Find(article.ArticleId);
            if (current != null)
            {
                current.Description = article.Description;
                current.Name = article.Name;
                current.Price = article.Price;
                current.TotalInShelf = article.TotalInShelf;
                current.TotalInVault = article.TotalInVault;
            }
            else
            {
                throw new RecordNotFoudException(string.Format("Article {0} not found", article.ArticleId));
            }
            
            superShoesContext.SaveChanges();
        }

        /// <summary>
        /// Delete an article.
        /// </summary>
        /// <param name="articleId">Id of the article to delete.</param>
        public void DeleteArticle(int articleId)
        {
            var current = superShoesContext.Articles.Find(articleId);
            if (current != null)
            {
                superShoesContext.Articles.Remove(current);
            }
            else
            {
                throw new RecordNotFoudException(string.Format("Article {0} not found", articleId));
            }
        }
    }
}
