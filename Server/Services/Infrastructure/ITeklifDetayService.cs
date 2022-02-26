using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UmotaWebApp.Shared.ModelDto;

namespace UmotaWebApp.Server.Services.Infrastructure
{
    public interface ITeklifDetayService
    {
        public Task<TeklifDetayDto> GetTeklifDetay(int logref, string firmaId);
        public Task<List<TeklifDetayDto>> GetTeklifDetays(int teklifRef, string firmaId);
        public Task<TeklifDetayDto> SaveTeklifDetay(TeklifDetayRequestDto request);
        public Task<TeklifDetayDto> UpdateTeklifDetay(TeklifDetayRequestDto request);
        public Task<bool> DeleteTeklifDetay(int logref, string firmaId);
    }
}
