using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UmotaWebApp.Shared;


namespace Prizma.Core.Services
{
    public interface IAktiviteService
    {
        Task<IEnumerable<V001Aktivite>> GetAll();

        Task<IEnumerable<V001Aktivite>> GetRelated(int parlogref);

    }
}
