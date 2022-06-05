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
using UmotaWebApp.Shared.ModelDto.Request;

namespace UmotaWebApp.Server.Services.Infrastructure
{
    public class VazifeService : IVazifeService
    {
        public IMapper Mapper { get; }
        public IConfiguration Configuration { get; }

        public VazifeService(IMapper mapper, IConfiguration configuration)
        {
            Mapper = mapper;
            Configuration = configuration;
        }
        public async Task<VazifeDto> GetVazife(short firmaId, int logref)
        {
            var connectionstring = Configuration.GetUmotaConnectionString(firmaId: firmaId.ToString());
            var optionsBuilder = new DbContextOptionsBuilder<UmotaCompanyDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);

            using (UmotaCompanyDbContext dbContext = new UmotaCompanyDbContext(optionsBuilder.Options))
            {
                var results = await dbContext.Vazifes.Where(x => x.Logref == logref)
                    .ProjectTo<VazifeDto>(Mapper.ConfigurationProvider)
                    .SingleOrDefaultAsync();

                return results;
            }
        }

        public async Task<List<VazifeDto>> GetVazifes(VazifeRequestDto request)
        {
            var connectionstring = Configuration.GetUmotaConnectionString(firmaId: request.FirmaId.ToString());
            var optionsBuilder = new DbContextOptionsBuilder<UmotaCompanyDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);

            using (UmotaCompanyDbContext dbContext = new UmotaCompanyDbContext(optionsBuilder.Options))
            {
                List<VazifeDto> results = null;

                if (request.AdminView == false)
                    results = await dbContext.Vazifes.Where(x => x.Insuser == request.User && x.Status == 0)
                                    .ProjectTo<VazifeDto>(Mapper.ConfigurationProvider).ToListAsync();
                else
                    results = await dbContext.Vazifes.Where(x => x.Status == 0)
                                .ProjectTo<VazifeDto>(Mapper.ConfigurationProvider).ToListAsync();
                return results;
            }
        }

        public async Task<VazifeDto> SaveVazife(VazifeRequestDto request)
        {
            var connectionstring = Configuration.GetUmotaConnectionString(firmaId: request.FirmaId.ToString());
            var optionsBuilder = new DbContextOptionsBuilder<UmotaCompanyDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);

            using (UmotaCompanyDbContext dbContext = new UmotaCompanyDbContext(optionsBuilder.Options))
            {
                var vazife = Mapper.Map<Vazife>(request.Vazife);

                await dbContext.Vazifes.AddAsync(vazife);
                await dbContext.SaveChangesAsync();

                return Mapper.Map<VazifeDto>(vazife);
            }
        }

        public async Task<VazifeDto> UpdateVazife(VazifeRequestDto request)
        {
            var connectionstring = Configuration.GetUmotaConnectionString(firmaId: request.FirmaId.ToString());
            var optionsBuilder = new DbContextOptionsBuilder<UmotaCompanyDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);

            using (UmotaCompanyDbContext dbContext = new UmotaCompanyDbContext(optionsBuilder.Options))
            {
                var row = await dbContext.Vazifes.Where(x => x.Logref == request.Vazife.Logref).SingleOrDefaultAsync();
                if (row == null)
                    throw new Exception("Takvim kaydı bulunamadı");

                Mapper.Map(request.Vazife, row);
                await dbContext.SaveChangesAsync();

                return Mapper.Map<VazifeDto>(row);
            }
        }

        public Task<int> GetVazifeCount(VazifeRequestDto request)
        {
            var connectionstring = Configuration.GetUmotaConnectionString(firmaId: request.FirmaId.ToString());
            var optionsBuilder = new DbContextOptionsBuilder<UmotaCompanyDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);

            using (UmotaCompanyDbContext dbContext = new UmotaCompanyDbContext(optionsBuilder.Options))
            {
                var results = dbContext.Vazifes.Where(x => x.Insuser == request.User && x.Status == 0 && x.Yapildi == 0).Count();
                return Task.FromResult(results);
            }
        }
    }
}
