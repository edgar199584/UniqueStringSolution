using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniqueString.Core.Interfaces.RepositoryContract;
using UniqueString.Infrastructure.DAL.Data;

namespace UniqueString.Infrastructure.DAL.Repositories
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly UniqueStringDBContext _context;
        public GenericRepository(UniqueStringDBContext context)
        {
            this._context = context;
        }

        protected internal UniqueStringDBContext db
        {
            get { return _context; }
        }
        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public TEntity Find(params object[] keyValues)
        {
            return _context.Set<TEntity>().Find(keyValues);
        }
        public void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void SetValues(object entity, object dbEntity)
        {
            _context.Entry(dbEntity).CurrentValues.SetValues(entity);
        }
    }
}
