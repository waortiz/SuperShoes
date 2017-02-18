namespace SuperShoes.Repositories
{
    public abstract class BaseRepository
    {
        /// <summary>
        /// Represents a context for database operations.
        /// </summary>
        internal SuperShoesContext superShoesContext;

        /// <summary>
        /// Constructor of the class.
        /// </summary>
        /// <param name="superShoesContext">Context for database operations</param>
        public BaseRepository(SuperShoesContext superShoesContext)
        {
            this.superShoesContext = superShoesContext;
        }
    }
}