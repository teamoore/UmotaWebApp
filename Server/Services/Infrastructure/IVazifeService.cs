using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UmotaWebApp.Shared.ModelDto;
using UmotaWebApp.Shared.ModelDto.Request;

namespace UmotaWebApp.Server.Services.Infrastructure
{
    public interface IVazifeService
    {
        public Task<List<VazifeDto>> GetVazifes(VazifeRequestDto request);

        public Task<VazifeDto> SaveVazife(VazifeRequestDto request);

        public Task<VazifeDto> GetVazife(short firmaId, int logref);

        public Task<VazifeDto> UpdateVazife(VazifeRequestDto request);
    }
}
