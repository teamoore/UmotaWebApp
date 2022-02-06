using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UmotaWebApp.Shared.ModelDto;

namespace UmotaWebApp.Server.Services.Infrastructure
{
   public interface ISisFirmaService
    {
        public Task<List<SisFirmaFirmaDonemDto>> GetFirmaDonems();
    }
}
