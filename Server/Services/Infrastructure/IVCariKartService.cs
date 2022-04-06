using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UmotaWebApp.Shared.ModelDto;

namespace UmotaWebApp.Server.Services.Infrastructure
{
    public interface IVCariKartService
    {
        public Task<List<VCariKartDto>> GetVCariKarts(string firmaId);
        public Task<VCariKartDto> GetVCariKart(int logref, string firmaId);
        public Task<List<VCariKartDto>> SearchVCariKarts(VCariKartsRequestDto request);
    }
}
