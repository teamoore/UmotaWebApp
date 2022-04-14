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
    public class KisilerService : IKisilerService
    {
        public IMapper Mapper { get; }
        public IConfiguration Configuration { get; }

        public KisilerService(IConfiguration configuration, IMapper mapper)
        {
            Configuration = configuration;
            Mapper = mapper;
        }
        public async Task<List<KisilerDto>> GetCariKartKisiler(int cariref, string firmaId)
        {
            if (string.IsNullOrEmpty(firmaId))
                throw new Exception("Firma Dönem seçimi yapınız");

            var connectionstring = Configuration.GetUmotaConnectionString(firmaId: firmaId);
            var optionsBuilder = new DbContextOptionsBuilder<UmotaCompanyDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);

            using (UmotaCompanyDbContext dbContext = new UmotaCompanyDbContext(optionsBuilder.Options))
            {
                IQueryable<KisilerDto> qry = dbContext.V015Kisilers.Where(i => i.Cariref == cariref)
                            .ProjectTo<KisilerDto>(Mapper.ConfigurationProvider);

                return await qry.ToListAsync();
            }
        }
        public async Task<KisilerDto> SaveCariKartKisi(KisilerRequestDto request)
        {
            var connectionstring = Configuration.GetUmotaConnectionString(firmaId: request.FirmaId.ToString());
            var optionsBuilder = new DbContextOptionsBuilder<UmotaCompanyDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);

            using (UmotaCompanyDbContext dbContext = new UmotaCompanyDbContext(optionsBuilder.Options))
            {
                var kisiKart = Mapper.Map<Kisiler>(request.Kisiler);
                await dbContext.Kisilers.AddAsync(kisiKart);
                await dbContext.SaveChangesAsync();
                return Mapper.Map<KisilerDto>(kisiKart);
            }
        }

    }
}
