using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UmotaWebApp.Shared.ModelDto;

namespace UmotaWebApp.Server.Services.Infrastructure
{
    public interface ICariKartService
    {
        public Task<List<CariKartDto>> GetCariKartDtos(string firmaId);
        public Task<CariKartDto> GetCariKartByKod(string kod, string firmaId);
        public Task<CariKartDto> GetCariKart(int logref, string firmaId);
        public Task<CariKartDto> SaveCariKart(CariKartRequestDto request);
        public Task<CariKartDto> UpdateCariKart(CariKartRequestDto request);
        public Task<List<CariKartDto>> SearchCariKarts(CariKartRequestDto request);
        public Task<List<KisilerDto>> GetCariKartKisiler(int cariref, string firmaId);
        public Task<KisilerDto> SaveCariKartKisi(KisilerRequestDto request);
    }
}
