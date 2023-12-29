﻿using Prizma.Core.Model;
using Prizma.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        
        public Task<TalepFis> CreateTalepFisAsync(TalepFis entity)
        {
            throw new NotImplementedException();
        }
    }
}
