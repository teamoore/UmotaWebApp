using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UmotaWebApp.Shared.ModelDto;

namespace UmotaWebApp.Server.Services.Infrastructure
{
    public interface ICariRaporService
    {
        public Task<List<CariDurumRaporuDto>> CariDurumRaporu(CariDurumRaporuRequestDto request);
        public Task<List<CariHesapEkstresiDto>> CariHesapEkstresi(CariHesapEkstresiRequestDto request);
    }
}
