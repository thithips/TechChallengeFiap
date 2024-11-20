using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechChallengeFiap.Domain.Interfaces.Repository;

namespace TechChallengeFiap.Services
{
    public abstract class BaseService
    {
        private readonly IUnitOfWork _unitOfWork;

        protected BaseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        protected async Task<bool> Commit()
        {
            if (await _unitOfWork.Commit()) return true; 
            
            return false;
        }
    }
}
