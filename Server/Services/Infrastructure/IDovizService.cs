using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UmotaWebApp.Shared.ModelDto;

namespace UmotaWebApp.Server.Services.Infrastructure
{
    public interface IDovizService
    {
        public Task<IEnumerable<DovizDto>> GetDovizList(int logofirmano);

        public Task<double> LogoDovKurAl(DovizKuruRequestDto request);
    }
}
