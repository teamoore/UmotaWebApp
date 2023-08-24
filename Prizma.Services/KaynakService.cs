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
    public class KaynakService : IKaynakService
    {
    
    private readonly IUnitOfWork _unitOfWork;

    public KaynakService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<V002_Kaynak>> GetList(KaynakRequestDto request)
    {
        return await _unitOfWork.KaynakRepository.GetList(request);
    }

}
}
