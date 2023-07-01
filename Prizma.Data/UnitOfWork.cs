using Prizma.Core;
using Prizma.Core.Repositories;
using Prizma.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prizma.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PrizmaDbContext _context;
        private TalepDetayRepository _talepdetayRepository;

        public UnitOfWork(PrizmaDbContext context)
        {
            _context = context;
        }

        public ITalepDetayRepository TalepDetays => _talepdetayRepository = _talepdetayRepository ?? new TalepDetayRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
