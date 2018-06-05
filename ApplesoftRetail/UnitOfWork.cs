using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplesoftRetail
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplesoftEntities context;

        public UnitOfWork(ApplesoftEntities contxt)
        {
            context = contxt;
            Store = new ShopsRepository(context);
            customer = new Customers(context);
        }
        public IShopsRepositoty Store { get; private set; }

        public ICustomer customer { get; private set; }

        public int Complete()
        {
            return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
