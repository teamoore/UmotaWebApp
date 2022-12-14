using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using UmotaWebApp.Server.Data.Models;
using UmotaWebApp.Server.Extensions;
using UmotaWebApp.Shared.ModelDto;
using System.Data.Common;

namespace UmotaWebApp.Server.Services.Infrastructure
{
    public class VMalzemeKartService : IVMalzemeKartService
    {
        public IMapper Mapper { get; }
        public IConfiguration Configuration { get; }
        private readonly DbConnection _sql;

        public VMalzemeKartService(IMapper mapper, IConfiguration configuration, DbConnection sql)
        {
            Mapper = mapper;
            Configuration = configuration;
            _sql = sql;
        }

        public async Task<VMalzemeKartDto> GetVMalzemeKart(int logref, string firmaId)
        {
            if (string.IsNullOrEmpty(firmaId))
                throw new Exception("Firma Dönem seçimi yapınız");

            var connectionstring = Configuration.GetUmotaConnectionString(firmaId: firmaId);
            var optionsBuilder = new DbContextOptionsBuilder<UmotaCompanyDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);

            using (UmotaCompanyDbContext dbContext = new UmotaCompanyDbContext(optionsBuilder.Options))
            {
                return await dbContext.V002Malzemelers.Where(i => i.Logref == logref)
                        .ProjectTo<VMalzemeKartDto>(Mapper.ConfigurationProvider).SingleOrDefaultAsync();
            }
        }
        public async Task<List<VMalzemeKartDto>> SearchVMalzemeKarts(VMalzemeKartsRequestDto request)
        {
            var connectionstring = Configuration.GetUmotaConnectionString(firmaId: request.FirmaId.ToString());
            var optionsBuilder = new DbContextOptionsBuilder<UmotaCompanyDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);

            string word = request.MalzemeAdi != null ? request.MalzemeAdi.ToLower() : null;
            string marka = request.Marka != null ? request.Marka.ToLower() : null;

            using (UmotaCompanyDbContext dbContext = new UmotaCompanyDbContext(optionsBuilder.Options))
            {
                return await dbContext.V002Malzemelers.Where(x => (x.Active == 0)
                && (word == null || x.Adi.ToLower().Contains(word) || x.Kodu.ToLower().Contains(word) || x.Adi3.ToLower().Contains(word))
                && (marka == null || x.Descr.Contains(marka))
                    ).ProjectTo<VMalzemeKartDto>(Mapper.ConfigurationProvider).ToListAsync();
            }
        }

    }
}
