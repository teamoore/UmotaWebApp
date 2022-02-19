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

        public async Task<CariKartDto> SaveCariKart(CariKartDto cari)
        {
            var cariKart = Mapper.Map<CariKart>(cari);
            await Db.CariKarts.AddAsync(cariKart);
            await Db.SaveChangesAsync();
            return Mapper.Map<CariKartDto>(cariKart);
        }

        public async Task<CariKartDto> GetCariKartByKod(string kod)
        {
            IQueryable<CariKartDto> qry = Db.CariKarts.Where(i => i.Kodu == kod)
                .ProjectTo<CariKartDto>(Mapper.ConfigurationProvider);

            return await qry.SingleOrDefaultAsync();
        }

        public async Task<CariKartDto> UpdateCariKart(CariKartDto cari)
        {
            var cariKart = await Db.CariKarts.Where(x => x.Kodu == cari.Kodu).SingleOrDefaultAsync();
            if (cariKart == null)
                throw new Exception("Cari kart bulunamadı");

            Mapper.Map(cari, cariKart);
            await Db.SaveChangesAsync();

            return Mapper.Map<CariKartDto>(cariKart);
        }

        public async Task<List<CariKartDto>> SearchCariKarts(CariKartDto cari)
        {
            var word = cari.Adi.ToLower();
            var results = await Db.CariKarts.Where(x => 
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
}
