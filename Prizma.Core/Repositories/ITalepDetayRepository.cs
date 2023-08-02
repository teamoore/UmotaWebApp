using Prizma.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UmotaWebApp.Shared.ModelDto.Request;
using UmotaWebApp.Shared.ViewModel;

namespace Prizma.Core.Repositories
{
    public interface ITalepDetayRepository : IRepository<TalepDetay>
    {
        Task<IEnumerable<TalepDetay>> GetTalepDetayListAsync();

        Task<IEnumerable<V031_TalepDetay>> GetTalepFisDetayListAsnyc(TalepFisDetayRequestDto request);

    }
}
