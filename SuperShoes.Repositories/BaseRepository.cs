using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperShoes.Repositories
{
    public abstract class BaseRepository
    {
        internal SuperShoesContext superShoesContext;

        public BaseRepository(SuperShoesContext superShoesContext)
        {
            this.superShoesContext = superShoesContext;
        }
    }
}