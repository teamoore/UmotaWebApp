using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UmotaWebApp.Shared.ModelDto;

namespace UmotaWebApp.Server.Services.Infrastructure
{
    public interface ITeklifReportService
    {
        public Task<int> KacAdetMusteriOnayiBekliyorTeklifVar(string firmaId,string kullanici);
        public Task<List<CariDurumRaporuDto>> CariDurumRaporu(CariDurumRaporuRequestDto request);
    }
}
