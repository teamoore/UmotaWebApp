using Azure.Core;
using Microsoft.EntityFrameworkCore;
using Prizma.Core.Model;
using Prizma.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UmotaWebApp.Shared;
using UmotaWebApp.Shared.ModelDto;
using UmotaWebApp.Shared.ModelDto.Request;

namespace Prizma.Data.Repositories
{
    public class TalepOnayRepository : Repository<TalepOnay>, ITalepOnayRepository
    {
        private PrizmaDbContext dbContext
        {
            get { return Context as PrizmaDbContext; }
        }

        public TalepOnayRepository(PrizmaDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<V032_TalepOnay>> GetTalepFisOnayListAsnyc(TalepOnayRequestDto request)
        {
            var qry = dbContext.v032_TalepOnay.AsQueryable();

            qry = qry.Where(x => x.TalepRef == request.TalepRef);

            return await qry.Take(100).ToListAsync();
        }
    }
}
