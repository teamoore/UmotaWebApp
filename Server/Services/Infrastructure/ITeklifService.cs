using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UmotaWebApp.Shared.ModelDto;
using UmotaWebApp.Shared.ServiceResponses;

namespace UmotaWebApp.Server.Services.Infrastructure
{
    public interface ITeklifService
    {
        public Task<List<TeklifDto>> GetTeklifDtos(string firmaId, string kullanicikodu, string duruminfo);
        public Task<TeklifDto> GetTeklifByRef(int logref, string firmaId);
        public Task<TeklifDto> SaveTeklif(TeklifRequestDto request);
        public Task<TeklifDto> UpdateTeklif(TeklifRequestDto request);
        public Task<List<TeklifDto>> SearchTeklif(TeklifRequestDto request);
        public Task<TeklifDto> UpdateTeklifDurum(TeklifRequestDto dto);
        public Task<bool> DeleteTeklif(int logref, string firmaId, string kullanici);
        public Task<List<TeklifDurumDetayDto>> GetTeklifDurumDetay(int teklifref, string firmaId);
        public Task<TeklifDto> TeklifKopyalaRevizeEt(TeklifRequestDto request);
    }
}
