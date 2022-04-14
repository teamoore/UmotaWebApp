using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UmotaWebApp.Shared.ModelDto;

namespace UmotaWebApp.Server.Services.Infrastructure
{
    public interface ISisKullaniciService
    {
        public Task<List<SisKullaniciDto>> GetSisKullaniciList();

        public Task<SisKullaniciDto> GetSisKullanici(string kod);

        Task<SisKullaniciLoginResponseDto> Login(SisKullaniciLoginRequestDto request);
        public Task<int> GetKullaniciYetkisiByKullaniciKodu(string kullanicikodu, string yetkikodu);
        public Task<int> GetKullaniciMenuYetkisiByMenuAdi(string kullanicikodu, string menu_dfm, string hak_tipi);
        public Task<List<SisMenuProfilDto>> GetKullaniciGrupList();
        public Task<SisKullaniciDto> SaveKullanici(SisKullaniciRequestDto request);
        public Task<SisKullaniciDto> UpdateKullanici(SisKullaniciRequestDto request);
    }
}
