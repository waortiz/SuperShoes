namespace SuperShoes.Services
{
    using Api.Models;
    using Newtonsoft.Json;
    using RestSharp;
    using System;
    using System.Collections.Generic;
    using System.Configuration;

    public class ArticleService : IArticleService
    {
        /// <summary>
        /// Represents the client rest service for the article.
        /// </summary>
        private RestClient client;

        /// <summary>
        /// Constructor of the class.
        /// </summary>
        public ArticleService()
        {
            this.client = new RestClient() { BaseUrl = new Uri(ConfigurationManager.AppSettings["WebApiBaseUrl"]) };
        }

        /// <summary>
        /// Get all the articles stored.
        /// </summary>
        /// <returns>List of the articles.</returns>
        public List<Article> GetArticles()
        {
            List<Article> articles = new List<Article>();
            RestRequest request = new RestRequest("services/article", Method.GET) { RequestFormat = DataFormat.Json};
            var result = this.client.Execute<ArticlesResponse>(request);
            if(result.Data == null)
            {
                throw new Exception(result.ErrorMessage);
            }
            if(result.Data.Success)
            {
                articles = result.Data.Articles;
            }
            else
            {
                throw new Exception(result.Data.ErrorMessage);
            }

            return articles;
        }
        
        /// <summary>
        /// Get all the articles of the one store.
        /// </summary>
        /// <param name="storeId">Id of the store.</param>
        /// <returns>List the articles of the one store.</returns>
        public List<Article> GetArticles(int storeId)
        {
            List<Article> articles = new List<Article>();
            RestRequest request = new RestRequest("services/article/store/" + storeId, Method.GET) { RequestFormat = DataFormat.Json };
            var result = this.client.Execute<ArticlesResponse>(request);
            if (result.Data == null)
            {
                throw new Exception(result.ErrorMessage);
            }
            if (result.Data.Success)
            {
                articles = result.Data.Articles;
            }
            else
            {
                throw new Exception(result.Data.ErrorMessage);
            }

            return articles;
        }

        /// <summary>
        /// Get an article.
        /// </summary>
        /// <param name="articleId">Id of the article to get.</param>
        /// <returns>An article.</returns>
        public Article GetArticle(int articleId)
        {
            Article article = new Article();
            RestRequest request = new RestRequest("services/article" + articleId, Method.GET) { RequestFormat = DataFormat.Json };
            var result = this.client.Execute<ArticleResponse>(request);
            if (result.Data == null)
            {
                throw new Exception(result.ErrorMessage);
            }
            if (result.Data.Success)
            {
                article = result.Data.Article;
            }
            else
            {
                throw new Exception(result.Data.ErrorMessage);
            }

            return article;
        }
        
        /// <summary>
        /// Save an article.
        /// </summary>
        /// <param name="article">Article to save.</param>
        public void SaveArticle(Article article)
        {
            RestRequest request = new RestRequest("services/article", Method.POST) { RequestFormat = DataFormat.Json };
            var json = JsonConvert.SerializeObject(article);
            request.AddParameter("application/json", json, ParameterType.RequestBody);
            var result = this.client.Execute<Response>(request);
            if (result.Data == null)
            {
                throw new Exception(result.ErrorMessage);
            }
            if (!result.Data.Success)
            {
                throw new Exception(result.Data.ErrorMessage);
            }
        }

        /// <summary>
        /// Update an article.
        /// </summary>
        /// <param name="article">Article to update.</param>
        public void UpdateArticle(Article article)
        {
            RestRequest request = new RestRequest("services/article", Method.PUT) { RequestFormat = DataFormat.Json };
            var json = JsonConvert.SerializeObject(article);
            request.AddParameter("application/json", json, ParameterType.RequestBody);
            var result = this.client.Execute<Response>(request);
            if (result.Data == null)
            {
                throw new Exception(result.ErrorMessage);
            }
            if (!result.Data.Success)
            {
                throw new Exception(result.Data.ErrorMessage);
            }
        }

        /// <summary>
        /// Delete an article.
        /// </summary>
        /// <param name="articleId">Id of the article to delete.</param>
        public void DeleteArticle(int articleId)
        {
            RestRequest request = new RestRequest("services/article" + articleId, Method.DELETE) { RequestFormat = DataFormat.Json };
            var result = this.client.Execute<Response>(request);
            if (result.Data == null)
            {
                throw new Exception(result.ErrorMessage);
            }
            if (!result.Data.Success)
            {
                throw new Exception(result.Data.ErrorMessage);
            }
        }
    }
}
