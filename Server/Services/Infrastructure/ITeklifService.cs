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
        public Task<TeklifDto> GetTeklifByRef(int logref, string firmaId);
        public Task<TeklifDto> SaveTeklif(TeklifRequestDto request);
        public Task<TeklifDto> UpdateTeklif(TeklifRequestDto request);
        public Task<List<TeklifDto>> SearchTeklif(TeklifRequestDto request);
    }
}
