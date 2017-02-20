using SuperShoes.Services;
using SuperShoes.Utilities;
using SuperShoes.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperShoes.Controllers
{
    public class ArticleController : Controller
    {
        /// <summary>
        /// Represents a service for the article.
        /// </summary>
        private IArticleService articleService;

        /// <summary>
        /// Represents a service for the store.
        /// </summary>
        private IStoreService storeService;

        /// <summary>
        /// Constructor of the controller.
        /// </summary>
        /// <param name="service">Service for the article.</param>
        /// /// <param name="service">Service for the store.</param>
        public ArticleController(IArticleService articleService, IStoreService storeService)
        {
            this.articleService = articleService;
            this.storeService = storeService;
        }

        // GET: Article
        public ActionResult Index()
        {
            List<Article> articles = articleService.GetArticles();
            IEnumerable<ArticleViewModel> list = articles.Select(x => new ArticleViewModel
            {
                ArticleId = x.ArticleId.ToString(),
                Price = x.Price.ToString("C2", new CultureInfo("en-US")),
                TotalInShelf = x.TotalInShelf.ToString(),
                TotalInVault = x.TotalInVault.ToString("C2", new CultureInfo("en-US")),
                Description = x.Description,
                Name = x.Name
            });

            return View("GetArticles", list);
        }

        // GET: Article/Details/5
        public ActionResult Details(int id)
        {
            return View("EditArticles");
        }

        // GET: Article/Create
        public ActionResult Create()
        {
            List<Store> stores = storeService.GetStores();
            IEnumerable<SelectListItem> list = stores.Select(x => new SelectListItem
            {
                Value = x.StoreId.ToString(),
                Text = x.Name
            });

            var model = new ArticleViewModel();
            model.Stores = list;

            return View("CreateArticles", model);
        }

        // POST: Article/Create
        [HttpPost]
        public ActionResult Create(ArticleViewModel model)
        {
            try
            {
                Article article = new Article()
                {
                    Name = model.Name,
                    Description = model.Description,
                    Price = Format.GetValue(model.Price),
                    TotalInShelf = Format.GetIntValue(model.TotalInShelf),
                    TotalInVault = Format.GetValue(model.TotalInVault),
                    Store = new Store() { StoreId = Format.GetIntValue(model.StoreId) }
                };
                articleService.SaveArticle(article);
                return RedirectToAction("Index");
            }
            catch
            {

            }

            return View("");
        }

        // GET: Article/Edit/5
        public ActionResult Edit(int id)
        {
            List<Store> stores = storeService.GetStores();
            IEnumerable<SelectListItem> list = stores.Select(x => new SelectListItem
            {
                Value = x.StoreId.ToString(),
                Text = x.Name
            });

            Article article = articleService.GetArticle(id);
            var model = new ArticleViewModel();
            model.Stores = list;
            model.ArticleId = article.ArticleId.ToString();
            model.Description = article.Description;
            model.Name = article.Name;
            model.Price = Format.FormatCurrency(article.Price);
            model.StoreId = article.Store.StoreId.ToString();
            model.TotalInShelf = article.TotalInShelf.ToString();
            model.TotalInVault = Format.FormatCurrency(article.TotalInVault);

            return View("EditArticles", model);
        }

        // POST: Article/Edit
        [HttpPost]
        public ActionResult Edit(int id, ArticleViewModel model)
        {
            try
            {
                articleService.UpdateArticle(new Article() { ArticleId = id, Name = model.Name, Description = model.Description, Price = Format.GetValue(model.Price), TotalInShelf = Format.GetIntValue(model.TotalInShelf), TotalInVault = Format.GetValue(model.TotalInVault) });
                return RedirectToAction("Index");
            }
            catch
            {
            }

            return View("Index");
        }

        // GET: Article/Delete/5
        public ActionResult Delete(int id)
        {
            return View("Index");
        }

        // POST: Article/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                storeService.DeleteStore(id);
                return RedirectToAction("Index");
            }
            catch
            {

            }

            return View("Index");
        }
    }
}
