using Prizma.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UmotaWebApp.Shared.ModelDto;

namespace Prizma.Core.Repositories
{
    public interface ITalepFisRepository : IRepository<TalepFis>
    {
        Task<TalepFis> CreateTalepFisAsync(TalepFis entity);

        Task<List<TalepFisDto>> GetTalepFisListAsync();
    }
}
