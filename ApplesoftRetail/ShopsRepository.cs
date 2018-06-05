using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplesoftRetail
{
   public class ShopsRepository:RepositoryClass<Store>, IShopsRepositoty
    {
        public ShopsRepository(ApplesoftEntities context) 
            : base(context)
        {
        }

        public IEnumerable<Store> GetTopShops()
        {
            return ApplesoftEntities.Stores.OrderBy(c => c.storeName).ToList();
        }
        public ApplesoftEntities ApplesoftEntities
        {
            get { return Context as ApplesoftEntities; }
        }
    }
}
