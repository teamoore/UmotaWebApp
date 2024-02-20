using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UmotaWebApp.Shared.ModelDto.Request;
using UmotaWebApp.Shared;
using UmotaWebApp.Shared.ModelDto;

namespace Prizma.Core.Services
{
    public interface ITalepOnayService
    {
        Task<IEnumerable<V032_TalepOnay>> GetTalepFisOnayListAsnyc(TalepOnayRequestDto request);

        Task<int> TalepOnayRota(TalepOnayRequestDto request);

        Task<int> TalepDurumGuncelle(TalepOnayRequestDto request);
        Task<int> TalepGetOnayLineRef(TalepOnayRequestDto request);
        Task<int> TalepOnayla(TalepOnayRequestDto request);

        Task<bool> UploadTalepDosya(TalepDosyaRequestDto request);

    }
}
