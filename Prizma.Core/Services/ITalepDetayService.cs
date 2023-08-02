using Prizma.Core.Model;
using UmotaWebApp.Shared.ModelDto;
using UmotaWebApp.Shared.ModelDto.Request;
using UmotaWebApp.Shared.ViewModel;

namespace Prizma.Core.Services
{
    public interface ITalepDetayService
    {
        Task<TalepDetay> CreateTalepDetay(TalepDetayDTO talepDetay);

        Task<IEnumerable<TalepDetay>> GetTalepDetayList();

        Task<IEnumerable<V031_TalepDetay>> GetTalepFisDetayListAsnyc(TalepFisDetayRequestDto request);
    }
}
