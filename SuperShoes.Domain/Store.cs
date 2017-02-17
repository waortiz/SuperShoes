namespace SuperShoes.Domain
{
    using System.Collections.Generic;

    /// <summary>
    /// Information of the store.
    /// </summary>
    public class Store
    {
        /// <summary>
        /// Gets or sets the identifier of the store.
        /// </summary>
        public int StoreId { get; set; }

        /// <summary>
        /// Gets or sets the name of the store.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the address of the store.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the address of the store.
        /// </summary>
        public virtual ICollection<Article> Articles { get; set; }
    }
}