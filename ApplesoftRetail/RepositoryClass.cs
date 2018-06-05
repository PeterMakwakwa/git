using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApplesoftRetail
{
    public class RepositoryClass<ApplesoftEntities> : IApplesoft_Repository<ApplesoftEntities> where ApplesoftEntities : class
    {
        protected readonly DbContext Context;

        public RepositoryClass(DbContext context)
        {
            Context = context;
        }
        
        public void Add(ApplesoftEntities applesoft)
        {
            Context.Set<ApplesoftEntities>().Add(applesoft);
        }

        public IEnumerable<ApplesoftEntities> Find(Expression<Func<ApplesoftEntities, bool>> predicate)
        {
            return Context.Set<ApplesoftEntities>().Where(predicate);
        }

        public ApplesoftEntities Get(int Id)
        {
            return Context.Set<ApplesoftEntities>().Find(Id);
        }

        public IEnumerable<ApplesoftEntities> GetAll()
        {
            return Context.Set<ApplesoftEntities>().ToList();               
        }

        public void AddRange(IEnumerable<ApplesoftEntities> applesoft)
        {
            Context.Set<ApplesoftEntities>().AddRange(applesoft);
        }

        public void Remove(ApplesoftEntities applesoft)
        {
            Context.Set<ApplesoftEntities>().Remove(applesoft);
        }

        public void RemoveRange(IEnumerable<ApplesoftEntities> applesoft)
        {
            Context.Set<ApplesoftEntities>().RemoveRange(applesoft);
        }
    }
}
