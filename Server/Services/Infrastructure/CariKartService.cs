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

    public class CariKartService : ICariKartService
    {
        public IMapper Mapper { get; }
        public UmotaCompanyDbContext Db { get; }
        public IConfiguration Configuration { get; }

        public CariKartService(IConfiguration configuration, UmotaCompanyDbContext db, IMapper mapper)
        {
            Configuration = configuration;
            Db = db;
            Mapper = mapper;
        }

        public async Task<List<CariKartDto>> GetCariKartDtos()
        {
            var results = await Db.CariKarts.ProjectTo<CariKartDto>(Mapper.ConfigurationProvider).ToListAsync();

            return results;
        }
    }
}
