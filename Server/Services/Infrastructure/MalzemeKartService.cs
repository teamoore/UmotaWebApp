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
    public class MalzemeKartService : IMalzemeKartService
    {
        public IMapper Mapper { get; }
        public UmotaCompanyDbContext Db { get; }
        public IConfiguration Configuration { get; }

        public MalzemeKartService(IMapper mapper, UmotaCompanyDbContext db, IConfiguration configuration)
        {
            Mapper = mapper;
            Db = db;
            Configuration = configuration;
        }

        public async Task<MalzemeKartDto> GetMalzemeKart(int logref)
        {
            return await Db.MalzKarts.Where(i => i.Logref == logref)
                .ProjectTo<MalzemeKartDto>(Mapper.ConfigurationProvider).SingleOrDefaultAsync();
        }

        public async Task<List<MalzemeKartDto>> GetMalzemeKartList()
        {
            return await Db.MalzKarts.ProjectTo<MalzemeKartDto>(Mapper.ConfigurationProvider).ToListAsync();
        }
    }
}
