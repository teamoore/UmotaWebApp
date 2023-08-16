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
    public class TalepOnayService : ITalepOnayService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TalepOnayService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<V032_TalepOnay>> GetTalepFisOnayListAsnyc(TalepOnayRequestDto request)
        {
            return await _unitOfWork.TalepOnayRepository.GetTalepFisOnayListAsnyc(request);
        }
    }
}
