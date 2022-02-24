using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UmotaWebApp.Server.Data.Models;
using UmotaWebApp.Shared.CustomException;
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

        public async Task<TeklifDetayDto> UpdateTeklifDetay(TeklifDetayDto teklifDetayDto)
        {
            var teklifDetayRow = await Db.Teklifdetays.Where(x => x.Logref == teklifDetayDto.Logref).SingleOrDefaultAsync();
            if (teklifDetayRow == null)
                throw new ApiException("Teklif Detayı bulunamadı");

            Mapper.Map(teklifDetayDto, teklifDetayRow);
            await Db.SaveChangesAsync();

            return Mapper.Map<TeklifDetayDto>(teklifDetayRow);

        }

        public async Task<TeklifDetayDto> SaveTeklifDetay(TeklifDetayDto teklifDetayDto)
        {
            teklifDetayDto = await CalculateTeklifDetay(teklifDetayDto);

            var teklifDetayRow = Mapper.Map<Teklifdetay>(teklifDetayDto);
            await Db.Teklifdetays.AddAsync(teklifDetayRow);
            await Db.SaveChangesAsync();

            await CalculateTeklif(teklifDetayDto.Teklifref.Value);

            return Mapper.Map<TeklifDetayDto>(teklifDetayRow);
        }

        private async Task<TeklifDetayDto> CalculateTeklifDetay(TeklifDetayDto td)
        {
            td.Tutar = td.Miktar * td.Fiyat;
            return await Task.FromResult(td);
        }

        private async Task CalculateTeklif(int teklifRef)
        {
            var teklifDetayList = await Db.Teklifdetays.Where(x => x.Teklifref == teklifRef).ToListAsync();
            var toplamTutar = new double();
            var toplamTutarTL = new double();

            foreach (var item in teklifDetayList)
            {
                if (item.Miktar.HasValue && item.Fiyat.HasValue)
                    toplamTutar = toplamTutar + (item.Miktar.Value * item.Fiyat.Value);
                if (item.Miktar.HasValue && item.Fiyattl.HasValue)
                    toplamTutarTL = toplamTutarTL + (item.Miktar.Value * item.Fiyattl.Value);
            }

            var teklif = await Db.Teklifs.Where(x => x.Logref == teklifRef).SingleOrDefaultAsync();

            teklif.Tutar = toplamTutar;
            teklif.Tutartl = toplamTutarTL;

            await Db.SaveChangesAsync();
        }

        public async Task<bool> DeleteTeklifDetay(int logref)
        {
            var row = await Db.Teklifdetays.Where(x => x.Logref == logref)
                            .FirstOrDefaultAsync();
            if (row == null)
                throw new Exception("Silinecek teklif detayı bulunamadı");

            var teklifRef = row.Teklifref;

            Db.Teklifdetays.Attach(row);
            Db.Teklifdetays.Remove(row);
            await Db.SaveChangesAsync();

            if (!teklifRef.HasValue)
                throw new Exception("Teklif detayı silinirken hata oluştu");

            // teklif detayı silindikten sonra teklif tutarı güncelle
            await CalculateTeklif(teklifRef.Value);

            return true;
        }
    }
}
