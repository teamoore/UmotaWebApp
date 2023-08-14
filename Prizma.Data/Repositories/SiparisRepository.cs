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

namespace Prizma.Data.Repositories
{
    public class SiparisRepository : Repository<Siparis> , ISiparisRepository
    {
        private PrizmaDbContext dbContext
        {
            get { return Context as PrizmaDbContext; }
        }

        public SiparisRepository(PrizmaDbContext dbContext) :base(dbContext) { }

        public async Task<List<V040_Siparis>> GetV040_Siparis(SiparisViewRequestDto request)
        {
            var qry = dbContext.v040_Siparis.Where(x => x.InsUser == request.kullanicikodu);


            if (request.Siparis != null)
            {
                if (request.Siparis.logref != 0)
                    qry = qry.Where(x => x.LogRef == request.Siparis.logref);

                if (request.SiparisDurumu != 0)
                    qry = qry.Where(x => x.DurumRef == request.SiparisDurumu);

                if (request.ProjeRef != 0)
                    qry = qry.Where(x => x.ProjeRef == request.ProjeRef);
            }

            return await qry.ToListAsync();
        }
    }
}
