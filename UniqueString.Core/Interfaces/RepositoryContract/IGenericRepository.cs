using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniqueString.Core.Interfaces.RepositoryContract
{
    public interface IGenericRepository<TEntity>
    {
        TEntity Find(params object[] keyValues);
        void SetValues(object from, object to);
        int SaveChanges();
        void Remove(TEntity entity);
        void Add(TEntity entity);
    }
}
