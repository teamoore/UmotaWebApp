using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using UmotaWebApp.Server.Data.Models;
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
               

        public async Task<SisKullaniciDto> GetSisKullanici(string kod)
        {
            var kullanici = await MasterDbContext.SisKullanicis.Where(x => x.KullaniciKodu == kod)
                .ProjectTo<SisKullaniciDto>(Mapper.ConfigurationProvider).FirstOrDefaultAsync();

            if (kullanici == null)
                throw new ApiException("Kullanıcı bulunamadı");

            return kullanici;
        }

        public async Task<List<SisKullaniciDto>> GetSisKullaniciList()
        {
            return await MasterDbContext.SisKullanicis
                .ProjectTo<SisKullaniciDto>(Mapper.ConfigurationProvider).ToListAsync();
        }

        public async Task<SisKullaniciLoginResponseDto> Login(SisKullaniciLoginRequestDto request)
        {
            var kullanici = await MasterDbContext.SisKullanicis.Where(x => x.KullaniciKodu == request.Kod && x.WebSifre == request.Sifre)
              .ProjectTo<SisKullaniciDto>(Mapper.ConfigurationProvider).FirstOrDefaultAsync();

            if (kullanici == null)
                throw new ApiException("Kullanıcı kodu ve/veya şifre hatalı girildi.");

            var kullanici_donem_yetki = await MasterDbContext.SisFirmaDonemYetkis.Where(x => x.Kodu == kullanici.KullaniciKodu)
                .ProjectTo<SisFirmaDonemYetkiDto>(Mapper.ConfigurationProvider).ToListAsync();

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
            response.KullaniciDto = Mapper.Map<SisKullaniciDto>(kullanici);
            response.KullaniciFirmaDonemYetkiListesi = kullanici_donem_yetki;

            return response;
        }

    }
}
