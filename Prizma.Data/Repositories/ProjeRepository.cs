using Microsoft.EntityFrameworkCore;
using Prizma.Core.Model;
using Prizma.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prizma.Data.Repositories
{
    public sealed class ProjeRepository : Repository<Proje>, IProjeRepository
    {
        private PrizmaDbContext dbContext
        {
            get { return Context as PrizmaDbContext; }
        }

        public ProjeRepository(PrizmaDbContext dbContext) : base(dbContext) { }

        public async Task<List<Proje>> GetProjeListAsync()
        {
            return await dbContext.Proje.Where(x => x.Active == 0).ToListAsync();
        }
    }
}
