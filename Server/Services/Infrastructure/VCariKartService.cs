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
    public class VCariKartService : IVCariKartService
    {
        public IMapper Mapper { get; }
        public IConfiguration Configuration { get; }

        public VCariKartService(IConfiguration configuration, IMapper mapper)
        {
            Configuration = configuration;
            Mapper = mapper;
        }

        public async Task<List<VCariKartDto>> GetVCariKarts(string firmaId)
        {
            if (string.IsNullOrEmpty(firmaId))
                throw new Exception("Firma Dönem seçimi yapınız");

            //var connectionstring = Configuration.GetUmotaConnectionString(firmaId: firmaId);
            var connectionstring = Configuration.GetPrizmeDbConnection();
            var optionsBuilder = new DbContextOptionsBuilder<UmotaCompanyDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);

            using (UmotaCompanyDbContext dbContext = new UmotaCompanyDbContext(optionsBuilder.Options))
            {
                var results = await dbContext.V001CariKarts.Where(x => (x.Active == 0) && (x.Kodu.StartsWith("120") || x.Kodu.StartsWith("320") || x.Logref < 0 ))
                                        .Take(100)
                                        .OrderByDescending(x => x.Logref)
                                        .ProjectTo<VCariKartDto>(Mapper.ConfigurationProvider).ToListAsync();

                return results;
            }
        }
        public async Task<List<VCariKartDto>> SearchVCariKarts(VCariKartsRequestDto request)
        {
            //var connectionstring = Configuration.GetUmotaConnectionString(firmaId: request.FirmaId.ToString());
            var connectionstring = Configuration.GetPrizmeDbConnection();
            var optionsBuilder = new DbContextOptionsBuilder<UmotaCompanyDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);

            using (UmotaCompanyDbContext dbContext = new UmotaCompanyDbContext(optionsBuilder.Options))
            {
                var word = request.SearchText.ToLower();
                var results = await dbContext.V001CariKarts.Where(x => (x.Active == 0) && (x.lgfirmano == request.lgfirmano) &&
                        (x.Adi.ToLower().Contains(word)
                        || x.Adres1.ToLower().Contains(word)
                        || x.Adres2.ToLower().Contains(word)
                        || x.Ilce.Contains(word)
                        || x.Web.Contains(word)
                        || x.Kodu.Contains(word)))
                    .ProjectTo<VCariKartDto>(Mapper.ConfigurationProvider)
                    .OrderByDescending(x => x.Logref)
                    .ToListAsync();

                return results;
            }
        }
        public async Task<VCariKartDto> GetVCariKart(int logref, string firmaId)
        {
            if (string.IsNullOrEmpty(firmaId))
                throw new Exception("Firma Dönem seçimi yapınız");

            //var connectionstring = Configuration.GetUmotaConnectionString(firmaId: firmaId);
            var connectionstring = Configuration.GetPrizmeDbConnection();
            var optionsBuilder = new DbContextOptionsBuilder<UmotaCompanyDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);

            using (UmotaCompanyDbContext dbContext = new UmotaCompanyDbContext(optionsBuilder.Options))
            {
                IQueryable<VCariKartDto> qry = dbContext.V001CariKarts.Where(i => i.Logref == logref)
                            .ProjectTo<VCariKartDto>(Mapper.ConfigurationProvider);

                return await qry.SingleOrDefaultAsync();
            }
        }
        public async Task<List<SevkAdresDto>> GetCariKartSevkAdresList(string firmaId, int cariref)
        {
            if (string.IsNullOrEmpty(firmaId))
                throw new Exception("Firma Dönem seçimi yapınız");

            var connectionstring = Configuration.GetUmotaConnectionString(firmaId: firmaId);
            var optionsBuilder = new DbContextOptionsBuilder<UmotaCompanyDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);

            using (UmotaCompanyDbContext dbContext = new UmotaCompanyDbContext(optionsBuilder.Options))
            {
                var results = await dbContext.V004Sevkadres.Where(x => x.Clientref == cariref)
                                        .Take(100)
                                        .OrderByDescending(x => x.Logref)
                                        .ProjectTo<SevkAdresDto>(Mapper.ConfigurationProvider).ToListAsync();

                return results;
            }
        }
    }
}
