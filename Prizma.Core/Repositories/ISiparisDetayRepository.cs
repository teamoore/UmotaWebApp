using Prizma.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UmotaWebApp.Shared.ModelDto.Request;
using UmotaWebApp.Shared;

namespace Prizma.Core.Repositories
{
    public interface ISiparisDetayRepository : IRepository<SiparisDetay>
    {
        List<SiparisDetay> GetAll();

        Task<IEnumerable<V041_SiparisDetay>> GetSiparisDetayListAsnyc(SiparisDetayRequestDto request);
    }
}
