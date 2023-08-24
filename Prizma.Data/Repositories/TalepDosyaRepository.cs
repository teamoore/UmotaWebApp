using Microsoft.EntityFrameworkCore;
using Prizma.Core.Model;
using Prizma.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Prizma.Data.Repositories
{
    public class TalepDosyaRepository : Repository<TalepDosya>, ITalepDosyaRepository
    {
        private PrizmaDbContext dbContext
        {
            get { return Context as PrizmaDbContext; }
        }

        public TalepDosyaRepository(PrizmaDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<TalepDosya> CreateTalepDosya(TalepDosya entity)
        {

            await dbContext.TalepDosya.AddAsync(entity);
            
            return entity;
        }

        public async Task<List<TalepDosya>> GetDosyalar(int talepref)
        {
           return await dbContext.TalepDosya.Where(x => x.TalepLogRef == talepref).ToListAsync();
        }
    }
}
