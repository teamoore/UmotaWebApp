using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UmotaWebApp.Shared.ModelDto;

namespace UmotaWebApp.Server.Services.Infrastructure
{
    public interface IMalzemeKartService
    {
        public Task<MalzemeKartDto> GetMalzemeKart(int logref, string firmaId);
        public Task<List<MalzemeKartDto>> SearchMalzemeKart(MalzemeKartRequestDto request);
    }
}
