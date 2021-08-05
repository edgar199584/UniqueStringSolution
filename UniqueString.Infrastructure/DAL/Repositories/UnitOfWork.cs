using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniqueString.Core.Interfaces.RepositoryContract;
using UniqueString.Infrastructure.DAL.Data;

namespace UniqueString.Infrastructure.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly UniqueStringDBContext _context;
        private IUniqueStringRepository _uniqueStringRepository;
        public UnitOfWork(UniqueStringDBContext context)
        {
            this._context = context;
        }
        public IUniqueStringRepository UniqueStringRepository => _uniqueStringRepository = _uniqueStringRepository ?? new UniqueStringRepository(_context);
    }
}
