using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UmotaWebApp.Shared.ModelDto;

namespace UmotaWebApp.Server.Services.Infrastructure
{
    public interface ITeklifDetayService
    {
        public Task<TeklifDetayDto> GetTeklifDetay(int logref);
        public Task<List<TeklifDetayDto>> GetTeklifDetays(int teklifRef);
        public Task<TeklifDetayDto> SaveTeklifDetay(TeklifDetayDto teklif);
        public Task<TeklifDetayDto> UpdateTeklifDetay(TeklifDetayDto teklif);
    }
}
