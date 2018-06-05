using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplesoftRetail
{
    public class Customers : RepositoryClass<cutomer>, ICustomer
    {
        int count = 0;
        public Customers(ApplesoftEntities context)
           : base(context)
        {

        }
        public IEnumerable<Store> GetStoreCustomer()
        {
            
            List<Store> tempss = new List<Store>();
            using (var context = new ApplesoftEntities())
            {
                for (int x = 1; x <= context.Stores.Count(); x++)
                {

                    context.cutomers.Where(o => o.storeID == x).Count();
                    var blog = context.Stores
                    .Where(b => b.storeID == x)
                    .FirstOrDefault();
                    tempss.Add(blog);

                   // tem.Add(count);
                }
            }
            return tempss;
        }


        public List<int> GetMostSelling()
        {
          
            List<int> tem = new List<int>();

            using (var context = new ApplesoftEntities())
            {
                for (int x = 1; x <= context.Stores.Count(); x++)
                {
                    count = context.cutomers.Where(o => o.storeID == x).Count();
                    tem.Add(count);
                }
                
            }
            
            return tem;
        }

        public int GetMostSellingName()
        {
            List<int> high = new List<int>();
            int maxvalue = int.MinValue;
           // int indes
            using (var context = new ApplesoftEntities())
            {
                for (int x = 1; x <= context.Stores.Count(); x++)
                {
                    count = context.cutomers.Where(o => o.storeID == x).Count();
                    high.Add(count);
                }

                foreach(var hi in high)
                {
                    if (hi > maxvalue)
                    {
                        maxvalue = hi;
                    }
                }
                if (high.IndexOf(maxvalue) == 0)
                {
                    return high.IndexOf(maxvalue) + 1;
                }
                else
                    return high.IndexOf(maxvalue);
            }

        }

        public ApplesoftEntities ApplesoftEntities
        {

            get { return Context as ApplesoftEntities; }
        }

        //public cutomer AddCutomerWithStore(int storeId, DateTime purchaseDate)
        //{
        //    cutomer cm = new cutomer
        //    {
        //        storeID = storeId,
        //        Dates = purchaseDate
        //    };

        //    return cm;
            
        //}
    }
}
