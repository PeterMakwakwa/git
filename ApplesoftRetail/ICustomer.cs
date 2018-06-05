using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplesoftRetail
{
    public interface ICustomer: IApplesoft_Repository<cutomer>
    {
        IEnumerable<Store> GetStoreCustomer();
        List<int> GetMostSelling();
        int GetMostSellingName();

        //
        //void GetMostSelling();

        // void AddCutomerWithStore(int storeId, DateTime purchaseDate);

    }
}
