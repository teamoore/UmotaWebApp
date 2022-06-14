using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UmotaWebApp.Shared.ModelDto;
using UmotaWebApp.Shared.ModelDto.Request;

namespace UmotaWebApp.Server.Services.Infrastructure
{
    public interface IServisService
    {
        public Task<ServisDto> GetServisByRef(int logref, string firmaId);
        public Task<List<ServisDto>> SearchServis(ServisRequestDto request);
        public Task<ServisDto> SaveServis(ServisRequestDto request);
        public Task<ServisDto> UpdateServis(ServisRequestDto request);
        public Task<bool> DeleteServis(int logref, string firmaId, string kullanici);
    }
}
