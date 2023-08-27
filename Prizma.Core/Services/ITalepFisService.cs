using Prizma.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UmotaWebApp.Shared;
using UmotaWebApp.Shared.ModelDto;

namespace Prizma.Core.Services
{
    public interface ITalepFisService
    {
        Task<TalepFis> CreateTalepFis(TalepFisDto talepFisDto);

        Task<List<TalepFisDto>> GetTalepFisListAsync(TalepFisRequestDto request);

        Task<List<V030_TalepFis>> GetV030_TalepFisListAsync(TalepFisRequestDto request);

        Task<TalepFis> UpdateTalepFis(TalepFisDto talepFisDto);
    }
}
