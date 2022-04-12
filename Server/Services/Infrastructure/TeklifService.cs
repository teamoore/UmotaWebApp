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
using UmotaWebApp.Shared.SharedConsts;

namespace UmotaWebApp.Server.Services.Infrastructure
{
    public class TeklifService : ITeklifService
    {
        public IMapper Mapper { get; }
        public IConfiguration Configuration { get; }
        private readonly DbConnection _sql;
        private ISisKullaniciService SisKullaniciService { get; }
        private IRefGenerator RefGeneratorService { get; }
        private IDovizService DovizService { get; }

        public TeklifService(IMapper mapper, IConfiguration configuration, DbConnection sql, ISisKullaniciService sisKullaniciService, IRefGenerator refGeneratorService, IDovizService dovizService)
        {
            Mapper = mapper;
            Configuration = configuration;
            _sql = sql;
            SisKullaniciService = sisKullaniciService;
            RefGeneratorService = refGeneratorService;
            DovizService = dovizService;
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
                    " from " + Configuration.GetUmotaObjectName("v009_teklif", firmaId:firmaId) + " a with(nolock) where 1=1 and a.revizyon = 0";

                var tumTeklifleriGormeYetkisi = await SisKullaniciService.GetKullaniciYetkisiByKullaniciKodu(kullanicikodu, KullaniciYetkiKodlari.TumTeklifleriGorebilir);
                if (tumTeklifleriGormeYetkisi == 0) 
                {
                    var kesinSiparisleriGormeYetkisi = await SisKullaniciService.GetKullaniciYetkisiByKullaniciKodu(kullanicikodu, KullaniciYetkiKodlari.KesinSiparisleriGorebilir);
                    string kullanici_tanimlari = Configuration.GetUmotaObjectName("kullanici_tanimlari", firmaId: firmaId);
                    sql += " and (";
                    sql += "    (insuser = '" + kullanicikodu + "')";
                    sql += " or exists (select aa.logref from " + kullanici_tanimlari + " aa with(nolock) where aa.teklifinsuserkodu = a.insuser and aa.kullanici_kodu = '" + kullanicikodu + "')";
                    sql += " or exists (select aa.logref from " + kullanici_tanimlari + " aa with(nolock) where aa.plasiyerkodu = a.temsilciadi COLLATE TURKISH_CI_AS and aa.kullanici_kodu = '" + kullanicikodu + "')";
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
            using (SqlConnection db = new SqlConnection(Configuration.GetUmotaConnectionString(request.FirmaId.ToString())))
            {
                db.Open();
                var p = new DynamicParameters();

                var sql = "select *, lodeme_plani LodemePlani, ilgili_adi IlgiliAdi, teslim_sekli TeslimSekli, teslim_tarihi TeslimTarihi, sevk_edilecek_bayi_adi SevkEdilecekBayiAdi, sevk_ilgilisi SevkIlgilisi" +
                    " from " + Configuration.GetUmotaObjectName("v009_teklif", firmaId: request.FirmaId.ToString()) + " a with(nolock) where 1=1 and a.revizyon = 0";

                var tumTeklifleriGormeYetkisi = await SisKullaniciService.GetKullaniciYetkisiByKullaniciKodu(request.kullanicikodu, KullaniciYetkiKodlari.TumTeklifleriGorebilir);
                if (tumTeklifleriGormeYetkisi == 0)
                {
                    var kesinSiparisleriGormeYetkisi = await SisKullaniciService.GetKullaniciYetkisiByKullaniciKodu(request.kullanicikodu, KullaniciYetkiKodlari.KesinSiparisleriGorebilir);
                    string kullanici_tanimlari = Configuration.GetUmotaObjectName("kullanici_tanimlari", firmaId: request.FirmaId.ToString());
                    sql += " and (";
                    sql += "    (insuser = '" + request.kullanicikodu + "')";
                    sql += " or exists (select aa.logref from " + kullanici_tanimlari + " aa with(nolock) where aa.teklifinsuserkodu = a.insuser and aa.kullanici_kodu = '" + request.kullanicikodu + "')";
                    sql += " or exists (select aa.logref from " + kullanici_tanimlari + " aa with(nolock) where aa.plasiyerkodu = a.temsilciadi COLLATE TURKISH_CI_AS and aa.kullanici_kodu = '" + request.kullanicikodu + "')";
                    if (kesinSiparisleriGormeYetkisi == 1)
                        sql += " or (duruminfo = '" + TeklifDurum.KesinSiparis + "') or  (duruminfo = '" + TeklifDurum.KesinSipLogoyaAktarildi + "')";
                    sql += " )";
                }

                if (!string.IsNullOrWhiteSpace(request.SearchText))
                {
                    sql += " and(";
                    sql += "    a.cariadi like @SearchText ";
                    sql += " or a.carikodu like @SearchText ";
                    sql += " or a.teklifno like @SearchText ";
                    sql += " or a.proje like @SearchText ";
                    sql += " or a.ilgili_adi like @SearchText ";
                    sql += " or a.duruminfo like @SearchText ";
                    sql += " or a.temsilciadi like @SearchText ";
                    sql += " or a.aciklama1 like @SearchText ";
                    sql += " or a.aciklama2 like @SearchText ";
                    sql += " or a.aciklama3 like @SearchText ";
                    sql += " or a.aciklama4 like @SearchText ";
                    sql += " or a.dovizdoku like @SearchText ";
                    sql += " )";

                    p.Add("@SearchText", value: "%" + request.SearchText + "%", dbType: DbType.String);
                }

                if (request.BaslangicTarih != null)
                {
                    sql += " and a.tarih >= @bastar ";
                    p.Add("@bastar", value: request.BaslangicTarih, dbType: DbType.DateTime);
                }

                if (request.BitisTarih != null)
                {
                    sql += " and a.tarih <= @bittar ";
                    p.Add("@bittar", value: request.BitisTarih, dbType: DbType.DateTime);
                }

                sql += " order by insdate desc";
                var result = await db.QueryAsync<TeklifDto>(sql, p, commandType: CommandType.Text);

                db.Close();

                return result.ToList();

            }

            //var connectionstring = Configuration.GetUmotaConnectionString(firmaId: request.FirmaId.ToString());
            //var optionsBuilder = new DbContextOptionsBuilder<UmotaCompanyDbContext>();
            //optionsBuilder.UseSqlServer(connectionstring);

            //using (UmotaCompanyDbContext dbContext = new UmotaCompanyDbContext(optionsBuilder.Options))
            //{
            //    var word = request.Teklif.Aciklama1.ToLower();

            //    return await dbContext.V009Teklifs.Where(x => x.Aciklama1.ToLower().Contains(word)
            //    || x.Aciklama2.ToLower().Contains(word)
            //    || x.Aciklama3.ToLower().Contains(word)
            //    || x.Aciklama3.ToLower().Contains(word)
            //    || x.Aciklama4.ToLower().Contains(word)
            //    || x.Teklifno.ToLower().Contains(word)
            //    || x.Tbelgeno.ToLower().Contains(word)
            //    || x.Lpersoneladi.ToLower().Contains(word)
            //    || x.Temsilciadi.ToLower().Contains(word)
            //    || x.LcariAdi.ToLower().Contains(word)
            //    || x.Cariadi.ToLower().Contains(word)
            //    || x.LcariKodu.ToLower().Contains(word)
            //    || x.Carikodu.ToLower().Contains(word)
            //    || x.Proje.ToLower().Contains(word)
            //    || x.IlgiliAdi.ToLower().Contains(word))
            //        .OrderByDescending(x => x.Tarih)
            //        .ProjectTo<TeklifDto>(Mapper.ConfigurationProvider).ToListAsync();
            //}
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
                    throw new ApiException("Teklif bulunamadı");

                //Teklif Para Birimi veya Döviz Kuru veya Genel iskonto oranı değişirse Detayı tekrar hesapla
                if (teklifRow.Dovizrefid != request.Teklif.Dovizrefid || teklifRow.Dovizkuruid != request.Teklif.Dovizkuruid || teklifRow.Gniskoran != request.Teklif.Gniskoran)
                {
                    var teklifDetayList = await dbContext.Teklifdetays.Where(x => x.Teklifref == request.Teklif.Logref && x.Status < 2).ToListAsync();
                    var toplamTutarID = new double();
                    var toplamTutarTL = new double();
                    var toplamTutarRD = new double();
                    var kdvMatrahID = new double();
                    var kdvMatrahTL = new double();
                    var kdvMatrahrd = new double();

                    foreach (var teklifDetay in teklifDetayList)
                    {
                        teklifDetay.Iskyuz4 = request.Teklif.Gniskoran;

                        await CalculateTeklifDetay(request.Teklif, teklifDetay);

                        if (teklifDetay.Tutarid.HasValue)
                            toplamTutarID += teklifDetay.Tutarid.Value;

                        if (teklifDetay.Tutartl.HasValue)
                            toplamTutarTL += teklifDetay.Tutartl.Value;

                        if (teklifDetay.Tutarrd.HasValue)
                            toplamTutarRD += teklifDetay.Tutarrd.Value;

                        if (teklifDetay.Kdvmatrahid.HasValue)
                            kdvMatrahID += teklifDetay.Kdvmatrahid.Value;

                        if (teklifDetay.Kdvmatrahtl.HasValue)
                            kdvMatrahTL += teklifDetay.Kdvmatrahtl.Value;

                        if (teklifDetay.Kdvmatrahrd.HasValue)
                            kdvMatrahrd += teklifDetay.Kdvmatrahrd.Value;
                    }

                    request.Teklif.Tutar = toplamTutarID;
                    request.Teklif.Tutartl = toplamTutarTL;
                    request.Teklif.Tutarrd = toplamTutarRD;
                    request.Teklif.Tutarmatrah = kdvMatrahID;
                    request.Teklif.Tutarmatrahtl = kdvMatrahTL;
                    request.Teklif.Tutarmatrahrd = kdvMatrahrd;
                }

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
                var teklif = await dbContext.Teklifs.Where(x => x.Logref == request.Teklif.Logref).SingleOrDefaultAsync();
                if (teklif == null)
                    throw new ApiException("Teklif bulunamadı");

                if (teklif.Duruminfo.Equals(request.Teklif.Duruminfo) == false)
                    throw new ApiException("Teklifin Durumu sizden önce değiştirilmiş , işlem durdurulacak");

                var kullanici = SisKullaniciService.GetSisKullanici(request.kullanicikodu);
                var isAdmin = kullanici.Result.KullaniciYetkiKodu == "ADM";

                if (request.Teklif.Duruminfo == TeklifDurum.FinansalUygunlukBekleniyor && request.Teklif.NewDuruminfo == TeklifDurum.KesinSiparis && !isAdmin)
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

                if (request.Teklif.NewDuruminfo.Equals(TeklifDurum.MusteriTeklifteRevizeIstedi))
                {
                    if (teklif.Duruminfo.Equals(TeklifDurum.MusteriOnayiBekliyor) == false && teklif.Duruminfo.Equals(TeklifDurum.FinansalUygunlukBekleniyor) == false)
                        throw new ApiException("Teklifin durumu revizyon için uygun değil, işlem durdurulacak");

                    if (teklif.Revizyon.HasValue && teklif.Revizyon.Value > 0)
                        throw new ApiException("Teklif önceden revize edilmiş, işlem durdurulacak");

                    if (!teklif.Insuser.Equals(request.kullanicikodu))
                    {
                        bool SatisYoneticisiDegisiklikYapabilir = isAdmin;
                        bool SiparisiDegistirebilir = isAdmin;

                        if (!isAdmin)
                        {
                            var res = await SisKullaniciService.GetKullaniciYetkisiByKullaniciKodu(request.kullanicikodu, KullaniciYetkiKodlari.SatisYoneticisiDegisiklikYapabilir);
                            SatisYoneticisiDegisiklikYapabilir = res == 1;
                            res = await SisKullaniciService.GetKullaniciYetkisiByKullaniciKodu(request.kullanicikodu, KullaniciYetkiKodlari.SiparisiDegistirebilir);
                            SiparisiDegistirebilir = res == 1;
                        }

                        if (!teklif.Insuser.Equals(request.kullanicikodu) && !SiparisiDegistirebilir && !SatisYoneticisiDegisiklikYapabilir)
                        {
                            throw new ApiException("Bu Teklifi revize etmek için yetkiniz bulunamadı");
                        }
                    }


                    var newteklif = new Teklif();
                    newteklif.Logref = await RefGeneratorService.RefNoAl("teklif", request.FirmaId.ToString());
                    if (string.IsNullOrWhiteSpace(teklif.Revzno))
                    {
                        newteklif.Revzno = "Rev01";
                    }
                    else
                    {
                        var rev = teklif.Revzno.Substring(3, 2);
                        var revi = Convert.ToInt32(rev);
                        revi = revi + 1;
                        rev = revi.ToString("00");
                        newteklif.Revzno = "Rev" + rev;
                    }
                    newteklif.Teklifno = teklif.Teklifno;
                    newteklif.Revizyon = 0;
                    newteklif.Tarih = DateTime.Now;
                    newteklif.Saat = DateTime.Now;
                    newteklif.Caritip = teklif.Caritip;
                    newteklif.Cariref = teklif.Cariref;
                    newteklif.IlgiliAdi = teklif.IlgiliAdi;
                    newteklif.Proje = teklif.Proje;
                    newteklif.TeslimSekli = teklif.TeslimSekli;
                    newteklif.TeslimTarihi = teklif.TeslimTarihi;
                    newteklif.LodemePlani = teklif.LodemePlani;
                    newteklif.Lpersonelref = teklif.Lpersonelref;
                    newteklif.Gniskoran = teklif.Gniskoran;
                    newteklif.Dovizref = teklif.Dovizref;
                    newteklif.Dovizrefid = teklif.Dovizrefid;
                    newteklif.Notlar = teklif.Notlar;

                    newteklif.Trcode = teklif.Trcode;
                    newteklif.Duruminfo = TeklifDurum.TeklifRevizyonda;
                    newteklif.Status = 0;
                    newteklif.Insuser = request.kullanicikodu;
                    newteklif.Insdate = DateTime.Now;
                    newteklif.Upduser = null;
                    newteklif.Upddate = null;

                    var requestDovizKuru = new DovizKuruRequestDto();
                    requestDovizKuru.KurTarihi = newteklif.Tarih.Value;
                    requestDovizKuru.KurTuru = 4;
                    requestDovizKuru.DovizTuru = newteklif.Dovizref.Value;
                    requestDovizKuru.LogoFirmaNo = Convert.ToInt32(request.Teklif.Lfirma);

                    newteklif.Dovizkuru = await DovizService.LogoDovKurAl(requestDovizKuru);

                    requestDovizKuru.DovizTuru = newteklif.Dovizrefid.Value;
                    newteklif.Dovizkuruid = await DovizService.LogoDovKurAl(requestDovizKuru);

                    var teklifDetayList = await dbContext.Teklifdetays.Where(x => x.Teklifref == request.Teklif.Logref && x.Status < 2).OrderBy(x => x.Sipnosira).ToListAsync();
                    var toplamTutarID = new double();
                    var toplamTutarTL = new double();
                    var toplamTutarRD = new double();
                    var kdvMatrahID = new double();
                    var kdvMatrahTL = new double();
                    var kdvMatrahrd = new double();

                    foreach (var Detay in teklifDetayList)
                    {
                        var teklifDetay = new Teklifdetay();
                        teklifDetay.Status = 0;
                        teklifDetay.Insuser = request.kullanicikodu;
                        teklifDetay.Insdate = DateTime.Now;
                        teklifDetay.Logref = await RefGeneratorService.RefNoAl("teklifdetay", request.FirmaId.ToString());
                        teklifDetay.Teklifref = newteklif.Logref;
                        teklifDetay.Cizimkodu = Detay.Cizimkodu;
                        teklifDetay.Sipnosira = Detay.Sipnosira;
                        teklifDetay.LstokId = Detay.LstokId;
                        teklifDetay.LstokKodu = Detay.LstokKodu;
                        teklifDetay.LstokAdi = Detay.LstokAdi;
                        teklifDetay.Unitsetref = Detay.Unitsetref;
                        teklifDetay.Unitsetllogref = Detay.Unitsetllogref;
                        teklifDetay.Aciklama = Detay.Aciklama;
                        teklifDetay.Miktar = Detay.Miktar;
                        teklifDetay.Fiyat = Detay.Fiyat;
                        teklifDetay.Dovizref = Detay.Dovizref;
                        if (teklifDetay.Dovizref == newteklif.Dovizrefid)
                        {
                            teklifDetay.Dovizkuru = newteklif.Dovizkuruid;
                        }
                        else
                        if (teklifDetay.Dovizref == 160)
                        {
                            teklifDetay.Dovizkuru = 1;
                        }
                        else
                        {
                            requestDovizKuru.DovizTuru = teklifDetay.Dovizref.Value;
                            teklifDetay.Dovizkuru = await DovizService.LogoDovKurAl(requestDovizKuru);
                        }
                        teklifDetay.Ebat = Detay.Ebat;
                        teklifDetay.Marka = Detay.Marka;
                        teklifDetay.Mensei = Detay.Mensei;

                        teklifDetay.Maliyet1 = Detay.Maliyet1;
                        teklifDetay.Maliyet2 = Detay.Maliyet2;
                        teklifDetay.Kdvyuz = Detay.Kdvyuz;
                        teklifDetay.Iskyuz1 = Detay.Iskyuz1;
                        teklifDetay.Iskyuz2 = Detay.Iskyuz2;
                        teklifDetay.Iskyuz3 = Detay.Iskyuz3;
                        teklifDetay.Iskyuz4 = Detay.Iskyuz4;

                        await CalculateTeklifDetay(request.Teklif, teklifDetay);

                        if (teklifDetay.Tutarid.HasValue)
                            toplamTutarID += teklifDetay.Tutarid.Value;

                        if (teklifDetay.Tutartl.HasValue)
                            toplamTutarTL += teklifDetay.Tutartl.Value;

                        if (teklifDetay.Tutarrd.HasValue)
                            toplamTutarRD += teklifDetay.Tutarrd.Value;

                        if (teklifDetay.Kdvmatrahid.HasValue)
                            kdvMatrahID += teklifDetay.Kdvmatrahid.Value;

                        if (teklifDetay.Kdvmatrahtl.HasValue)
                            kdvMatrahTL += teklifDetay.Kdvmatrahtl.Value;

                        if (teklifDetay.Kdvmatrahrd.HasValue)
                            kdvMatrahrd += teklifDetay.Kdvmatrahrd.Value;

                        await dbContext.Teklifdetays.AddAsync(teklifDetay);
                    }

                    newteklif.Tutar = toplamTutarID;
                    newteklif.Tutartl = toplamTutarTL;
                    newteklif.Tutarrd = toplamTutarRD;
                    newteklif.Tutarmatrah = kdvMatrahID;
                    newteklif.Tutarmatrahtl = kdvMatrahTL;
                    newteklif.Tutarmatrahrd = kdvMatrahrd;
                    await dbContext.Teklifs.AddAsync(newteklif);

                    // Yeni Teklif Durum Detayına ekle
                    var teklifDurum = new TeklifDurumDetay();
                    teklifDurum.Aciklama = "";
                    teklifDurum.Tarih = DateTime.Now;
                    teklifDurum.Teklifref = newteklif.Logref;
                    teklifDurum.Duruminfo = newteklif.Duruminfo;
                    teklifDurum.KullaniciKodu = request.kullanicikodu;
                    await dbContext.TeklifDurumDetays.AddAsync(teklifDurum);


                    // Eski Teklif Güncelle ve Durum Detayına ekle
                    request.Teklif.Revizyon = 1;
                    request.Teklif.Aciklama1 = "Revize edilmiş";
                    request.Teklif.Duruminfo = request.Teklif.NewDuruminfo;

                    teklifDurum = new TeklifDurumDetay();
                    teklifDurum.Aciklama = !string.IsNullOrWhiteSpace(request.Teklif.TeklifDurumAciklama) ? request.Teklif.TeklifDurumAciklama : "Revizyona uğradı, arşive kalktı";
                    teklifDurum.Tarih = DateTime.Now;
                    teklifDurum.Teklifref = request.Teklif.Logref;
                    teklifDurum.Duruminfo = request.Teklif.NewDuruminfo;
                    teklifDurum.KullaniciKodu = request.Teklif.Upduser;
                    await dbContext.TeklifDurumDetays.AddAsync(teklifDurum);

                    Mapper.Map(request.Teklif, teklif);
                    await dbContext.SaveChangesAsync();

                    return Mapper.Map<TeklifDto>(newteklif);
                }
                else
                {
                    var teklifDurum = new TeklifDurumDetay();
                    teklifDurum.Aciklama = request.Teklif.TeklifDurumAciklama;
                    teklifDurum.Tarih = DateTime.Now;
                    teklifDurum.Teklifref = request.Teklif.Logref;
                    teklifDurum.Duruminfo = request.Teklif.NewDuruminfo;
                    teklifDurum.KullaniciKodu = request.Teklif.Upduser;

                    await dbContext.TeklifDurumDetays.AddAsync(teklifDurum);

                    request.Teklif.Duruminfo = request.Teklif.NewDuruminfo;

                    Mapper.Map(request.Teklif, teklif);
                    await dbContext.SaveChangesAsync();

                    return Mapper.Map<TeklifDto>(teklif);
                }
            }
        }
        public async Task<bool> DeleteTeklif(int logref, string firmaId, string kullanici)
        {
            if (string.IsNullOrEmpty(firmaId))
                throw new Exception("Firma Dönem seçimi yapınız");

            var connectionstring = Configuration.GetUmotaConnectionString(firmaId: firmaId);
            var optionsBuilder = new DbContextOptionsBuilder<UmotaCompanyDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);

