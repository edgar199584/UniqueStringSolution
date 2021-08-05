using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniqueString.Core.Interfaces.BLContract;
using UniqueString.Core.Interfaces.RepositoryContract;

namespace UniqueString.Core.BL
{
    public class UniqueStringBL : IUniqueStringBL
    {
        protected IUniqueStringRepository UniqueStringRepository;
        public UniqueStringBL(IUnitOfWork _unitOfWork)
        {
            UniqueStringRepository = _unitOfWork.UniqueStringRepository;
        }
        public bool IsUnique(string text)
        {
            var result = UniqueStringRepository.GetUniqueString(text);
            if (result == null)
                return true;
            return false;
        }
    }
}
