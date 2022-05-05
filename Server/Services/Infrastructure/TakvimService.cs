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
    public class TakvimService : ITakvimService
    {
        public IMapper Mapper { get; }
        public IConfiguration Configuration { get; }

        public TakvimService(IMapper mapper, IConfiguration configuration)
        {
            Mapper = mapper;
            Configuration = configuration;
        }

        public async Task<List<TakvimDto>> GetTakvimInformation(TakvimRequestDto request)
        {

            var connectionstring = Configuration.GetUmotaConnectionString(firmaId: request.FirmaId.ToString());
            var optionsBuilder = new DbContextOptionsBuilder<UmotaCompanyDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);

            using (UmotaCompanyDbContext dbContext = new UmotaCompanyDbContext(optionsBuilder.Options))
            {
                var results = await dbContext.Takvims.Where(x => x.Insuser == request.User)
                                .OrderByDescending(x => x.Tarih)
                                .Where(x => x.Tarih > DateTime.Now.AddDays(-30)
                                && x.Status == 0)                                
                                .ProjectTo<TakvimDto>(Mapper.ConfigurationProvider).ToListAsync();
                return results;
            }
        }

        public async Task<TakvimDto> SaveTakvim(TakvimRequestDto request)
        {
            var connectionstring = Configuration.GetUmotaConnectionString(firmaId: request.FirmaId.ToString());
            var optionsBuilder = new DbContextOptionsBuilder<UmotaCompanyDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);

            using (UmotaCompanyDbContext dbContext = new UmotaCompanyDbContext(optionsBuilder.Options))
            {
                var takvim = Mapper.Map<Takvim>(request.Takvim);

                await dbContext.Takvims.AddAsync(takvim);
                await dbContext.SaveChangesAsync();

                return Mapper.Map<TakvimDto>(takvim);
            }
        }

        public async Task<TakvimDto> UpdateTakvim(TakvimRequestDto request)
        {
            var connectionstring = Configuration.GetUmotaConnectionString(firmaId: request.FirmaId.ToString());
            var optionsBuilder = new DbContextOptionsBuilder<UmotaCompanyDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);

            using (UmotaCompanyDbContext dbContext = new UmotaCompanyDbContext(optionsBuilder.Options))
            {
                var takvimRow = await dbContext.Takvims.Where(x => x.Logref == request.Takvim.Logref).SingleOrDefaultAsync();
                if (takvimRow == null)
                    throw new Exception("Takvim kaydı bulunamadı");

                Mapper.Map(request.Takvim, takvimRow);
                await dbContext.SaveChangesAsync();

                return Mapper.Map<TakvimDto>(takvimRow);
            }
        }

        public async Task<TakvimDto> GetTakvim(short firmaId, int logref)
        {
            var connectionstring = Configuration.GetUmotaConnectionString(firmaId: firmaId.ToString());
            var optionsBuilder = new DbContextOptionsBuilder<UmotaCompanyDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);

            using (UmotaCompanyDbContext dbContext = new UmotaCompanyDbContext(optionsBuilder.Options))
            {
                var results = await dbContext.Takvims.Where(x => x.Logref == logref)
                    .ProjectTo<TakvimDto>(Mapper.ConfigurationProvider)
                    .SingleOrDefaultAsync();

                return results;
            }
        }
    }
}
