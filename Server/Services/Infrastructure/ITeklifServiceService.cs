using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UmotaWebApp.Shared.ModelDto;
using UmotaWebApp.Shared.ServiceResponses;

namespace UmotaWebApp.Server.Services.Infrastructure
{
    public interface ITeklifServiceService
    {
        public Task<List<TeklifDto>> GetTeklifDtos();
        public Task<TeklifDto> GetTeklifByRef(int logref);
        public Task<TeklifDto> SaveTeklif(TeklifDto teklifDto);
        public Task<List<TeklifDto>> SearchTeklif(TeklifDto teklif);
    }
}
