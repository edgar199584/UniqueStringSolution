using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniqueString.Core.Entities;
using UniqueString.Core.Interfaces.RepositoryContract;
using UniqueString.Infrastructure.DAL.Data;

namespace UniqueString.Infrastructure.DAL.Repositories
{
    public class UniqueStringRepository : GenericRepository<UniqueStringEntity>, IUniqueStringRepository
    {

        public UniqueStringRepository(UniqueStringDBContext context):base(context)
        {

        }
        public UniqueStringEntity GetUniqueString(string text)
        {
            return db.UniqueStrings.FirstOrDefault(x => x.Text == text);
        }
        
    }
}
