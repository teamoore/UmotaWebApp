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

    public class CariKartService : ICariKartService
    {
        public IMapper Mapper { get; }
        public IConfiguration Configuration { get; }

        public CariKartService(IConfiguration configuration,  IMapper mapper)
        {
            Configuration = configuration;
            Mapper = mapper;
        }
                
        public async Task<List<CariKartDto>> GetCariKartDtos(string firmaId)
        {
            if (string.IsNullOrEmpty(firmaId))
                throw new Exception("Firma Dönem seçimi yapınız");

            var connectionstring = Configuration.GetUmotaConnectionString(firmaId: firmaId);
            var optionsBuilder = new DbContextOptionsBuilder<UmotaCompanyDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);

            using (UmotaCompanyDbContext dbContext = new UmotaCompanyDbContext(optionsBuilder.Options))
            {
                var results = await dbContext.CariKarts
                                        .Take(100)
                                        .OrderByDescending(x => x.Insdate)
                                        .ProjectTo<CariKartDto>(Mapper.ConfigurationProvider).ToListAsync();

                return results;
            }
        }

        public async Task<CariKartDto> GetCariKartByKod(string kod, string firmaId)
        {
            if (string.IsNullOrEmpty(firmaId))
                throw new Exception("Firma Dönem seçimi yapınız");

            var connectionstring = Configuration.GetUmotaConnectionString(firmaId: firmaId);
            var optionsBuilder = new DbContextOptionsBuilder<UmotaCompanyDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);

            using (UmotaCompanyDbContext dbContext = new UmotaCompanyDbContext(optionsBuilder.Options))
            {
                IQueryable<CariKartDto> qry = dbContext.CariKarts.Where(i => i.Kodu == kod)
                            .ProjectTo<CariKartDto>(Mapper.ConfigurationProvider);

                return await qry.SingleOrDefaultAsync();
            }
        }

        public async Task<CariKartDto> SaveCariKart(CariKartRequestDto request)
        {
            
            var connectionstring = Configuration.GetUmotaConnectionString(firmaId: request.FirmaId.ToString());
            var optionsBuilder = new DbContextOptionsBuilder<UmotaCompanyDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);

            using (UmotaCompanyDbContext dbContext = new UmotaCompanyDbContext(optionsBuilder.Options))
            {
                var cariKart = Mapper.Map<CariKart>(request.CariKart);
                await dbContext.CariKarts.AddAsync(cariKart);
                await dbContext.SaveChangesAsync();
                return Mapper.Map<CariKartDto>(cariKart);
            }
        }

        public async Task<CariKartDto> UpdateCariKart(CariKartRequestDto request)
        {
            var connectionstring = Configuration.GetUmotaConnectionString(firmaId: request.FirmaId.ToString());
            var optionsBuilder = new DbContextOptionsBuilder<UmotaCompanyDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);

            using (UmotaCompanyDbContext dbContext = new UmotaCompanyDbContext(optionsBuilder.Options))
            {
                var cariKartRow = await dbContext.CariKarts.Where(x => x.Kodu == request.CariKart.Kodu).SingleOrDefaultAsync();
                if (cariKartRow == null)
                    throw new Exception("Cari kart bulunamadı");

                Mapper.Map(request.CariKart, cariKartRow);
                await dbContext.SaveChangesAsync();

                return Mapper.Map<CariKartDto>(cariKartRow);
            }
        }

        public async Task<List<CariKartDto>> SearchCariKarts(CariKartRequestDto request)
        {
            var connectionstring = Configuration.GetUmotaConnectionString(firmaId: request.FirmaId.ToString());
            var optionsBuilder = new DbContextOptionsBuilder<UmotaCompanyDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);

            using (UmotaCompanyDbContext dbContext = new UmotaCompanyDbContext(optionsBuilder.Options))
            {
                var word = request.CariKart.Adi.ToLower();
                var results = await dbContext.CariKarts.Where(x =>
                        x.Adi.ToLower().Contains(word)
                        || x.Adi2.ToLower().Contains(word)
                        || x.Adres1.ToLower().Contains(word)
                        || x.Adres2.ToLower().Contains(word)
                        || x.Ilce.Contains(word)
                        || x.Web.Contains(word)
                        || x.Kodu.Contains(word))
                    .ProjectTo<CariKartDto>(Mapper.ConfigurationProvider).ToListAsync();

                return results;
            }
        }

        public async Task<CariKartDto> GetCariKart(int logref, string firmaId)
        {
            if (string.IsNullOrEmpty(firmaId))
                throw new Exception("Firma Dönem seçimi yapınız");

            var connectionstring = Configuration.GetUmotaConnectionString(firmaId: firmaId);
            var optionsBuilder = new DbContextOptionsBuilder<UmotaCompanyDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);

            using (UmotaCompanyDbContext dbContext = new UmotaCompanyDbContext(optionsBuilder.Options))
            {
                IQueryable<CariKartDto> qry = dbContext.CariKarts.Where(i => i.Logref == logref)
                            .ProjectTo<CariKartDto>(Mapper.ConfigurationProvider);

                return await qry.SingleOrDefaultAsync();
            }
        }
    }
}
