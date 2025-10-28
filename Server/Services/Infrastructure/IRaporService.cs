using System.Collections.Generic;
using System.Threading.Tasks;
using UmotaWebApp.Shared.ModelDto;

namespace UmotaWebApp.Server.Services.Infrastructure
{
    public interface IRaporService
    {
        public Task<List<ProjeDetayRaporuDto>> ProjeDetayRaporu(ProjeDetayRaporuReq request);
    }
}
