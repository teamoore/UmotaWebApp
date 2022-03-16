using AutoMapper;
using AutoMapper.QueryableExtensions;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using UmotaWebApp.Server.Data.Models;
using UmotaWebApp.Server.Extensions;
using UmotaWebApp.Shared.Consts;
using UmotaWebApp.Shared.CustomException;
using UmotaWebApp.Shared.ModelDto;

namespace UmotaWebApp.Server.Services.Infrastructure
{
    public class TeklifService : ITeklifService
    {
        public IMapper Mapper { get; }
        public IConfiguration Configuration { get; }
        private readonly DbConnection _sql;
        private ISisKullaniciService SisKullaniciService { get; }

        public TeklifService(IMapper mapper, IConfiguration configuration, DbConnection sql, ISisKullaniciService sisKullaniciService)
        {
            Mapper = mapper;
            Configuration = configuration;
            _sql = sql;
            SisKullaniciService = sisKullaniciService;
        }

        public async Task<TeklifDto> GetTeklifByRef(int logref, string firma_id)
        {
            using (SqlConnection db = new SqlConnection(Configuration.GetUmotaConnectionString(firma_id)))
            {
                db.Open();

                var sql = "select top 1 *, lodeme_plani LodemePlani, ilgili_adi IlgiliAdi, teslim_sekli TeslimSekli, teslim_tarihi TeslimTarihi, sevk_edilecek_bayi_adi SevkEdilecekBayiAdi, sevk_ilgilisi SevkIlgilisi" +
                    " from " + Configuration.GetUmotaObjectName("v009_teklif", firmaId: firma_id) + " where logref=" + logref;

                var result = await db.QueryAsync<TeklifDto>(sql, commandType: CommandType.Text);

                db.Close();

                return result.SingleOrDefault();
            }
        }

        public async Task<List<TeklifDto>> GetTeklifDtos(string firmaId, string kullanicikodu)
        {
            using (SqlConnection db = new SqlConnection(Configuration.GetUmotaConnectionString(firmaId)))
            {
                db.Open();

                var sql = "select top 100 *, lodeme_plani LodemePlani, ilgili_adi IlgiliAdi, teslim_sekli TeslimSekli, teslim_tarihi TeslimTarihi, sevk_edilecek_bayi_adi SevkEdilecekBayiAdi, sevk_ilgilisi SevkIlgilisi" +
                    " from " + Configuration.GetUmotaObjectName("v009_teklif", firmaId:firmaId) + " a with(nolock) where 1=1";

                var tumTeklifleriGormeYetkisi = await SisKullaniciService.GetKullaniciYetkisiByKullaniciKodu(kullanicikodu, KullaniciYetkiKodlari.TumTeklifleriGorebilir);
                if (tumTeklifleriGormeYetkisi == 0) 
                {
                    var kesinSiparisleriGormeYetkisi = await SisKullaniciService.GetKullaniciYetkisiByKullaniciKodu(kullanicikodu, KullaniciYetkiKodlari.KesinSiparisleriGorebilir);
                    string kullanici_tanimlari = Configuration.GetUmotaObjectName("kullanici_tanimlari", firmaId: firmaId);
                    sql += " and (";
                    sql += "    (insuser = '" + kullanicikodu + "')";
                    sql += " or exists (select aa.logref from " + kullanici_tanimlari + " aa with(nolock) where aa.teklifinsuserkodu = a.insuser and aa.kullanici_kodu = '" + kullanicikodu + "')";
                    sql += " or exists (select aa.logref from " + kullanici_tanimlari + " aa with(nolock) where aa.plasiyerkodu = a.temsilciadi and aa.kullanici_kodu = '" + kullanicikodu + "')";
                    if (kesinSiparisleriGormeYetkisi == 1)
                        sql += " or (duruminfo = '"+ TeklifDurum.KesinSiparis +"') or  (duruminfo = '"+ TeklifDurum.KesinSipLogoyaAktarildi +"')";
                    sql += " )";
                }

                sql += " order by insdate desc";
                var result = await db.QueryAsync<TeklifDto>(sql, commandType: CommandType.Text);

                db.Close();

                return result.ToList();

            }

        }

        public async Task<TeklifDto> SaveTeklif(TeklifRequestDto request)
        {
            var connectionstring = Configuration.GetUmotaConnectionString(firmaId: request.FirmaId.ToString());
            var optionsBuilder = new DbContextOptionsBuilder<UmotaCompanyDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);

            using (UmotaCompanyDbContext dbContext = new UmotaCompanyDbContext(optionsBuilder.Options))
            {
                var teklif = Mapper.Map<Teklif>(request.Teklif);
                await dbContext.Teklifs.AddAsync(teklif);

                var tdd = new TeklifDurumDetay();
                tdd.Teklifref = teklif.Logref;
                tdd.Tarih = DateTime.Now;
                tdd.Duruminfo = teklif.Duruminfo;
                tdd.Aciklama = teklif.Aciklama1;
                tdd.KullaniciKodu = teklif.Insuser;

                await dbContext.TeklifDurumDetays.AddAsync(tdd);

                await dbContext.SaveChangesAsync();
                return Mapper.Map<TeklifDto>(teklif);
            }
        }

