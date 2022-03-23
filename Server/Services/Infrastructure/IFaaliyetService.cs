using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UmotaWebApp.Shared.ModelDto;

namespace UmotaWebApp.Server.Services.Infrastructure
{
    public interface IFaaliyetService
    {
        public Task<List<FaaliyetDto>> GetFaaliyets(string firmaId, string kullanicikodu);
        public Task<FaaliyetDto> GetFaaliyetByRef(int logref, string firmaId);
        public Task<List<FaaliyetDto>> SearchFaaliyet(FaaliyetRequestDto request);
        public Task<FaaliyetDto> SaveFaaliyet(FaaliyetRequestDto request);
        public Task<FaaliyetDto> UpdateFaaliyet(FaaliyetRequestDto request);
        public Task<int> GetCariFaaliyetSayisi(FaaliyetRequestDto request);
    }
}
