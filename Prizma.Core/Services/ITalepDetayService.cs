using Prizma.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prizma.Core.Services
{
    public interface ITalepDetayService
    {
        Task<TalepDetay> CreateTalepDetay(TalepDetay talepDetay);

        Task<IEnumerable<TalepDetay>> GetTalepDetayList();
    }
}
