using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplesoftRetail
{
    public interface IUnitOfWork:IDisposable
    {
        IShopsRepositoty Store { get; }
        ICustomer customer { get; }
        int Complete();
    }
}
