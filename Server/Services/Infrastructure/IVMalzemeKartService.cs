using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UmotaWebApp.Shared.ModelDto;

namespace UmotaWebApp.Server.Services.Infrastructure
{
    public interface IVMalzemeKartService
    {
        public Task<VMalzemeKartDto> GetVMalzemeKart(int logref, string firmaId);
        public Task<List<VMalzemeKartDto>> SearchVMalzemeKarts(VMalzemeKartsRequestDto request);
    }
}
