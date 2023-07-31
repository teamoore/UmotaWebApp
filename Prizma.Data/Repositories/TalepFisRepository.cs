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
    public class TalepFisRepository : Repository<TalepFis>, ITalepFisRepository
    {
        private PrizmaDbContext dbContext
        {
            get { return Context as PrizmaDbContext; }
        }

        public TalepFisRepository(PrizmaDbContext dbContext) :base(dbContext) 
        { 
        }
        
        public async Task<TalepFis> CreateTalepFisAsync(TalepFis entity)
        {
            await dbContext.TalepFis.AddAsync(entity);
            await dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<List<TalepFisDto>> GetTalepFisListAsync(string kullanici)
        {
            var qry = from t in dbContext.TalepFis
                      join p in dbContext.Proje on t.ProjeRef equals p.logref

                      where t.insuser == kullanici
                      orderby t.insdate descending
                      select new TalepFisDto()
                      {
                          ProjeAdi = p.Adi,
                          TalepEden = t.TalepEden,
                          Aciklama = t.Aciklama,
                          TeslimTarihi = t.TeslimTarihi,
                          TeslimYeriRef = t.TeslimYeriRef,
                          insuser = t.insuser
                      };

            return await qry.ToListAsync();
        }

        public async Task<List<V030_TalepFis>> GetV030_TalepFisListAsync(TalepFisRequestDto request)
        {
            var qry = dbContext.v030_TalepFis.Where(x => x.InsUser == request.kullanicikodu);

            return await qry.ToListAsync();
        }
    }
}
