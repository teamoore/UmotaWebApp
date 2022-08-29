using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UmotaWebApp.Shared.ModelDto;

namespace UmotaWebApp.Server.Services.Infrastructure
{
    public interface ISisFirmaDonemService
    {
        public Task<List<SisFirmaDonemDto>> GetSisFirmaDonem(string kullanici);
        public Task<SisFirmaDonemDto> GetSisFirmaDonemOnDeger();
    }
}
