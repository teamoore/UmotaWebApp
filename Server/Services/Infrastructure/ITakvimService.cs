using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UmotaWebApp.Shared.ModelDto;

namespace UmotaWebApp.Server.Services.Infrastructure
{
    public interface ITakvimService
    {
        public Task<List<TakvimDto>> GetTakvimInformation(TakvimRequestDto request);

        public Task<TakvimDto> SaveTakvim(TakvimRequestDto request);

        public Task<TakvimDto> GetTakvim(short firmaId, int logref);

        public Task<TakvimDto> UpdateTakvim(TakvimRequestDto request);
    }
}
