using Prizma.Core;
using Prizma.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UmotaWebApp.Shared;


namespace Prizma.Services
{
    public class AktiviteService : IAktiviteService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AktiviteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<V001Aktivite>> GetAll()
        {
            return await _unitOfWork.AktiviteRepository.GetAll();
        }

        public async Task<IEnumerable<V001Aktivite>> GetRelated(int parlogref)
        {
            return await _unitOfWork.AktiviteRepository.GetRelated(parlogref);
        }
    }
}