            using (UmotaCompanyDbContext dbContext = new UmotaCompanyDbContext(optionsBuilder.Options))
            {
                var row = await dbContext.Teklifs.Where(x => x.Logref == logref)
                .FirstOrDefaultAsync();
                if (row == null)
                    throw new Exception("Silinecek kayıt bulunamadı");

                var teklifDetayList = await dbContext.Teklifdetays.Where(x => x.Teklifref == logref && x.Status < 2).ToListAsync();

                foreach (var teklifDetay in teklifDetayList)
                {
                    teklifDetay.Status = 2;
                    teklifDetay.Upddate = DateTime.Now;
                    teklifDetay.Upduser = kullanici;
                }

                row.Status = 2;
                row.Upddate = DateTime.Now;
                row.Upduser = kullanici;

                await dbContext.SaveChangesAsync();

                return true;
            }


        }
        public async Task<List<TeklifDurumDetayDto>> GetTeklifDurumDetay(int teklifref, string firmaId)
        {
            if (string.IsNullOrEmpty(firmaId))
                throw new Exception("Firma Dönem seçimi yapınız");

            var connectionstring = Configuration.GetUmotaConnectionString(firmaId: firmaId);
            var optionsBuilder = new DbContextOptionsBuilder<UmotaCompanyDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);

