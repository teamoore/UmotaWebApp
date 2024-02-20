using Prizma.Core.Model;
using UmotaWebApp.Shared;
using UmotaWebApp.Shared.ModelDto;

namespace Prizma.Core.Services
{
    public interface ISiparisService
    {
        Task<List<V040_Siparis>> LoadRecordsFromView(SiparisRequestDto request);
        Task<SiparisDto> LoadRecordFromView(SiparisRequestDto request);
        Task<SiparisDto> SaveRecord(SiparisDto entity);
        Task<Siparis> UpdateRecord(SiparisDto entity);
    }
}
