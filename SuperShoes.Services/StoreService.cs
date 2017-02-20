namespace SuperShoes.Services
{
    using SuperShoes.Domain;
    using SuperShoes.Repositories;
    using System.Collections.Generic;
    using System.Linq;
    using System;

    public class StoreService : IStoreService
    {
        /// <summary>
        /// Represents the repository for the store.
        /// </summary>
        IStoreRepository repository;

        /// <summary>
        /// Constructor of the class.
        /// </summary>
        /// <param name="repository">Repository for the store.</param>
        public StoreService(IStoreRepository repository)
        {
            this.repository = repository;
        }

        /// <summary>
        /// Get all the stores in the respository.
        /// </summary>
        /// <returns>List the stores in the respository.</returns>
        public List<Store> GetStores()
        {
            return repository.GetStores();
        }

        /// <summary>
        /// Save a store.
        /// </summary>
        /// <param name="store">Store to save.</param>
        public void SaveStore(Store store)
        {
            repository.SaveStore(store);
        }

        /// <summary>
        /// Update a store.
        /// </summary>
        /// <param name="store">Store to update.</param>
        public void UpdateStore(Store store)
        {
            repository.UpdateStore(store);
        }

        /// <summary>
        /// Delete a store by id.
        /// </summary>
        /// <param name="storeId">Id of the store.</param>
        public void DeleteStore(int storeId)
        {
            repository.DeleteStore(storeId);
        }

        /// <summary>
        /// Get a store.
        /// </summary>
        /// <param name="storeId">Id of the store to get.</param>
        public Store GetStore(int storeId)
        {
            return repository.GetStore(storeId);
        }
    }
}
