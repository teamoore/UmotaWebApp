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
    public class SiparisDetayRepository : Repository<SiparisDetay>, ISiparisDetayRepository
    {
        private PrizmaDbContext dbContext
        {
            get { return Context as PrizmaDbContext; }
        }
        public SiparisDetayRepository(DbContext context) : base(context)
        {

        }

        public List<SiparisDetay> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<V041_SiparisDetay>> GetSiparisDetayListAsnyc(SiparisDetayRequestDto request)
        {
            var qry = dbContext.v041_SiparisDetay.AsQueryable();

            if (request.SiparisDetay != null)
            {
                if (request.SiparisDetay.Parlogref != 0)
                    qry = qry.Where(x => x.Parlogref == request.SiparisDetay.Parlogref);
            }

            return await qry.Take(100).ToListAsync();
        }
    }
}
