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
                                .ProjectTo<TakvimDto>(Mapper.ConfigurationProvider).ToListAsync();
                return results;
            }
        }
    }
}
