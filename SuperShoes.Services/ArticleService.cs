namespace SuperShoes.Services
{
    using SuperShoes.Domain;
    using SuperShoes.Repositories;
    using System.Collections.Generic;

    public class ArticleService : IArticleService
    {
        /// <summary>
        /// Represents the repository for the article.
        /// </summary>
        IArticleRepository repository;

        /// <summary>
        /// Constructor of the class.
        /// </summary>
        /// <param name="repository">Repository for the article.</param>
        public ArticleService(IArticleRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Get all the articles stored.
        /// </summary>
        /// <returns>List of the articles.</returns>
        public List<Article> GetArticles()
        {
            return repository.GetArticles();
        }
        
        /// <summary>
        /// Get all the articles of the one store.
        /// </summary>
        /// <param name="storeId">Id of the store.</param>
        /// <returns>List the articles of the one store.</returns>
        public List<Article> GetArticles(int storeId)
        {
            return repository.GetArticles(storeId);
        }

        /// <summary>
        /// Get an article.
        /// </summary>
        /// <param name="articleId">Id of the article to get.</param>
        /// <returns>An article.</returns>
        public Article GetArticle(int articleId)
        {
            return repository.GetArticle(articleId);
        }
        
        /// <summary>
        /// Save an article.
        /// </summary>
        /// <param name="article">Article to save.</param>
        public void SaveArticle(Article article)
        {
            repository.SaveArticle(article);
        }

        /// <summary>
        /// Update an article.
        /// </summary>
        /// <param name="article">Article to update.</param>
        public void UpdateArticle(Article article)
        {
            repository.UpdateArticle(article);
        }

        /// <summary>
        /// Delete an article.
        /// </summary>
        /// <param name="articleId">Id of the article to delete.</param>
        public void DeleteArticle(int articleId)
        {
            repository.DeleteArticle(articleId);
        }
    }
}
