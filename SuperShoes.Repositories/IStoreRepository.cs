namespace SuperShoes.Repositories
{
    using SuperShoes.Domain;
    using System.Collections.Generic;

    /// <summary>
    /// Interface for managing the repository of the store
    /// </summary>
    public interface IStoreRepository
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
        /// <returns>An article.</returns>
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
