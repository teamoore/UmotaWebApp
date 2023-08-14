using Prizma.Core.Model;
using UmotaWebApp.Shared;
using UmotaWebApp.Shared.ModelDto;
using UmotaWebApp.Shared.ModelDto.Request;

namespace Prizma.Core.Services
{
    public interface ITalepDetayService
    {
        Task<TalepDetay> CreateTalepDetay(TalepDetayDTO talepDetay);

        Task<IEnumerable<TalepDetay>> GetTalepDetayList();

        Task<IEnumerable<V031_TalepDetay>> GetTalepFisDetayListAsnyc(TalepFisDetayRequestDto request);

        Task<TalepDetay> GetTalepDetay(int logref);
    }
}
