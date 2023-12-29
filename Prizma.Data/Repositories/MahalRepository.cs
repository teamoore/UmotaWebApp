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
    public class MahalRepository : Repository<Mahal>, IMahalRepository
    {
        private PrizmaDbContext dbContext
        {
            get { return Context as PrizmaDbContext; }
        }


        public MahalRepository(PrizmaDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Mahal>> GetMahalsListAsync()
        {
            return await dbContext.Mahals.ToListAsync();
        }
    }
}
