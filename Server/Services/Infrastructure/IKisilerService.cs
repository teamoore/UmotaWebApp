using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UmotaWebApp.Shared.ModelDto;

namespace UmotaWebApp.Server.Services.Infrastructure
{
    public interface IKisilerService
    {
        public Task<List<KisilerDto>> GetCariKartKisiler(int cariref, string firmaId);
        public Task<List<KisilerDto>> GetKisiler(string firmaId);
        public Task<KisilerDto> GetKisi(int logref, string firmaId); 
        public Task<List<KisilerDto>> SearchKisiler(KisilerRequestDto request);
        public Task<KisilerDto> SaveCariKartKisi(KisilerRequestDto request);
        public Task<KisilerDto> UpdateKisi(KisilerRequestDto request);
    }
}
