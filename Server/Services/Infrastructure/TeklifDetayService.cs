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
    public class TeklifDetayService : ITeklifDetayService
    {
        public IMapper Mapper { get; }
        public UmotaCompanyDbContext Db { get; }
        public IConfiguration Configuration { get; }

        public TeklifDetayService(IMapper mapper, UmotaCompanyDbContext db, IConfiguration configuration)
        {
            Mapper = mapper;
            Db = db;
            Configuration = configuration;
        }

        public async Task<TeklifDetayDto> GetTeklifDetay(int logref)
        {
            return await Db.Teklifdetays.Where(x => x.Logref == logref)
                .ProjectTo<TeklifDetayDto>(Mapper.ConfigurationProvider).SingleOrDefaultAsync();
        }

        public async Task<List<TeklifDetayDto>> GetTeklifDetays(int teklifRef)
        {
            return await Db.Teklifdetays.Where(x => x.Teklifref.Value == teklifRef)
                .ProjectTo<TeklifDetayDto>(Mapper.ConfigurationProvider).ToListAsync();
        }
    }
}
