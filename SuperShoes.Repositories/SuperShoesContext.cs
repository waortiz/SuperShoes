namespace SuperShoes.Repositories
{
    using Domain;
    using System.Data.Entity;

    /// <summary>
    /// Information of the database context.
    /// </summary>
    public class SuperShoesContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Store> Stores { get; set; }

        public SuperShoesContext() : base("name=SuperShoesContext")
        {
            
        }
    }
}
