namespace SuperShoes.Services
{
    using SuperShoes.Domain;
    using System.Collections.Generic;

    public interface IStoreService
    {
        /// <summary>
        /// Get all the stores in the respository.
        /// </summary>
        /// <returns>List the stores in the respository.</returns>
        List<Store> GetStores();

        /// <summary>
        /// Get a store.
        /// </summary>
        /// <param name="storeId">Id of the store to get.</param>
        Store GetStore(int storeId);

        /// <summary>
        /// Save a store.
        /// </summary>
        /// <param name="store">Store to save.</param>
        void SaveStore(Store store);

        /// <summary>
        /// Update a store.
        /// </summary>
        /// <param name="store">Store to update.</param>
        void UpdateStore(Store store);

        /// <summary>
        /// Delete a store by id.
        /// </summary>
        /// <param name="storeId">Id of the store.</param>
        void DeleteStore(int storeId);
    }
}
