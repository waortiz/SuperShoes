namespace SuperShoes.Repositories
{
    using Domain;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

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
