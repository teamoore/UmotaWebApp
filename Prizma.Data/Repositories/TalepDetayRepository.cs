using Microsoft.EntityFrameworkCore;
using Prizma.Core.Model;
using Prizma.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UmotaWebApp.Shared.ModelDto.Request;
using UmotaWebApp.Shared;

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

        public async Task<IEnumerable<V031_TalepDetay>> GetTalepFisDetayListAsnyc(TalepFisDetayRequestDto request)
        {
            var qry = dbContext.v031_TalepFisDetay.AsQueryable();

            if (request.TalepFisDetay != null)
            {
                if (request.TalepFisDetay.Parlogref != 0)
                    qry = qry.Where(x => x.Parlogref == request.TalepFisDetay.Parlogref);
            }

            return await qry.Take(100).ToListAsync();
        }
    }
}
