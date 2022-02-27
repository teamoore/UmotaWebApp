using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UmotaWebApp.Server.Data.Models;
using UmotaWebApp.Server.Extensions;
using UmotaWebApp.Shared.ModelDto;

namespace UmotaWebApp.Server.Services.Infrastructure
{
    public class MalzemeKartService : IMalzemeKartService
    {
        public IMapper Mapper { get; }
        public IConfiguration Configuration { get; }

        public MalzemeKartService(IMapper mapper, IConfiguration configuration)
        {
            Mapper = mapper;
            Configuration = configuration;
        }

 

 

        public async Task<MalzemeKartDto> GetMalzemeKart(int logref, string firmaId)
        {
            if (string.IsNullOrEmpty(firmaId))
                throw new Exception("Firma Dönem seçimi yapınız");

            var connectionstring = Configuration.GetUmotaConnectionString(firmaId: firmaId);
            var optionsBuilder = new DbContextOptionsBuilder<UmotaCompanyDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);

            using (UmotaCompanyDbContext dbContext = new UmotaCompanyDbContext(optionsBuilder.Options))
            {
                return await dbContext.MalzKarts.Where(i => i.Logref == logref)
                        .ProjectTo<MalzemeKartDto>(Mapper.ConfigurationProvider).SingleOrDefaultAsync();
            }
        }

        public async Task<List<MalzemeKartDto>> SearchMalzemeKart(MalzemeKartRequestDto request)
        {

            var connectionstring = Configuration.GetUmotaConnectionString(firmaId: request.FirmaId.ToString());
            var optionsBuilder = new DbContextOptionsBuilder<UmotaCompanyDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);

            var word = request.MalzemeKart.Adi.ToLower();

            using (UmotaCompanyDbContext dbContext = new UmotaCompanyDbContext(optionsBuilder.Options))
            {
                return await dbContext.MalzKarts.Where(x => x.Adi.ToLower().Contains(word)
                || x.Marka.ToLower().Contains(word)
                || x.Logokodu.ToLower().Contains(word)
                || x.Ozelkod.ToLower().Contains(word))
                    .ProjectTo<MalzemeKartDto>(Mapper.ConfigurationProvider).ToListAsync();
            }
        }
    }
}
