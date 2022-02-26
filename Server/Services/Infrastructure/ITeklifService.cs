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
        public Task<List<TeklifDto>> GetTeklifDtos(string firmaId);
        public Task<TeklifDto> GetTeklifByRef(int logref);
        public Task<TeklifDto> SaveTeklif(TeklifSaveRequestDto request);
        public Task<TeklifDto> UpdateTeklif(TeklifDto teklifDto);
        public Task<List<TeklifDto>> SearchTeklif(TeklifDto teklif);
    }
}
