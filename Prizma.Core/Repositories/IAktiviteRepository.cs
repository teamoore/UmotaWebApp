using Prizma.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UmotaWebApp.Shared;


namespace Prizma.Core.Repositories
{
    public interface IAktiviteRepository : IRepository<Aktivite>
    {
        Task<IEnumerable<V001Aktivite>> GetAll();

        Task<IEnumerable<V001Aktivite>> GetRelated(int parlogref);
    }
}
