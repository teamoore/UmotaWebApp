using Microsoft.EntityFrameworkCore;
using Prizma.Core.Model;
using Prizma.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UmotaWebApp.Shared;
using UmotaWebApp.Shared.ModelDto.Request;

namespace Prizma.Data.Repositories
{
    public class KaynakRepository : Repository<Kaynak>, IKaynakRepository
    {
        private PrizmaDbContext dbContext
        {
            get { return Context as PrizmaDbContext; }
        }

        public KaynakRepository(PrizmaDbContext dbContext) : base(dbContext)
        {

        }
        public async Task<IEnumerable<V002_Kaynak>> GetList(KaynakRequestDto request)
        {
            //return await dbContext.v002_Kaynak.ToListAsync();

            var qry = dbContext.v002_Kaynak.AsQueryable();

            if (request.AktiviteRef.HasValue && request.AktiviteRef > 0)
                qry = qry.Where(x => x.Aktiviteref == request.AktiviteRef);

            if (!string.IsNullOrWhiteSpace(request.searchString))
                qry = qry.Where(x => x.Adi.Contains(request.searchString));

            return await qry.ToListAsync();

        }
    }
}
