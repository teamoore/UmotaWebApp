using UmotaWebApp.Shared;
using UmotaWebApp.Shared.ModelDto;

namespace Prizma.Core.Services
{
    public interface ISiparisService
    {
        Task<List<V040_Siparis>> GetV040_SiparisList(SiparisViewRequestDto request);
    }
}
