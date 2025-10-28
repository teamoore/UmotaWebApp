using AutoMapper;
using AutoMapper.QueryableExtensions;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UmotaWebApp.Server.Data.Models;
using UmotaWebApp.Server.Extensions;
using UmotaWebApp.Shared.CustomException;
using UmotaWebApp.Shared.ModelDto;

namespace UmotaWebApp.Server.Services.Infrastructure
{
    public class SisKullaniciService : ISisKullaniciService
    {
        public IMapper Mapper { get; }
        public UmotaMasterDbContext MasterDbContext { get; }
        public IConfiguration Configuration { get; }
             
        public SisKullaniciService(IMapper mapper, UmotaMasterDbContext masterDbContext, IConfiguration configuration)
        {
            Mapper = mapper;
            MasterDbContext = masterDbContext;
            Configuration = configuration;
        }

        public string SifreDegistir(string sifre)
        {
            if (string.IsNullOrWhiteSpace(sifre)) { return ""; }

            // SELECT char(ASCII('1')^20) SQL Versiyonu bu şekilde
            string res = sifre;
            int len = sifre.Length;
            char[] chars = res.ToCharArray();

            for (int i = 0; i <=chars.Length-1; i++)
            {
                var c1 = chars[i].ToString();
                var c2 = Encoding.ASCII.GetBytes(c1)[0];
                var c3 = c2 ^ 20;
                var c4 = (char)c3;

                chars[i] = c4;
            }

            return new string(chars);
        }
        public async Task<SisKullaniciDto> GetSisKullanici(string kod)
        {
            using (SqlConnection db = new SqlConnection(Configuration.GetUmotaConnectionString()))
            {
                db.Open();

                var sql = @$"select top 1 A.ID, 
                            A.Kodu as KullaniciKodu, A.Adi as KullaniciAdi, A.Sifre KullaniciSifre,
                            A.Iptal as KullaniciIptal, A.Rol As KullaniciYetkiKodu, A.MailAdres as MailAdres,
                            A.GrupID as KullaniciMenuProfil, B.Adi As KullaniciMenuProfilAdi
                     from {Configuration.GetUmotaObjectName("Kullanici")} A 
                     left outer join {Configuration.GetUmotaObjectName("KullaniciGrup")} B on (A.GrupID = B.ID) 
                     
                     where A.Kodu = '{kod}' ";

                var result = await db.QueryAsync<SisKullaniciDto>(sql, commandType: CommandType.Text);

                db.Close();

                return result.SingleOrDefault();
            }
        }

        public async Task<List<SisKullaniciDto>> GetSisKullaniciList()
        {
            using (SqlConnection db = new SqlConnection(Configuration.GetUmotaConnectionString()))
            {
                db.Open();

                var sql = @$"select
                            A.Kodu as KullaniciKodu, A.Adi as KullaniciAdi, A.Sifre KullaniciSifre,
                            A.Iptal as KullaniciIptal, A.Rol As KullaniciYetkiKodu, A.MailAdres as MailAdres,
                            A.GrupID as KullaniciMenuProfil, B.Adi As KullaniciMenuProfilAdi
                     from {Configuration.GetUmotaObjectName("Kullanici")} A 
                     left outer join {Configuration.GetUmotaObjectName("KullaniciGrup")} B on (A.GrupID = B.ID) 
                     
                      ";

                var result = await db.QueryAsync<SisKullaniciDto>(sql, commandType: CommandType.Text);

                db.Close();

                return result.ToList();
            }
        }

        public Task<SisKullaniciLoginResponseDto> Login(SisKullaniciLoginRequestDto request)
        {
            var kullanici = GetSisKullanici(request.Kod).Result;

            if (kullanici == null)
                throw new Exception("Tanımsız Kullanıcı Kodu");

            if (kullanici.KullaniciIptal)
               throw new Exception("Kullanıcı bulunamadı");

            var hashedPassword = SifreDegistir(request.Sifre);

            if (hashedPassword != kullanici.KullaniciSifre)
               throw new Exception("Şifre hatalı");

            //var kullanici_donem_yetki = await MasterDbContext.SisFirmaDonemYetkis.Where(x => x.Kodu == kullanici.KullaniciKodu)
            //    .ProjectTo<SisFirmaDonemYetkiDto>(Mapper.ConfigurationProvider).ToListAsync();

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtSecurityKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(int.Parse(Configuration["JwtExpiresInDay"].ToString()));

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, kullanici.KullaniciKodu)
            };

