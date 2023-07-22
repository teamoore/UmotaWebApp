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
        private MahalRepository _mahalRepository;
        private ITalepFisRepository _talepfRepository;

        public UnitOfWork(PrizmaDbContext context)
        {
            _context = context;
        }

        public ITalepDetayRepository TalepDetayRepository => _talepdetayRepository = _talepdetayRepository ?? new TalepDetayRepository(_context);
        public IMahalRepository MahalRepository => _mahalRepository = _mahalRepository ?? new MahalRepository(_context);

        public ITalepFisRepository TalepFisRepository => _talepfRepository = _talepfRepository ?? new TalepFisRepository(_context);

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
