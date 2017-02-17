using SuperShoes.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperShoes.Repositories
{
    public interface IArticleRepository
    {
        IQueryable<Article> GetArticles();
        void SaveArticle(Article article);
        void UpdateArticle(Article article);
        void DeleteArticle(int articleId);
    }
}
