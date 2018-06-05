using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplesoftRetail;

namespace ApplesoftRetail
{
    public interface IShopsRepositoty: IApplesoft_Repository<Store>
    {
        IEnumerable<Store> GetTopShops();
        //IEnumerable<Store> Get
    }
}
