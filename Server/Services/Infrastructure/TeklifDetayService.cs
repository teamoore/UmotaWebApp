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

                var teklifRow = await dbContext.Teklifs.Where(x => x.Logref == teklifDetayRow.Teklifref).SingleOrDefaultAsync();
                if (teklifRow == null)
                    throw new ApiException("Teklif bulunamadı");

                ValidateTeklif(teklifRow);

                // Güncellenen teklif detayını loga at
                var teklifDetayLog = new TeklifdetayLog();
                Mapper.Map(teklifDetayRow, teklifDetayLog);
                await dbContext.TeklifdetayLogs.AddAsync(teklifDetayLog);

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
                var teklifRow = await dbContext.Teklifs.Where(x => x.Logref == request.TeklifDetay.Teklifref).SingleOrDefaultAsync();
                if (teklifRow == null)
                    throw new ApiException("Teklif bulunamadı");

                ValidateTeklif(teklifRow);

                var teklifDetayRow = Mapper.Map<Teklifdetay>(request.TeklifDetay);
                await dbContext.Teklifdetays.AddAsync(teklifDetayRow);
                await dbContext.SaveChangesAsync();

                await CalculateTeklif(request.TeklifDetay.Teklifref.Value, request.FirmaId.ToString());

                return Mapper.Map<TeklifDetayDto>(teklifDetayRow);
            }


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
                var teklifDetayList = await dbContext.Teklifdetays.Where(x => x.Teklifref == teklifRef && x.Status < 2).ToListAsync();
                var toplamTutarID = new double();
                var toplamTutarTL = new double();
                var toplamTutarRD = new double();
                var kdvMatrahID = new double();
                var kdvMatrahTL = new double();
                var kdvMatrahrd = new double();

                foreach (var item in teklifDetayList)
                {
                    if (item.Tutarid.HasValue )
                        toplamTutarID += item.Tutarid.Value;

                    if (item.Tutartl.HasValue)
                        toplamTutarTL += item.Tutartl.Value;

                    if (item.Tutarrd.HasValue)
                        toplamTutarRD += item.Tutarrd.Value;

                    if (item.Kdvmatrahid.HasValue)
                        kdvMatrahID += item.Kdvmatrahid.Value;

                    if (item.Kdvmatrahtl.HasValue)
                        kdvMatrahTL += item.Kdvmatrahtl.Value;

                    if (item.Kdvmatrahrd.HasValue)
                        kdvMatrahrd += item.Kdvmatrahrd.Value;
                }

                var teklif = await dbContext.Teklifs.Where(x => x.Logref == teklifRef).SingleOrDefaultAsync();

                teklif.Tutar = toplamTutarID;
                teklif.Tutartl = toplamTutarTL;
                teklif.Tutarrd = toplamTutarRD;
                teklif.Tutarmatrah = kdvMatrahID;
                teklif.Tutarmatrahtl = kdvMatrahTL;
                teklif.Tutarmatrahrd = kdvMatrahrd;

                await dbContext.SaveChangesAsync();
            }


        }

        public async Task<bool> DeleteTeklifDetay(int logref, string firmaId, string kullanici)
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

                var teklifRow = await dbContext.Teklifs.Where(x => x.Logref == row.Teklifref).SingleOrDefaultAsync();
                if (teklifRow == null)
                    throw new Exception("Silinecek teklif detayına ait, teklif bulunamadı");

                ValidateBeforeDelete(teklifRow);

                var teklifRef = row.Teklifref;

                row.Status = 2;
                row.Upddate = DateTime.Now;
                row.Upduser = kullanici;
                                
                await dbContext.SaveChangesAsync();

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

        private void ValidateBeforeDelete(Teklif t)
        {
            if (!t.Duruminfo.Equals("Teklif Revizyonda") && !t.Duruminfo.Equals("Teklif Hazırlanıyor"))
                throw new ApiException("Teklif durumu silmek için uygun değil");

        }

        private void ValidateTeklif(Teklif t)
        {
            if (!t.Duruminfo.Equals("Teklif Revizyonda") && !t.Duruminfo.Equals("Teklif Hazırlanıyor"))
                throw new ApiException("Teklif durumu güncellemek için uygun değil");
        }
    }
}
