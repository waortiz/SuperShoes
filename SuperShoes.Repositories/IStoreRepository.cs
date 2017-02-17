using SuperShoes.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperShoes.Repositories
{
    public interface IStoreRepository
    {
        IQueryable<Store> GetStores();
        IQueryable<Article> GetArticles(int storeId);
        void SaveStore(Store store);
        void UpdateStore(Store store);
        void DeleteStore(int storeId);
    }
}
