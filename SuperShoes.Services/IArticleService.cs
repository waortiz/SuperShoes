﻿namespace SuperShoes.Services
{
    using SuperShoes.Domain;
    using System.Collections.Generic;

    /// <summary>
    /// Information of the article repository interface.
    /// </summary>
    public interface IArticleService
    {
        /// <summary>
        /// Get all the articles stored.
        /// </summary>
        /// <returns>List of the articles.</returns>
        List<Article> GetArticles();

        /// <summary>
        /// Get an article.
        /// </summary>
        /// <param name="articleId">Id of the article to get.</param>
        /// <returns>An article.</returns>
        Article GetArticle(int articleId);

        /// <summary>
        /// Get all the articles of the one store.
        /// </summary>
        /// <param name="storeId">Id of the store.</param>
        /// <returns>List the articles of the one store.</returns>
        List<Article> GetArticles(int storeId);

        /// <summary>
        /// Save an article.
        /// </summary>
        /// <param name="article">Article to save.</param>
        void SaveArticle(Article article);

        /// <summary>
        /// Update an article.
        /// </summary>
        /// <param name="article">Article to update.</param>
        void UpdateArticle(Article article);

        /// <summary>
        /// Delete an article.
        /// </summary>
        /// <param name="articleId">Id of the article to delete.</param>
        void DeleteArticle(int articleId);
    }
}
