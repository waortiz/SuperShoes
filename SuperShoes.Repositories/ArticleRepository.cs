using SuperShoes.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperShoes.Repositories
{
    public class ArticleRepository : BaseRepository, IArticleRepository
    {
        public ArticleRepository(SuperShoesContext superShoesContext) : base(superShoesContext)
        {

        }

        public IQueryable<Article> GetArticles()
        {
            return superShoesContext.Articles.AsQueryable();
        }

        public void SaveArticle(Article article)
        {
            superShoesContext.Articles.Add(article);
            superShoesContext.SaveChanges();
        }

        public void UpdateArticle(Article article)
        {
            var current = superShoesContext.Articles.Find(article.IdArticle);
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
                superShoesContext.Articles.Add(article);
            }

            superShoesContext.SaveChanges();
        }

        public void DeleteArticle(int articleId)
        {
            var current = superShoesContext.Articles.Find(articleId);
            if (current != null)
            {
                superShoesContext.Articles.Remove(current);
            }
        }
    }
}
