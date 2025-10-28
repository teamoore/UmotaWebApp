using AutoMapper;
using AutoMapper.QueryableExtensions;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Org.BouncyCastle.Asn1.Ocsp;
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
    public class SisMenuService : ISisMenuService
    {
        public IMapper Mapper { get; }
        public UmotaMasterDbContext db { get; }
        public IConfiguration Configuration { get; }

        public ISisKullaniciService KullaniciService { get; }

        public SisMenuService(IMapper mapper, UmotaMasterDbContext umotaMasterDbContext, IConfiguration configuration, ISisKullaniciService kullaniciService)
        {
            Mapper = mapper;
            db = umotaMasterDbContext;
            Configuration = configuration;
            KullaniciService = kullaniciService;
        }

        public async Task<List<SisMenuDto>> GetSisMenuler()
        {
            var menuler = await db.SisMenulers.OrderBy(i => i.MenuId)
                .ProjectTo<SisMenuDto>(Mapper.ConfigurationProvider).ToListAsync();

            if (menuler == null)
                throw new ApiException("Menüleri çekerken hata oluştu");

            return menuler;
        }
        public async Task<List<MenuItemDto>> GetMenuItems(string kullaniciKodu)
        {
            var kullanici = await KullaniciService.GetSisKullanici(kullaniciKodu);

            using (SqlConnection db = new SqlConnection(Configuration.GetUmotaConnectionString()))
            {
                db.Open();

                string Menuler = Configuration.GetUmotaObjectName("Menuler");

                string sql = $@"select 
                                 A.ID , A.ParentID, A.Modul, A.Secenek, A.Tanimi, A.HRef, A.SiraNo
                                ,A.GirisEkrani, A.imageName
                                from {Menuler} A with(nolock)
                                where A.Modul = 1
                {(kullanici == null || kullanici.isAdmin ? "" : $" AND A.ID IN (select aa.MenuID from [dbo].[KullaniciMenuHaklari] aa where aa.KullaniciID = {kullanici.ID} and HakTipi = 'sel'  union select aa.MenuID from [dbo].[KullaniciGrupMenuHaklari] aa where aa.GrupID = {kullanici.KullaniciMenuProfil} and HakTipi = 'sel' ) ")}  

                                order by A.ParentID, A.SiraNo";

                var result = await db.QueryAsync<MenuItemDto>(sql, commandType: CommandType.Text);

                db.Close();

                return result.ToList();
            }
        }

        public async Task<List<MenuItemDto>> GetAllMenusAsync()
        {
            using var con = new SqlConnection(Configuration.GetUmotaConnectionString());
            var menus = await con.QueryAsync<MenuItemDto>("SELECT ID, ParentID, Tanimi, GirisEkrani, imageName FROM [dbo].[Menuler] order by ParentID, SiraNo");
            return menus.ToList();
        }

        public async Task<List<KullaniciMenuYetkiDto>> GetUserPermissionsAsync(string kullaniciKodu)
        {
            using var con = new SqlConnection(Configuration.GetUmotaConnectionString());
            var sql = "SELECT b.Kodu KullaniciKodu, a.MenuID as MenuId, a.HakTipi as YetkiTuru FROM [dbo].[KullaniciMenuHaklari] a,  [dbo].[Kullanici] b WHERE a.KullaniciID = b.ID and b.Kodu = @kod";
            var result = await con.QueryAsync<KullaniciMenuYetkiDto>(sql, new { kod = kullaniciKodu });
            return result.ToList();
        }

        public async Task<bool> SavePermissionsAsync(string kullaniciKodu, List<KullaniciMenuYetkiDto> yetkiler)
        {
            var kullanici = await KullaniciService.GetSisKullanici(kullaniciKodu);

            using var db = new SqlConnection(Configuration.GetUmotaConnectionString());
            await db.OpenAsync();

            // 4️⃣ Eski yetkileri temizle, yenilerini ekle
            await db.ExecuteAsync("DELETE FROM [dbo].[KullaniciMenuHaklari] WHERE KullaniciID = @KullaniciID",  new { KullaniciID = kullanici.ID });

            const string insertSql = $@"INSERT INTO [dbo].[KullaniciMenuHaklari] (KullaniciID, MenuId, HakTipi)
                                       VALUES (@KullaniciID, @MenuID, @YetkiTuru)";

            using var tran = db.BeginTransaction();
            try
            {
                // map each yetki objesine KullaniciID ekleyecek anonim nesne koleksiyonu oluştur
                var parameters = yetkiler.Select(y => new {
                    KullaniciID = kullanici.ID,
                    MenuID = y.MenuID,
                    YetkiTuru = y.YetkiTuru
                });

                // Dapper bu koleksiyon için foreach gibi davranıp her öğeyi tek tek insert eder
                await db.ExecuteAsync(insertSql, parameters, transaction: tran);

                tran.Commit();
                await db.CloseAsync();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                await db.CloseAsync();
                // Hata mesajını logla veya fırlat
                throw; // veya Log(ex);
            }

            return true;
        }
    }
}
