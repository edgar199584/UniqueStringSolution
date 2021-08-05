using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniqueString.Core.Interfaces.RepositoryContract
{
    public interface IUnitOfWork
    {
        IUniqueStringRepository UniqueStringRepository { get; }
    }
}
