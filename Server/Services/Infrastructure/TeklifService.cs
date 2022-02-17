using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UmotaWebApp.Server.Data.Models;
using UmotaWebApp.Shared.ModelDto;

namespace UmotaWebApp.Server.Services.Infrastructure
{
    public class TeklifService : ITeklifService
    {
        public IMapper Mapper { get; }
        public UmotaCompanyDbContext Db { get; }
        public IConfiguration Configuration { get; }

        public TeklifService(IMapper mapper, UmotaCompanyDbContext db, IConfiguration configuration)
        {
            Mapper = mapper;
            Db = db;
            Configuration = configuration;
        }

        public async Task<TeklifDto> GetTeklifByRef(int logref)
        {
           return await Db.Teklifs.Where(i => i.Logref == logref)
                .ProjectTo<TeklifDto>(Mapper.ConfigurationProvider).SingleOrDefaultAsync();
        }

        public async Task<List<TeklifDto>> GetTeklifDtos()
        {
            return await Db.Teklifs.ProjectTo<TeklifDto>(Mapper.ConfigurationProvider).ToListAsync();
        }
    }
}
