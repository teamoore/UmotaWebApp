using Prizma.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 

namespace Prizma.Core.Repositories
{
    public interface ITalepDetayRepository : IRepository<TalepDetay>
    {
        Task<IEnumerable<TalepDetay>> GetTalepDetayListAsync();

    }
}
