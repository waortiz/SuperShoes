namespace SuperShoes.Repositories
{
    using Exceptions;
    using SuperShoes.Domain;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Class for managing the repository of the store.
    /// </summary>
    public class StoreRepository : BaseRepository, IStoreRepository
    {
        /// <summary>
        /// Constructor of the class.
        /// </summary>
        /// <param name="superShoesContext">Context for the repository.</param>
        public StoreRepository(SuperShoesContext superShoesContext) : base(superShoesContext)
        {

        }

        /// <summary>
        /// Get all the stores in the respository.
        /// </summary>
        /// <returns>List the stores in the respository.</returns>
        public List<Store> GetStores()
        {
            List<Store> stores = new List<Store>();
            var currentStores = superShoesContext.Stores.ToList();
            foreach(Store store in currentStores)
            {
                stores.Add(new Store() { Address = store.Address, Name = store.Name, StoreId = store.StoreId });
            }

            return stores;
        }

        /// <summary>
        /// Get a store.
        /// </summary>
        /// <param name="storeId">Id of the store to get.</param>
        /// <returns>An article.</returns>
        public Store GetStore(int storeId)
        {
            var current = superShoesContext.Stores.Find(storeId);
            if (current == null)
            {
                throw new RecordNotFoudException(string.Format("Store {0} not found", storeId));
            }

            return new Store() { Address = current.Address, Name = current.Name, StoreId = current.StoreId };
        }

        /// <summary>
        /// Save a store.
        /// </summary>
        /// <param name="store">Store to save.</param>
        public void SaveStore(Store store)
        {
            superShoesContext.Stores.Add(store);
            superShoesContext.SaveChanges();
        }

        /// <summary>
        /// Update a store.
        /// </summary>
        /// <param name="store">Store to update.</param>
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
                throw new RecordNotFoudException(string.Format("Store {0} not found", store.StoreId));
            }

            superShoesContext.SaveChanges();
        }

        /// <summary>
        /// Delete a store by id.
        /// </summary>
        /// <param name="storeId">Id of the store.</param>
        public void DeleteStore(int storeId)
        {
            var current = superShoesContext.Stores.Find(storeId);
            if (current != null)
            {
                superShoesContext.Stores.Remove(current);
                superShoesContext.SaveChanges();
            }
            else
            {
                throw new RecordNotFoudException(string.Format("Store {0} not found", storeId));
            }
        }
    }
}
