using Microsoft.EntityFrameworkCore;
using Prizma.Core.Model;
using Prizma.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UmotaWebApp.Shared.ModelDto.Request;
using UmotaWebApp.Shared.ViewModel;

namespace Prizma.Data.Repositories
{
    public class TalepDetayRepository : Repository<TalepDetay>, ITalepDetayRepository
    {
        private PrizmaDbContext dbContext
        {
            get { return Context as PrizmaDbContext; }
        }

        public TalepDetayRepository(PrizmaDbContext context) : base(context)
        {
                
        }

        public async Task<IEnumerable<TalepDetay>> GetTalepDetayListAsync()
        {
            var list = await dbContext.TalepDetays.ToListAsync();
            return list;
        }

        public Task<IEnumerable<V031_TalepDetay>> GetTalepFisDetayListAsnyc(TalepFisDetayRequestDto request)
        {
            throw new NotImplementedException();
        }
    }
}
