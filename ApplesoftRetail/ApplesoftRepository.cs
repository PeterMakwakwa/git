using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApplesoftRetail
{
    public interface IApplesoft_Repository<ApplesoftEntities> where ApplesoftEntities : class
    {
        ApplesoftEntities Get(int Id);
        IEnumerable<ApplesoftEntities> GetAll();
        IEnumerable<ApplesoftEntities> Find(Expression<Func<ApplesoftEntities, bool>> predicate);

        void Add(ApplesoftEntities applesoft);
        void AddRange(IEnumerable<ApplesoftEntities> applesoft);

        void Remove(ApplesoftEntities applesoft);
        void RemoveRange(IEnumerable<ApplesoftEntities> applesoft);
    }
}
