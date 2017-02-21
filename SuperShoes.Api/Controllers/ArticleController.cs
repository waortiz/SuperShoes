namespace SuperShoes.Api.Controllers
{
    using Domain;
    using Filters;
    using Models;
    using Repositories.Exceptions;
    using SuperShoes.Services;
    using System;
    using System.Web.Http;

    [IdentityBasicAuthentication]
    public class ArticleController : ApiController
    {
        /// <summary>
        /// Represents a service for the article.
        /// </summary>
        IArticleService articleService;

        /// <summary>
        /// Constructor of the controller.
        /// </summary>
        /// <param name="articleService">Service for the article.</param>
        public ArticleController(IArticleService articleService)
        {
            this.articleService = articleService;
        }

        // GET services/article
        public ArticlesResponse Get()
        {
            ArticlesResponse response = new ArticlesResponse() { Success = true };
            try
            {
                var articles = articleService.GetArticles();
                response.Articles = articles;
                response.TotalElements = articles.Count;
            }
            catch(Exception exc)
            {
                response.Success = false;
                response.ErrorCode = ((int)ErrorResponse.ServerError).ToString();
                response.ErrorMessage = exc.Message;
            }

            return response;
        }

        // GET services/article/store/id
        [HttpGet]
        [Route("services/article/store/{id:int}")]
        public ArticlesResponse GetStoreArticles(int id)
        {
            ArticlesResponse response = new ArticlesResponse() { Success = true };
            try
            {
                var articles = articleService.GetArticles(id);
                response.Articles = articles;
                response.TotalElements = articles.Count;
            }
            catch (Exception exc)
            {
                response.Success = false;
                response.ErrorCode = ((int)ErrorResponse.ServerError).ToString();
                response.ErrorMessage = exc.Message;
            }

            return response;
        }

        // GET services/article/5
        public ArticleResponse Get(int id)
        {
            ArticleResponse response = new ArticleResponse() { Success = true };
            try
            {
                var article = articleService.GetArticle(id);
                response.Article = article;
            }
            catch (RecordNotFoudException exc)
            {
                response.Success = false;
                response.ErrorCode = ((int)ErrorResponse.RecordNotFound).ToString();
                response.ErrorMessage = exc.Message;
            }
            catch (Exception exc)
            {
                response.Success = false;
                response.ErrorCode = ((int)ErrorResponse.ServerError).ToString();
                response.ErrorMessage = exc.Message;
            }

            return response;
        }

        // POST services/article
        public Response Post(Article article)
        {
            Response response = new Response() { Success = true };
            try
            {
                articleService.SaveArticle(article);
            }
            catch (Exception exc)
            {
                response.Success = false;
                response.ErrorCode = ((int)ErrorResponse.ServerError).ToString();
                response.ErrorMessage = exc.Message;
            }

            return response;
        }

        // PUT services/article
        public Response Put(Article article)
        {
            Response response = new Response() { Success = true };
            try
            {
                articleService.UpdateArticle(article);
            }
            catch (RecordNotFoudException exc)
            {
                response.Success = false;
                response.ErrorCode = ((int)ErrorResponse.RecordNotFound).ToString();
                response.ErrorMessage = exc.Message;
            }
            catch (Exception exc)
            {
                response.Success = false;
                response.ErrorCode = ((int)ErrorResponse.ServerError).ToString();
                response.ErrorMessage = exc.Message;
            }

            return response;
        }

        // DELETE services/article/5

        public Response Delete(int id)
        {
            Response response = new Response() { Success = true };
            try
            {
                articleService.DeleteArticle(id);
            }
            catch(RecordNotFoudException exc)
            {
                response.Success = false;
                response.ErrorCode = ((int)ErrorResponse.RecordNotFound).ToString();
                response.ErrorMessage = exc.Message;
            }
            catch (Exception exc)
            {
                response.Success = false;
                response.ErrorCode = ((int)ErrorResponse.ServerError).ToString();
                response.ErrorMessage = exc.Message;
            }

            return response;
        }
    }
}