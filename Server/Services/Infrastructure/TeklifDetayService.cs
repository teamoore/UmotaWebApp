using AutoMapper;
using AutoMapper.QueryableExtensions;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
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

            using (SqlConnection db = new SqlConnection(Configuration.GetUmotaConnectionString(firmaId)))
            {
                db.Open();

                var sql = "select top 1 *, lstok_id LstokId, lstok_kodu LstokKodu, lstok_adi LstokAdi, teslim_tarihi TeslimTarihi, filtre_har_ref FiltreHarRef, montaj_yeri MontajYeri" +
                    " from " + Configuration.GetUmotaObjectName("v010_teklifdetay", firmaId: firmaId) + " where logref=" + logref;

                var result = await db.QueryAsync<TeklifDetayDto>(sql, commandType: CommandType.Text);

                db.Close();

                return result.SingleOrDefault();

            }
        }

        public async Task<List<TeklifDetayDto>> GetTeklifDetays(int teklifRef, string firmaId)
        {
            if (string.IsNullOrEmpty(firmaId))
                throw new Exception("Firma Dönem seçimi yapınız");

            using (SqlConnection db = new SqlConnection(Configuration.GetUmotaConnectionString(firmaId)))
            {
                db.Open();

                var sql = "select *,lstok_id LstokId, lstok_kodu LstokKodu, lstok_adi LstokAdi, teslim_tarihi TeslimTarihi, filtre_har_ref FiltreHarRef, montaj_yeri MontajYeri " +
                    " from " + Configuration.GetUmotaObjectName("v010_teklifdetay", firmaId: firmaId) + " where teklifref=" + teklifRef;

                var result = await db.QueryAsync<TeklifDetayDto>(sql, commandType: CommandType.Text);

                db.Close();

                return result.ToList();

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

                //request.TeklifDetay = await CalculateTeklifDetay(request.TeklifDetay);
                Mapper.Map(request.TeklifDetay, teklifDetayRow);
                await dbContext.SaveChangesAsync();

                await CalculateTeklif(request.TeklifDetay.Teklifref.Value, request.FirmaId.ToString());

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
                //request.TeklifDetay = await CalculateTeklifDetay(request.TeklifDetay);

                var teklifDetayRow = Mapper.Map<Teklifdetay>(request.TeklifDetay);
                await dbContext.Teklifdetays.AddAsync(teklifDetayRow);
                await dbContext.SaveChangesAsync();

                await CalculateTeklif(request.TeklifDetay.Teklifref.Value, request.FirmaId.ToString());

                return Mapper.Map<TeklifDetayDto>(teklifDetayRow);
            }


        }

        private async Task<TeklifDetayDto> CalculateTeklifDetay(TeklifDetayDto td)
        {
            if (td.Miktar.HasValue && td.Fiyat.HasValue)
                td.Tutar = Math.Round(td.Miktar.Value * td.Fiyat.Value, 2);
            else
                td.Tutar = 0;

            if (td.Dovizkuru.HasValue)
                td.Tutartl = Math.Round(td.Tutar.Value * td.Dovizkuru.Value,2);

            if (td.Iskyuz1.HasValue)
                td.Isktut1 = (td.Tutar * td.Iskyuz1) / 100;               
            
            if (td.Iskyuz2.HasValue)
                td.Isktut2 = ((td.Tutar - td.Isktut1) * td.Iskyuz2) / 100;

            if (td.Iskyuz3.HasValue)
                td.Isktut3 = ((td.Tutar - td.Isktut2 - td.Isktut1) * td.Iskyuz3) / 100;

            if (td.Iskyuz4.HasValue)
                td.Isktut4 = ((td.Tutar - td.Isktut2 - td.Isktut1 - td.Isktut3) * td.Iskyuz4) / 100;
                        

            if (td.Isktut1.HasValue)
                td.Kdvmatrah = td.Tutar - td.Isktut1.Value;

            if (td.Isktut2.HasValue)
                td.Kdvmatrah = td.Tutar - td.Isktut2.Value;

            if (td.Isktut3.HasValue)
                td.Kdvmatrah = td.Tutar - td.Isktut3.Value;

            if (td.Isktut4.HasValue)
                td.Kdvmatrah = td.Tutar - td.Isktut4.Value;


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
                    if (item.Tutar.HasValue )
                        toplamTutar = toplamTutar + item.Tutar.Value;

                    if (item.Tutartl.HasValue)
                        toplamTutarTL = toplamTutarTL + item.Tutartl.Value;
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

        public async Task<string> GetTeklifDetaySiraNo(int teklifRef, string firmaId)
        {
            if (string.IsNullOrEmpty(firmaId))
                throw new Exception("Firma Dönem seçimi yapınız");

            using (SqlConnection db = new SqlConnection(Configuration.GetUmotaConnectionString(firmaId)))
            {
                db.Open();

                var sql = "select coalesce(max(sipnosira),'00000') as sipnosira from " +
                    Configuration.GetUmotaObjectName("TeklifDetay", firmaId: firmaId) + " where teklifref=" + teklifRef;

                var result = await db.ExecuteScalarAsync<string>("select dbo.GenerateNewCode(isnull(("+ sql +"),'00000')) as value"
                    , commandType: CommandType.Text);
           
                db.Close();

                return result;

            }
        }
    }
}
