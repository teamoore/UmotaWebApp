using Prizma.Core;
using Prizma.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UmotaWebApp.Shared;
using UmotaWebApp.Shared.ModelDto;

namespace Prizma.Services
{
    public class SiparisService : ISiparisService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SiparisService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<V040_Siparis>> GetV040_SiparisList(SiparisViewRequestDto request)
        {
           return await _unitOfWork.SiparisRepository.GetV040_Siparis(request);
        }
    }
}