        public async Task<List<TeklifDto>> SearchTeklif(TeklifRequestDto request)
        {

            var connectionstring = Configuration.GetUmotaConnectionString(firmaId: request.FirmaId.ToString());
            var optionsBuilder = new DbContextOptionsBuilder<UmotaCompanyDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);

            using (UmotaCompanyDbContext dbContext = new UmotaCompanyDbContext(optionsBuilder.Options))
            {
                var word = request.Teklif.Aciklama1.ToLower();

                return await dbContext.V009Teklifs.Where(x => x.Aciklama1.ToLower().Contains(word)
                || x.Aciklama2.ToLower().Contains(word)
                || x.Aciklama3.ToLower().Contains(word)
                || x.Aciklama3.ToLower().Contains(word)
                || x.Aciklama4.ToLower().Contains(word)
                || x.Teklifno.ToLower().Contains(word)
                || x.Tbelgeno.ToLower().Contains(word)
                || x.Lpersoneladi.ToLower().Contains(word)
                || x.Temsilciadi.ToLower().Contains(word)
                || x.LcariAdi.ToLower().Contains(word)
                || x.Cariadi.ToLower().Contains(word)
                || x.LcariKodu.ToLower().Contains(word)
                || x.Carikodu.ToLower().Contains(word)
                || x.Proje.ToLower().Contains(word)
                || x.IlgiliAdi.ToLower().Contains(word))
                    .OrderByDescending(x => x.Tarih)
                    .ProjectTo<TeklifDto>(Mapper.ConfigurationProvider).ToListAsync();
            }


        }

        public async Task<TeklifDto> UpdateTeklif(TeklifRequestDto request)
        {

            var connectionstring = Configuration.GetUmotaConnectionString(firmaId: request.FirmaId.ToString());
            var optionsBuilder = new DbContextOptionsBuilder<UmotaCompanyDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);

            using (UmotaCompanyDbContext dbContext = new UmotaCompanyDbContext(optionsBuilder.Options))
            {
                var teklifRow = await dbContext.Teklifs.Where(x => x.Logref == request.Teklif.Logref).SingleOrDefaultAsync();
                if (teklifRow == null)
                    throw new ApiException("Teklif Detayı bulunamadı");

                // Güncellenen teklifi loga at
                var teklifLog = new TeklifLog();
                Mapper.Map(teklifRow, teklifLog);
                await dbContext.TeklifLogs.AddAsync(teklifLog);

                Mapper.Map(request.Teklif, teklifRow);
                await dbContext.SaveChangesAsync();

                return Mapper.Map<TeklifDto>(teklifRow);
            }


        }

        public async Task<TeklifDto> UpdateTeklifDurum(TeklifRequestDto request)
        {

            var connectionstring = Configuration.GetUmotaConnectionString(firmaId: request.FirmaId.ToString());
            var optionsBuilder = new DbContextOptionsBuilder<UmotaCompanyDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);

            using (UmotaCompanyDbContext dbContext = new UmotaCompanyDbContext(optionsBuilder.Options))
            {
                var teklifRow = await dbContext.Teklifs.Where(x => x.Logref == request.Teklif.Logref).SingleOrDefaultAsync();
                if (teklifRow == null)
                    throw new ApiException("Teklif bulunamadı");

                if (teklifRow.Duruminfo.Equals(request.Teklif.Duruminfo) == false)
                    throw new ApiException("Teklifin Durumu sizden önce değiştirilmiş , işlem durudurulacak");

                if (request.Teklif.NewDuruminfo == TeklifDurum.KesinSiparis)
                {
                    var teklif_finans_onay = await dbContext.TeklifFinansOnays
                        .Where(x => 
                            x.Bas <= request.Teklif.Tutarmatrahtl &&
                            x.Bit >= request.Teklif.Tutarmatrahtl &&
                            ( x.Onay1 == request.Teklif.Upduser || x.Onay2 == request.Teklif.Upduser || x.Onay3 == request.Teklif.Upduser )
                        ).SingleOrDefaultAsync();

                    if (teklif_finans_onay == null)
                        throw new ApiException("Finansal Uygunluk vermek için yetkiniz bulunamadı");
                }

                var teklifDurum = new TeklifDurumDetay();
                teklifDurum.Aciklama = request.Teklif.TeklifDurumAciklama;
                teklifDurum.Tarih = DateTime.Now;
                teklifDurum.Teklifref = request.Teklif.Logref;
                teklifDurum.Duruminfo = request.Teklif.NewDuruminfo;
                teklifDurum.KullaniciKodu = request.Teklif.Upduser;

                await dbContext.TeklifDurumDetays.AddAsync(teklifDurum);

                request.Teklif.Duruminfo = request.Teklif.NewDuruminfo;
                 
                Mapper.Map(request.Teklif, teklifRow);
                await dbContext.SaveChangesAsync();

                return Mapper.Map<TeklifDto>(teklifRow);
            }
        }

        
    }
}