            using (UmotaCompanyDbContext dbContext = new UmotaCompanyDbContext(optionsBuilder.Options))
            {
                var results = await dbContext.TeklifDurumDetays.Where(x => x.Teklifref == teklifref)
                                        .OrderBy(x => x.Tarih)
                                        .ProjectTo<TeklifDurumDetayDto>(Mapper.ConfigurationProvider).ToListAsync();

                return results;
            }
        }
        public async Task<TeklifDto> TeklifKopyalaRevizeEt(TeklifRequestDto request)
        {
            var connectionstring = Configuration.GetUmotaConnectionString(firmaId: request.FirmaId.ToString());
            var optionsBuilder = new DbContextOptionsBuilder<UmotaCompanyDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);

            using (UmotaCompanyDbContext dbContext = new UmotaCompanyDbContext(optionsBuilder.Options))
            {
                var teklif = await dbContext.Teklifs.Where(x => x.Logref == request.Teklif.Logref).SingleOrDefaultAsync();
                if (teklif == null)
                    throw new ApiException("Teklif bulunamadı");

                if (teklif.Revizyon.HasValue && teklif.Revizyon.Value > 0)
                    throw new ApiException("Teklif önceden revize edilmiş, işlem durdurulacak");

                if (teklif.Duruminfo.Equals(TeklifDurum.MusteriOnayiBekliyor) == false && teklif.Duruminfo.Equals(TeklifDurum.FinansalUygunlukBekleniyor) == false)
                    throw new ApiException("Teklifin Durumu revizyon için uygun değil, işlem durdurulacak");

                var kullanici = SisKullaniciService.GetSisKullanici(request.kullanicikodu);
                var isAdmin = kullanici.Result.KullaniciYetkiKodu == "ADM";
                bool SatisYoneticisiDegisiklikYapabilir = isAdmin;
                bool SiparisiDegistirebilir = isAdmin;

                if (!isAdmin)
                {
                    var res = await SisKullaniciService.GetKullaniciYetkisiByKullaniciKodu(request.kullanicikodu, KullaniciYetkiKodlari.SatisYoneticisiDegisiklikYapabilir);
                    SatisYoneticisiDegisiklikYapabilir = res == 1;
                    res = await SisKullaniciService.GetKullaniciYetkisiByKullaniciKodu(request.kullanicikodu, KullaniciYetkiKodlari.SiparisiDegistirebilir);
                    SiparisiDegistirebilir = res == 1;
                }

                if (!teklif.Insuser.Equals(request.kullanicikodu) && !SiparisiDegistirebilir && !SatisYoneticisiDegisiklikYapabilir)
                {
                   throw new ApiException("Bu Teklifi revize etmek için yetkiniz bulunamadı");
                }

                var newteklif = new Teklif();
                newteklif.Logref = await RefGeneratorService.RefNoAl("teklif", request.FirmaId.ToString());
                if (string.IsNullOrWhiteSpace(teklif.Revzno))
                {
                    newteklif.Revzno = "Rev01";
                } else
                {
                    var rev = teklif.Revzno.Substring(3, 2);
                    var revi = Convert.ToInt32(rev);
                    revi = revi + 1;
                    rev = revi.ToString("00");
                    newteklif.Revzno = "Rev" + rev;
                }
                newteklif.Teklifno = teklif.Teklifno;
                newteklif.Revizyon = 0;
                newteklif.Tarih = DateTime.Now;
                newteklif.Saat = DateTime.Now;
                newteklif.Caritip = teklif.Caritip;
                newteklif.Cariref = teklif.Cariref;
                newteklif.IlgiliAdi = teklif.IlgiliAdi;
                newteklif.Proje = teklif.Proje;
                newteklif.TeslimSekli = teklif.TeslimSekli;
                newteklif.TeslimTarihi = teklif.TeslimTarihi;
                newteklif.LodemePlani = teklif.LodemePlani;
                newteklif.Lpersonelref = teklif.Lpersonelref;
                newteklif.Gniskoran = teklif.Gniskoran;
                newteklif.Dovizref = teklif.Dovizref;
                newteklif.Dovizrefid = teklif.Dovizrefid;
                newteklif.Notlar = teklif.Notlar;

                newteklif.Trcode = teklif.Trcode;
                newteklif.Duruminfo = TeklifDurum.TeklifRevizyonda;
                newteklif.Status = 0;
                newteklif.Insuser = request.kullanicikodu;
                newteklif.Insdate = DateTime.Now;
                newteklif.Upduser = null;
                newteklif.Upddate = null;

                var requestDovizKuru = new DovizKuruRequestDto();
                requestDovizKuru.KurTarihi = newteklif.Tarih.Value;
                requestDovizKuru.KurTuru = 4;
                requestDovizKuru.DovizTuru = newteklif.Dovizref.Value;
                requestDovizKuru.LogoFirmaNo =  Convert.ToInt32(request.Teklif.Lfirma);

                newteklif.Dovizkuru = await DovizService.LogoDovKurAl(requestDovizKuru);

                requestDovizKuru.DovizTuru = newteklif.Dovizrefid.Value;
                newteklif.Dovizkuruid = await DovizService.LogoDovKurAl(requestDovizKuru);

                var teklifDetayList = await dbContext.Teklifdetays.Where(x => x.Teklifref == request.Teklif.Logref && x.Status < 2).OrderBy(x => x.Sipnosira).ToListAsync();
                var toplamTutarID = new double();
                var toplamTutarTL = new double();
                var toplamTutarRD = new double();
                var kdvMatrahID = new double();
                var kdvMatrahTL = new double();
                var kdvMatrahrd = new double();

                foreach (var Detay in teklifDetayList)
                {
                    var teklifDetay = new Teklifdetay();
                    teklifDetay.Status = 0;
                    teklifDetay.Insuser = request.kullanicikodu;
                    teklifDetay.Insdate = DateTime.Now;
                    teklifDetay.Logref = await RefGeneratorService.RefNoAl("teklifdetay", request.FirmaId.ToString());
                    teklifDetay.Teklifref = newteklif.Logref;
                    teklifDetay.Cizimkodu = Detay.Cizimkodu;
                    teklifDetay.Sipnosira = Detay.Sipnosira;
                    teklifDetay.LstokId = Detay.LstokId;
                    teklifDetay.LstokKodu = Detay.LstokKodu;
                    teklifDetay.LstokAdi = Detay.LstokAdi;
                    teklifDetay.Unitsetref = Detay.Unitsetref;
                    teklifDetay.Unitsetllogref = Detay.Unitsetllogref;
                    teklifDetay.Aciklama = Detay.Aciklama;
                    teklifDetay.Miktar = Detay.Miktar;
                    teklifDetay.Fiyat = Detay.Fiyat;
                    teklifDetay.Dovizref = Detay.Dovizref;
                    if (teklifDetay.Dovizref == newteklif.Dovizrefid)
                    {
                        teklifDetay.Dovizkuru = newteklif.Dovizkuruid;
                    }
                    else
                    if (teklifDetay.Dovizref == 160)
                    {
                        teklifDetay.Dovizkuru = 1;
                    }
                    else
                    {
                        requestDovizKuru.DovizTuru = teklifDetay.Dovizref.Value;
                        teklifDetay.Dovizkuru = await DovizService.LogoDovKurAl(requestDovizKuru);
                    }
                    teklifDetay.Ebat = Detay.Ebat;
                    teklifDetay.Marka = Detay.Marka;
                    teklifDetay.Mensei = Detay.Mensei;

                    teklifDetay.Maliyet1 = Detay.Maliyet1;
                    teklifDetay.Maliyet2 = Detay.Maliyet2;
                    teklifDetay.Kdvyuz = Detay.Kdvyuz;
                    teklifDetay.Iskyuz1 = Detay.Iskyuz1;
                    teklifDetay.Iskyuz2 = Detay.Iskyuz2;
                    teklifDetay.Iskyuz3 = Detay.Iskyuz3;
                    teklifDetay.Iskyuz4 = Detay.Iskyuz4;

                    await CalculateTeklifDetay(request.Teklif, teklifDetay);

                    if (teklifDetay.Tutarid.HasValue)
                        toplamTutarID += teklifDetay.Tutarid.Value;

                    if (teklifDetay.Tutartl.HasValue)
                        toplamTutarTL += teklifDetay.Tutartl.Value;

                    if (teklifDetay.Tutarrd.HasValue)
                        toplamTutarRD += teklifDetay.Tutarrd.Value;

                    if (teklifDetay.Kdvmatrahid.HasValue)
                        kdvMatrahID += teklifDetay.Kdvmatrahid.Value;

                    if (teklifDetay.Kdvmatrahtl.HasValue)
                        kdvMatrahTL += teklifDetay.Kdvmatrahtl.Value;

                    if (teklifDetay.Kdvmatrahrd.HasValue)
                        kdvMatrahrd += teklifDetay.Kdvmatrahrd.Value;

                    await dbContext.Teklifdetays.AddAsync(teklifDetay);
                }

                newteklif.Tutar = toplamTutarID;
                newteklif.Tutartl = toplamTutarTL;
                newteklif.Tutarrd = toplamTutarRD;
                newteklif.Tutarmatrah = kdvMatrahID;
                newteklif.Tutarmatrahtl = kdvMatrahTL;
                newteklif.Tutarmatrahrd = kdvMatrahrd;
                await dbContext.Teklifs.AddAsync(newteklif);

                // Yeni Teklif Durum Detayına ekle
                var teklifDurum = new TeklifDurumDetay();
                teklifDurum.Aciklama = "";
                teklifDurum.Tarih = DateTime.Now;
                teklifDurum.Teklifref = newteklif.Logref;
                teklifDurum.Duruminfo = newteklif.Duruminfo;
                teklifDurum.KullaniciKodu = request.kullanicikodu;
                await dbContext.TeklifDurumDetays.AddAsync(teklifDurum);

                // Eski Teklif Güncelle Durum Detayına ekle
                teklif.Revizyon = 1;
                teklif.Aciklama1 = "Revize edilmiş";

                teklifDurum = new TeklifDurumDetay();
                teklifDurum.Aciklama = "Revizyona uğradı , arşive kalktı";
                teklifDurum.Tarih = DateTime.Now;
                teklifDurum.Teklifref = teklif.Logref;
                teklifDurum.Duruminfo = teklif.Duruminfo;
                teklifDurum.KullaniciKodu = request.kullanicikodu;
                await dbContext.TeklifDurumDetays.AddAsync(teklifDurum);

                await dbContext.SaveChangesAsync();
                return Mapper.Map<TeklifDto>(newteklif);
            }
        }
        private async Task CalculateTeklifDetay(TeklifDto teklif, Teklifdetay teklifDetay)
        {
            if (teklifDetay.Miktar.HasValue && teklifDetay.Fiyat.HasValue)
                teklifDetay.Tutar = Math.Round(teklifDetay.Miktar.Value * teklifDetay.Fiyat.Value, 2);
            else
                teklifDetay.Tutar = 0;

            if (teklifDetay.Iskyuz1.HasValue)
                teklifDetay.Isktut1 = Math.Round((teklifDetay.Tutar.Value * teklifDetay.Iskyuz1.Value) / 100, 2);
            else
                teklifDetay.Isktut1 = 0;

            if (teklifDetay.Iskyuz2.HasValue)
                teklifDetay.Isktut2 = Math.Round(((teklifDetay.Tutar.Value - teklifDetay.Isktut1.Value) * teklifDetay.Iskyuz2.Value) / 100, 2);
            else
                teklifDetay.Isktut2 = 0;

            if (teklifDetay.Iskyuz3.HasValue)
                teklifDetay.Isktut3 = Math.Round(((teklifDetay.Tutar.Value - teklifDetay.Isktut2.Value - teklifDetay.Isktut1.Value) * teklifDetay.Iskyuz3.Value) / 100, 2);
            else
                teklifDetay.Isktut3 = 0;

            if (teklifDetay.Iskyuz4.HasValue)
                teklifDetay.Isktut4 = Math.Round(((teklifDetay.Tutar.Value - teklifDetay.Isktut2.Value - teklifDetay.Isktut1.Value - teklifDetay.Isktut3.Value) * teklifDetay.Iskyuz4.Value) / 100, 2);
            else
                teklifDetay.Isktut4 = 0;

            teklifDetay.Kdvmatrah = teklifDetay.Tutar.Value - teklifDetay.Isktut1.Value - teklifDetay.Isktut2.Value - teklifDetay.Isktut3.Value - teklifDetay.Isktut4.Value;
            teklifDetay.Kdvtut = Math.Round((teklifDetay.Kdvmatrah.Value * (teklifDetay.Kdvyuz.HasValue ? teklifDetay.Kdvyuz.Value : 0)) / 100, 2);
            teklifDetay.Nettutar = teklifDetay.Kdvmatrah.Value + teklifDetay.Kdvtut.Value;

            if (teklifDetay.Dovizref == 160)
            {
                teklifDetay.Fiyattl = teklifDetay.Fiyat;
                teklifDetay.Tutartl = teklifDetay.Tutar.Value;
                teklifDetay.Isktut1tl = teklifDetay.Isktut1.Value;
                teklifDetay.Isktut2tl = teklifDetay.Isktut2.Value;
                teklifDetay.Isktut3tl = teklifDetay.Isktut3.Value;
                teklifDetay.Isktut4tl = teklifDetay.Isktut4.Value;
                teklifDetay.Kdvmatrahtl = teklifDetay.Kdvmatrah.Value;
                teklifDetay.Kdvtuttl = teklifDetay.Kdvtut.Value;
                teklifDetay.Nettutartl = teklifDetay.Nettutar.Value;
            }
            else
            if (teklifDetay.Dovizkuru.HasValue)
            {
                teklifDetay.Fiyattl = Math.Round(teklifDetay.Fiyat.Value * teklifDetay.Dovizkuru.Value, 2);
                teklifDetay.Tutartl = Math.Round(teklifDetay.Tutar.Value * teklifDetay.Dovizkuru.Value, 2);
                teklifDetay.Isktut1tl = Math.Round(teklifDetay.Isktut1.Value * teklifDetay.Dovizkuru.Value, 2);
                teklifDetay.Isktut2tl = Math.Round(teklifDetay.Isktut2.Value * teklifDetay.Dovizkuru.Value, 2);
                teklifDetay.Isktut3tl = Math.Round(teklifDetay.Isktut3.Value * teklifDetay.Dovizkuru.Value, 2);
                teklifDetay.Isktut4tl = Math.Round(teklifDetay.Isktut4.Value * teklifDetay.Dovizkuru.Value, 2);
                teklifDetay.Kdvmatrahtl = Math.Round(teklifDetay.Kdvmatrah.Value * teklifDetay.Dovizkuru.Value, 2);
                teklifDetay.Kdvtuttl = Math.Round(teklifDetay.Kdvtut.Value * teklifDetay.Dovizkuru.Value, 2);
                teklifDetay.Nettutartl = Math.Round(teklifDetay.Nettutar.Value * teklifDetay.Dovizkuru.Value, 2);
            }
            else
            {
                teklifDetay.Fiyattl = 0;
                teklifDetay.Tutartl = 0;
                teklifDetay.Isktut1tl = 0;
                teklifDetay.Isktut2tl = 0;
                teklifDetay.Isktut3tl = 0;
                teklifDetay.Isktut4tl = 0;
                teklifDetay.Kdvmatrahtl = 0;
                teklifDetay.Kdvtuttl = 0;
                teklifDetay.Nettutartl = 0;
            }

            if (teklifDetay.Dovizref == teklif.Dovizrefid)
            {
                teklifDetay.Tutarid = teklifDetay.Tutar.Value;
                teklifDetay.Isktut1id = teklifDetay.Isktut1.Value;
                teklifDetay.Isktut2id = teklifDetay.Isktut2.Value;
                teklifDetay.Isktut3id = teklifDetay.Isktut3.Value;
                teklifDetay.Isktut4id = teklifDetay.Isktut4.Value;
                teklifDetay.Kdvmatrahid = teklifDetay.Kdvmatrah.Value;
                teklifDetay.Kdvtutid = teklifDetay.Kdvtut.Value;
                teklifDetay.Nettutarid = teklifDetay.Nettutar.Value;
            }
            else
            if (teklif.Dovizkuruid.HasValue)
            {
                teklifDetay.Tutarid = Math.Round(teklifDetay.Tutartl.Value / teklif.Dovizkuruid.Value, 2);
                teklifDetay.Isktut1id = Math.Round(teklifDetay.Isktut1tl.Value / teklif.Dovizkuruid.Value, 2);
                teklifDetay.Isktut2id = Math.Round(teklifDetay.Isktut2tl.Value / teklif.Dovizkuruid.Value, 2);
                teklifDetay.Isktut3id = Math.Round(teklifDetay.Isktut3tl.Value / teklif.Dovizkuruid.Value, 2);
                teklifDetay.Isktut4id = Math.Round(teklifDetay.Isktut4tl.Value / teklif.Dovizkuruid.Value, 2);
                teklifDetay.Kdvmatrahid = Math.Round(teklifDetay.Kdvmatrahtl.Value / teklif.Dovizkuruid.Value, 2);
                teklifDetay.Kdvtutid = Math.Round(teklifDetay.Kdvtuttl.Value / teklif.Dovizkuruid.Value, 2);
                teklifDetay.Nettutarid = Math.Round(teklifDetay.Nettutartl.Value / teklif.Dovizkuruid.Value, 2);
            }
            else
            {
                teklifDetay.Tutarid = 0;
                teklifDetay.Isktut1id = 0;
                teklifDetay.Isktut2id = 0;
                teklifDetay.Isktut3id = 0;
                teklifDetay.Isktut4id = 0;
                teklifDetay.Kdvmatrahid = 0;
                teklifDetay.Kdvtutid = 0;
                teklifDetay.Nettutarid = 0;
            }

            if (teklifDetay.Dovizref == teklif.Dovizref)
            {
                teklifDetay.Tutarrd = teklifDetay.Tutar.Value;
                teklifDetay.Isktut1rd = teklifDetay.Isktut1.Value;
                teklifDetay.Isktut2rd = teklifDetay.Isktut2.Value;
                teklifDetay.Isktut3rd = teklifDetay.Isktut3.Value;
                teklifDetay.Isktut4rd = teklifDetay.Isktut4.Value;
                teklifDetay.Kdvmatrahrd = teklifDetay.Kdvmatrah.Value;
                teklifDetay.Kdvtutrd = teklifDetay.Kdvtut.Value;
                teklifDetay.Nettutarrd = teklifDetay.Nettutar.Value;
            }
            else
            if (teklif.Dovizkuru.HasValue)
            {
                teklifDetay.Tutarrd = Math.Round(teklifDetay.Tutartl.Value / teklif.Dovizkuru.Value, 2);
                teklifDetay.Isktut1rd = Math.Round(teklifDetay.Isktut1tl.Value / teklif.Dovizkuru.Value, 2);
                teklifDetay.Isktut2rd = Math.Round(teklifDetay.Isktut2tl.Value / teklif.Dovizkuru.Value, 2);
                teklifDetay.Isktut3rd = Math.Round(teklifDetay.Isktut3tl.Value / teklif.Dovizkuru.Value, 2);
                teklifDetay.Isktut4rd = Math.Round(teklifDetay.Isktut4tl.Value / teklif.Dovizkuru.Value, 2);
                teklifDetay.Kdvmatrahrd = Math.Round(teklifDetay.Kdvmatrahtl.Value / teklif.Dovizkuru.Value, 2);
                teklifDetay.Kdvtutrd = Math.Round(teklifDetay.Kdvtuttl.Value / teklif.Dovizkuru.Value, 2);
                teklifDetay.Nettutarrd = Math.Round(teklifDetay.Nettutartl.Value / teklif.Dovizkuru.Value, 2);
            }
            else
            {
                teklifDetay.Tutarrd = 0;
                teklifDetay.Isktut1rd = 0;
                teklifDetay.Isktut2rd = 0;
                teklifDetay.Isktut3rd = 0;
                teklifDetay.Isktut4rd = 0;
                teklifDetay.Kdvmatrahrd = 0;
                teklifDetay.Kdvtutrd = 0;
                teklifDetay.Nettutarrd = 0;
            }

            if (teklifDetay.Dovizref == teklif.Dovizrefid)
            {
                teklifDetay.Maliyet1id = teklifDetay.Maliyet1.Value;
                teklifDetay.Maliyet2id = teklifDetay.Maliyet2.Value;
            }
            else
            if (teklif.Dovizkuruid.HasValue)
            {
                teklifDetay.Maliyet1id = Math.Round(teklifDetay.Maliyet1.Value * teklifDetay.Dovizkuru.Value / teklif.Dovizkuruid.Value, 2);
                teklifDetay.Maliyet2id = Math.Round(teklifDetay.Maliyet2.Value * teklifDetay.Dovizkuru.Value / teklif.Dovizkuruid.Value, 2);
            }
            else
            {
                teklifDetay.Maliyet1id = 0;
                teklifDetay.Maliyet2id = 0;
            }


        }
    }
}
