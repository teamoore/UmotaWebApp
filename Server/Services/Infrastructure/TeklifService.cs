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
    public class TeklifService : ITeklifServiceService
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

        public async Task<TeklifDto> SaveTeklif(TeklifDto teklifDto)
        {
            var teklif = Mapper.Map<Teklif>(teklifDto);
            await Db.Teklifs.AddAsync(teklif);
            await Db.SaveChangesAsync();
            return Mapper.Map<TeklifDto>(teklif);
        }

        public async Task<List<TeklifDto>> SearchTeklif(TeklifDto teklif)
        {
            var word = teklif.Aciklama1.ToLower();

            return await Db.Teklifs.Where(x => x.Aciklama1.ToLower().Contains(word)
            || x.Aciklama2.ToLower().Contains(word)
            || x.Aciklama3.ToLower().Contains(word)
            || x.Aciklama3.ToLower().Contains(word)
            || x.Aciklama4.ToLower().Contains(word)
            || x.Teklifno.ToLower().Contains(word)
            || x.Tbelgeno.ToLower().Contains(word)
            || x.Lpersoneladi.ToLower().Contains(word)
            || x.LcariAdi.ToLower().Contains(word)
            || x.LcariKodu.ToLower().Contains(word))
                .OrderByDescending(x => x.Tarih)
                .ProjectTo<TeklifDto>(Mapper.ConfigurationProvider).ToListAsync();
        }
    }
}
