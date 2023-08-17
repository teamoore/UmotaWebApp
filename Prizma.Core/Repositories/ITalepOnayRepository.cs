using Prizma.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UmotaWebApp.Shared.ModelDto.Request;
using UmotaWebApp.Shared;
using UmotaWebApp.Shared.ModelDto;

namespace Prizma.Core.Repositories
{
    public interface ITalepOnayRepository : IRepository<TalepOnay>
    {
        Task<IEnumerable<V032_TalepOnay>> GetTalepFisOnayListAsnyc(TalepOnayRequestDto request);

        Task<int> TalepOnayRota(TalepOnayRequestDto request);

        Task<int> TalepDurumGuncelle(TalepOnayRequestDto request);
        Task<int> TalepGetOnayLineRef(TalepOnayRequestDto request);
        Task<int> TalepOnayla(TalepOnayRequestDto request);
    }
}