            var token = new JwtSecurityToken(Configuration["JwtIssuer"], Configuration["JwtAudience"], claims, null, expires, creds);

            string tokenStr = new JwtSecurityTokenHandler().WriteToken(token);


            var response = new SisKullaniciLoginResponseDto();
            response.ApiToken = tokenStr;
            response.KullaniciDto = kullanici;
            //response.KullaniciFirmaDonemYetkiListesi = kullanici_donem_yetki;

            return Task.FromResult(response);
        }

        public async Task<int> GetKullaniciYetkisiByKullaniciKodu(string kullanicikodu, string yetkikodu)
        {
            using (SqlConnection db = new SqlConnection(Configuration.GetUmotaConnectionString()))
            {
                var sql = @$"IF EXISTS(select 1
                                        from dbo.KullaniciYetkiKodlari a with(nolock)
		                                inner join [dbo].[Kullanici] b with(nolock) on a.KullaniciID = b.ID
		                                inner join [dbo].[YetkiKodlari] c with(nolock) on a.YetkiID = c.ID
                                        where b.Kodu = @KullaniciKodu 
                                        and c.Kodu = @YetkiKodu
                                         )
	                                select 1
                                ELSE
	                                select 0 ";

                int say = await db.ExecuteScalarAsync<int>(sql, new { KullaniciKodu = kullanicikodu, YetkiKodu = yetkikodu });

                db.Close();

                return say;
            }

        }
        public async Task<int> GetKullaniciMenuYetkisiByMenuAdi(string kullanicikodu, string menu_dfm, string hak_tipi)
        {
            using (SqlConnection db = new SqlConnection(Configuration.GetUmotaConnectionString()))
            {
                var p = new DynamicParameters();
                p.Add("@kullanici_kodu", kullanicikodu);
                p.Add("@menu_dfm", menu_dfm);
                p.Add("@hak_tipi", hak_tipi);
                p.Add("@ReturnValue", dbType: DbType.Int32, direction: ParameterDirection.ReturnValue);

                await db.ExecuteAsync("GetKullaniciMenuYetkisiByMenuAdi", p, commandType: CommandType.StoredProcedure);

                int c = p.Get<int>("@ReturnValue");

                return c;

            }

        }
        public async Task<List<SisMenuProfilDto>> GetKullaniciGrupList()
        {
            using (SqlConnection db = new SqlConnection(Configuration.GetUmotaConnectionString()))
            {
                db.Open();

                var sql = @$"select
                            A.ID as ProfilId, A.Adi as ProfilAdi
                     from {Configuration.GetUmotaObjectName("KullaniciGrup")} A ";

                var result = await db.QueryAsync<SisMenuProfilDto>(sql, commandType: CommandType.Text);

                db.Close();

                return result.ToList();
            }
        }
        public async Task<SisKullaniciDto> SaveKullanici(SisKullaniciRequestDto request)
        {
            request.SisKullanici.KullaniciSifre = SifreDegistir(request.SisKullanici.KullaniciSifre);

            using (SqlConnection db = new SqlConnection(Configuration.GetUmotaConnectionString()))
            {
                db.Open();

                var sql = @$"INSERT INTO [dbo].[Kullanici]
                                ([Kodu],[Adi],[Sifre],[Rol],[GrupID]
                                ,[Iptal],[MailAdres],[MailSifre]
                                ,[LogoUserName],[LogoPassword])
                        VALUES
                            (@Kodu, @Adi, @Sifre, @Rol, @GrupID
                            ,@Iptal, @MailAdres, @MailSifre
                            ,@LogoUserName, @LogoPassword) ";

                var p = new DynamicParameters();
                p.Add("@Kodu", request.SisKullanici.KullaniciKodu);
                p.Add("@Adi", request.SisKullanici.KullaniciAdi);
                p.Add("@Sifre", request.SisKullanici.KullaniciSifre);
                p.Add("@Rol", request.SisKullanici.KullaniciYetkiKodu);
                p.Add("@GrupID", request.SisKullanici.KullaniciMenuProfil);
                p.Add("@MailAdres", request.SisKullanici.MailAdres);
                p.Add("@MailSifre", request.SisKullanici.MailSifre);
                p.Add("@LogoUserName", request.SisKullanici.LogoUsername);
                p.Add("@LogoPassword", request.SisKullanici.LogoPassword);
                p.Add("@Iptal", request.SisKullanici.KullaniciIptal);

                await db.ExecuteAsync(sql, p, commandType: CommandType.Text);

                db.Close();

            }

            return request.SisKullanici;
        }
        public async Task<SisKullaniciDto> UpdateKullanici(SisKullaniciRequestDto request)
        {
            var kullanici = await GetSisKullanici(request.SisKullanici.KullaniciKodu);
            if (kullanici == null)
                throw new Exception("Kart bulunamadı");

            if (!request.SisKullanici.KullaniciSifre.Equals(kullanici.KullaniciSifre))
                request.SisKullanici.KullaniciSifre = SifreDegistir(request.SisKullanici.KullaniciSifre);

            using (SqlConnection db = new SqlConnection(Configuration.GetUmotaConnectionString()))
            {
                db.Open();

                var sql = @$"UPDATE [dbo].[Kullanici]
                           SET [Kodu] = @Kodu
                              ,[Adi] = @Adi
                              ,[Sifre] = @Sifre
                              ,[Rol] = @Rol
                              ,[GrupID] = @GrupID
                              ,[Iptal] = @Iptal
                              ,[MailAdres] = @MailAdres
                              ,[MailSifre] = @MailSifre
                              ,[LogoUserName] = @LogoUserName
                              ,[LogoPassword] = @LogoPassword
                         WHERE Kodu = @Kodu ";

                var p = new DynamicParameters();
                p.Add("@Kodu", request.SisKullanici.KullaniciKodu);
                p.Add("@Adi", request.SisKullanici.KullaniciAdi);
                p.Add("@Sifre", request.SisKullanici.KullaniciSifre);
                p.Add("@Rol", request.SisKullanici.KullaniciYetkiKodu);
                p.Add("@GrupID", request.SisKullanici.KullaniciMenuProfil);
                p.Add("@MailAdres", request.SisKullanici.MailAdres);
                p.Add("@MailSifre", request.SisKullanici.MailSifre);
                p.Add("@LogoUserName", request.SisKullanici.LogoUsername);
                p.Add("@LogoPassword", request.SisKullanici.LogoPassword);
                p.Add("@Iptal", request.SisKullanici.KullaniciIptal);

                await db.ExecuteAsync(sql, p, commandType: CommandType.Text);

                db.Close();

            }

            return request.SisKullanici;
        }

        public async Task<List<KullaniciYetkiDto>> GetKullaniciYetkiList(string kullanicikodu)
        {
            var kullanici = await GetSisKullanici(kullanicikodu);
            if (kullanici == null)
                throw new Exception("Kart bulunamadı");

            using (SqlConnection db = new SqlConnection(Configuration.GetUmotaConnectionString()))
            {
                db.Open();

                var sql = @$"select
                            y.ID, y.Kodu, y.Adi,
                            CASE WHEN ky.YetkiID IS NOT NULL THEN 1 ELSE 0 END AS Secili
                            FROM [dbo].[YetkiKodlari] y
                            LEFT OUTER JOIN [dbo].[KullaniciYetkiKodlari] ky ON (ky.YetkiID = y.ID AND ky.KullaniciID = @KullaniciID)
                            ORDER BY y.Kodu ";

                var result = await db.QueryAsync<KullaniciYetkiDto>(sql, new { KullaniciID = kullanici.ID });

                db.Close();

                return result.ToList();
            }
        }

        public async Task<bool> PostKullaniciYetkiList(KullaniciYetkiPostDto request)
        {
            var kullanici = await GetSisKullanici(request.KullaniciKodu);
            if (kullanici == null)
                throw new Exception("Kart bulunamadı");

            using (SqlConnection db = new SqlConnection(Configuration.GetUmotaConnectionString()))
            {
                db.Open();

                var sql = @$"Delete from [dbo].[KullaniciYetkiKodlari]
                                Where KullaniciID = @KullaniciID";

                await db.ExecuteAsync(sql, new { KullaniciID = kullanici.ID });

                foreach (KullaniciYetkiDto item in request.YetkiKodlari)
                {
                    sql = @$"INSERT INTO [dbo].[KullaniciYetkiKodlari]
                                ([KullaniciID],[YetkiID])
                        VALUES
                            (@KullaniciID, @YetkiID) ";

                    await db.ExecuteAsync(sql, new { KullaniciID = kullanici.ID, YetkiID = item.ID });
                }

                db.Close();

            }

            return true;
        }



    }
}
