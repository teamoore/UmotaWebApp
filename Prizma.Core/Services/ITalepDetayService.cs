using Prizma.Core.Model;
using UmotaWebApp.Shared.ModelDto;

namespace Prizma.Core.Services
{
    public interface ITalepDetayService
    {
        Task<TalepDetay> CreateTalepDetay(TalepDetayDTO talepDetay);

        Task<IEnumerable<TalepDetay>> GetTalepDetayList();
    }
}
