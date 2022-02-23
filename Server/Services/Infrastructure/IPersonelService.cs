using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UmotaWebApp.Shared.ModelDto;

namespace UmotaWebApp.Server.Services.Infrastructure
{
    public interface IPersonelService
    {
        public Task<IEnumerable<PersonelDto>> GetPersonelList();
    }
}
