using SuperShoes.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperShoes.Repositories
{
    public class StoreRepository : BaseRepository, IStoreRepository
    {
        public StoreRepository(SuperShoesContext superShoesContext) : base(superShoesContext)
        {

        }

        public IQueryable<Store> GetStores()
        {
            return superShoesContext.Stores.AsQueryable();
        }

        public IQueryable<Article> GetArticles(int storeId)
        {
            return superShoesContext.Articles.Where(a=>a.Store.StoreId == storeId);
        }

        public void SaveStore(Store store)
        {
            superShoesContext.Stores.Add(store);
            superShoesContext.SaveChanges();
        }

        public void UpdateStore(Store store)
        {
            var current = superShoesContext.Stores.Find(store.StoreId);
            if (current != null)
            {
                current.Address = store.Address;
                current.Name = store.Name;
            }
            else
            {
                superShoesContext.Stores.Add(store);
            }

            superShoesContext.SaveChanges();
        }

        public void DeleteStore(int storeId)
        {
            var current = superShoesContext.Stores.Find(storeId);
            if (current != null)
            {
                superShoesContext.Stores.Remove(current);
            }
        }
    }
}
