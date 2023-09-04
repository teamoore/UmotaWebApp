using Prizma.Core;
using Prizma.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UmotaWebApp.Shared;
using UmotaWebApp.Shared.ModelDto.Request;

namespace Prizma.Services
{
    public class SiparisDetayService : ISiparisDetayService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SiparisDetayService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<V041_SiparisDetay>> GetSiparisDetayListAsnyc(SiparisDetayRequestDto request)
        {
            return await _unitOfWork.SiparisDetayRepository.GetSiparisDetayListAsnyc(request);
        }
    }
}
