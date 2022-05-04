using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UmotaWebApp.Shared.ModelDto;

namespace UmotaWebApp.Server.Services.Infrastructure
{
    public interface IMalzemeKartService
    {
        public Task<List<MalzemeKartDto>> GetMalzemeKarts(string firmaId);
        public Task<MalzemeKartDto> GetMalzemeKart(int logref, string firmaId);
        public Task<List<MalzemeKartDto>> SearchMalzemeKarts(MalzemeKartRequestDto request);
        public Task<MalzemeFiyatDto> MalzemeFiyatGetir(MalzemeFiyatRequestDto request);
        public Task<MalzemeFiyatDto> MalzemeMaliyetGetir(MalzemeFiyatRequestDto request);
        public Task<List<MalzemeStokDto>> SearchMalzemeKartStoklu(MalzemeStokRequestDto request);
        public Task<MalzemeKartDto> SaveMalzemeKart(MalzemeKartRequestDto request);
        public Task<MalzemeKartDto> UpdateMalzemeKart(MalzemeKartRequestDto request);
        public Task<IEnumerable<MalzemeBirimSetDto>> GetMalzemeBirimSetList(int logofirmno);
        public Task<IEnumerable<SpeCodesDto>> GetMalzemeGrupList(int logofirmno);
        public Task<IEnumerable<SpeCodesDto>> GetMalzemeMarkaList(int logofirmno);
        public Task<SpeCodesDto> SaveMalzemeMarka(SpeCodesDto request);
    }
}
