using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UmotaWebApp.Shared.ModelDto;

namespace UmotaWebApp.Server.Services.Infrastructure
{
    public interface ISisMenuService
    {
        public Task<List<SisMenuDto>> GetSisMenuler();
    }
}
