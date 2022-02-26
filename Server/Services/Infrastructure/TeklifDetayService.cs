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
using UmotaWebApp.Shared.CustomException;
using UmotaWebApp.Shared.ModelDto;

namespace UmotaWebApp.Server.Services.Infrastructure
{
    public class TeklifDetayService : ITeklifDetayService
    {
        public IMapper Mapper { get; }
        public IConfiguration Configuration { get; }

        public TeklifDetayService(IMapper mapper,IConfiguration configuration)
        {
            Mapper = mapper;            
            Configuration = configuration;
        }

        public async Task<TeklifDetayDto> GetTeklifDetay(int logref, string firmaId)
        {
            if (string.IsNullOrEmpty(firmaId))
                throw new Exception("Firma Dönem seçimi yapınız");

            var connectionstring = Configuration.GetUmotaConnectionString(firmaId: firmaId);
            var optionsBuilder = new DbContextOptionsBuilder<UmotaCompanyDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);

            using (UmotaCompanyDbContext dbContext = new UmotaCompanyDbContext(optionsBuilder.Options))
            {
                return await dbContext.Teklifdetays.Where(x => x.Logref == logref)
                        .ProjectTo<TeklifDetayDto>(Mapper.ConfigurationProvider).SingleOrDefaultAsync();
            }
        }

        public async Task<List<TeklifDetayDto>> GetTeklifDetays(int teklifRef, string firmaId)
        {
            if (string.IsNullOrEmpty(firmaId))
                throw new Exception("Firma Dönem seçimi yapınız");

            var connectionstring = Configuration.GetUmotaConnectionString(firmaId: firmaId);
            var optionsBuilder = new DbContextOptionsBuilder<UmotaCompanyDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);

            using (UmotaCompanyDbContext dbContext = new UmotaCompanyDbContext(optionsBuilder.Options))
            {
                return await dbContext.Teklifdetays.Where(x => x.Teklifref.Value == teklifRef)
                        .ProjectTo<TeklifDetayDto>(Mapper.ConfigurationProvider).ToListAsync();
            }
        }

        public async Task<TeklifDetayDto> UpdateTeklifDetay(TeklifDetayRequestDto request)
        {            
            var connectionstring = Configuration.GetUmotaConnectionString(firmaId: request.FirmaId.ToString());
            var optionsBuilder = new DbContextOptionsBuilder<UmotaCompanyDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);

            using (UmotaCompanyDbContext dbContext = new UmotaCompanyDbContext(optionsBuilder.Options))
            {
                var teklifDetayRow = await dbContext.Teklifdetays.Where(x => x.Logref == request.TeklifDetay.Logref).SingleOrDefaultAsync();
                if (teklifDetayRow == null)
                    throw new ApiException("Teklif Detayı bulunamadı");

                Mapper.Map(request.TeklifDetay, teklifDetayRow);
                await dbContext.SaveChangesAsync();

                return Mapper.Map<TeklifDetayDto>(teklifDetayRow);
            }



        }

        public async Task<TeklifDetayDto> SaveTeklifDetay(TeklifDetayRequestDto request)
        {

            var connectionstring = Configuration.GetUmotaConnectionString(firmaId: request.FirmaId.ToString());
            var optionsBuilder = new DbContextOptionsBuilder<UmotaCompanyDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);

            using (UmotaCompanyDbContext dbContext = new UmotaCompanyDbContext(optionsBuilder.Options))
            {
                request.TeklifDetay = await CalculateTeklifDetay(request.TeklifDetay);

                var teklifDetayRow = Mapper.Map<Teklifdetay>(request.TeklifDetay);
                await dbContext.Teklifdetays.AddAsync(teklifDetayRow);
                await dbContext.SaveChangesAsync();

                await CalculateTeklif(request.TeklifDetay.Teklifref.Value, request.FirmaId.ToString());

                return Mapper.Map<TeklifDetayDto>(teklifDetayRow);
            }


        }

        private async Task<TeklifDetayDto> CalculateTeklifDetay(TeklifDetayDto td)
        {
            td.Tutar = td.Miktar * td.Fiyat;
            return await Task.FromResult(td);
        }

        private async Task CalculateTeklif(int teklifRef, string firmaId)
        {

            if (string.IsNullOrEmpty(firmaId))
                throw new Exception("Firma Dönem seçimi yapınız");

            var connectionstring = Configuration.GetUmotaConnectionString(firmaId: firmaId);
            var optionsBuilder = new DbContextOptionsBuilder<UmotaCompanyDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);

            using (UmotaCompanyDbContext dbContext = new UmotaCompanyDbContext(optionsBuilder.Options))
            {
                var teklifDetayList = await dbContext.Teklifdetays.Where(x => x.Teklifref == teklifRef).ToListAsync();
                var toplamTutar = new double();
                var toplamTutarTL = new double();

                foreach (var item in teklifDetayList)
                {
                    if (item.Miktar.HasValue && item.Fiyat.HasValue)
                        toplamTutar = toplamTutar + (item.Miktar.Value * item.Fiyat.Value);
                    if (item.Miktar.HasValue && item.Fiyattl.HasValue)
                        toplamTutarTL = toplamTutarTL + (item.Miktar.Value * item.Fiyattl.Value);
                }

                var teklif = await dbContext.Teklifs.Where(x => x.Logref == teklifRef).SingleOrDefaultAsync();

                teklif.Tutar = toplamTutar;
                teklif.Tutartl = toplamTutarTL;

                await dbContext.SaveChangesAsync();
            }


        }

        public async Task<bool> DeleteTeklifDetay(int logref, string firmaId)
        {
            if (string.IsNullOrEmpty(firmaId))
                throw new Exception("Firma Dönem seçimi yapınız");

            var connectionstring = Configuration.GetUmotaConnectionString(firmaId: firmaId);
            var optionsBuilder = new DbContextOptionsBuilder<UmotaCompanyDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);

            using (UmotaCompanyDbContext dbContext = new UmotaCompanyDbContext(optionsBuilder.Options))
            {
                var row = await dbContext.Teklifdetays.Where(x => x.Logref == logref)
                .FirstOrDefaultAsync();
                if (row == null)
                    throw new Exception("Silinecek teklif detayı bulunamadı");

                var teklifRef = row.Teklifref;

                dbContext.Teklifdetays.Attach(row);
                dbContext.Teklifdetays.Remove(row);
                await dbContext.SaveChangesAsync();

                if (!teklifRef.HasValue)
                    throw new Exception("Teklif detayı silinirken hata oluştu");

                // teklif detayı silindikten sonra teklif tutarı güncelle
                await CalculateTeklif(teklifRef.Value, firmaId);

                return true;
            }


        }
    }
}
