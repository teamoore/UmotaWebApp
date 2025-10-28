using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UmotaWebApp.Shared.ModelDto;
using UmotaWebApp.Shared.ModelDto.Request;

namespace UmotaWebApp.Server.Services.Infrastructure
{
    public interface IMalzemeKartService
    {
        public Task<List<UrunDto>> GetMalzemeKarts(string firmaId);
        public Task<UrunDto> GetMalzemeKart(int logref, string firmaId);
        public Task<List<UrunDto>> SearchMalzemeKarts(MalzemeKartRequestDto request);
        public Task<MalzemeKartDto> SaveMalzemeKart(MalzemeKartRequestDto request);
        public Task<MalzemeKartDto> UpdateMalzemeKart(MalzemeKartRequestDto request);
        public Task<List<string>> GetFotoList(int urunId);
        public Task<List<SepetDto>> GetUserSepetList(string kullaniciKodu);
        public Task<List<SepetUrunDto>> GetSepetUrunList(string kullaniciKodu, string sepetAdi);
        public Task<int> DeleteUserSepet(string kullaniciKodu, string sepetAdi);
        public Task<int> DeleteSepetUrun(int urunId);
        public Task<int> SepetPost(SepetPostDto request);
        public Task<int> GetUserSepetCount(string kullaniciKodu);
        public Task<int> ExceldenUrunleriAktar(string excelFileName, string kullaniciKodu);
    }
}
