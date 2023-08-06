using Microsoft.EntityFrameworkCore;
using Prizma.Core.Model;
using Prizma.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UmotaWebApp.Shared;


namespace Prizma.Data.Repositories
{
    public class AktiviteRepository : Repository<Aktivite>, IAktiviteRepository
    {
        private PrizmaDbContext dbContext
        {
            get { return Context as PrizmaDbContext; }
        }

        public AktiviteRepository(PrizmaDbContext dbContext):base(dbContext)
        {
            
        }

        public async Task<IEnumerable<V001Aktivite>> GetAll()
        {
            return await dbContext.v001Aktivite.ToListAsync();
        }

        public async Task<IEnumerable<V001Aktivite>> GetRelated(int parlogref)
        {
            return await dbContext.v001Aktivite.Where(x => x.Parlogref ==  parlogref).ToListAsync();
        }
    }
}
