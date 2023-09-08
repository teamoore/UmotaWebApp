using Prizma.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UmotaWebApp.Shared;
using UmotaWebApp.Shared.ModelDto;

namespace Prizma.Core.Repositories
{
    public interface ISiparisRepository : IRepository<Siparis>
    {
        Task<List<V040_Siparis>> LoadRecordsFromView(SiparisRequestDto request);
        Task<Siparis> SaveRecord(Siparis entity);
    }
}
