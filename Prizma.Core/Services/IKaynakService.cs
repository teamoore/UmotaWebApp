using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UmotaWebApp.Shared;
using UmotaWebApp.Shared.ModelDto.Request;

namespace Prizma.Core.Services
{
    public interface IKaynakService
    {
        Task<IEnumerable<V002_Kaynak>> GetList(KaynakRequestDto request);
    }
}
