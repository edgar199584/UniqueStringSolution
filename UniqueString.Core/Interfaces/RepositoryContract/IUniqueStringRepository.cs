using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniqueString.Core.Entities;

namespace UniqueString.Core.Interfaces.RepositoryContract
{
    public interface IUniqueStringRepository:IGenericRepository<UniqueStringEntity>
    {
        UniqueStringEntity GetUniqueString(string text);
    }
}
