using Prizma.Core;
using Prizma.Core.Model;
using Prizma.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UmotaWebApp.Shared.ModelDto;

namespace Prizma.Services
{
    public class TalepDosyaService : ITalepDosyaService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TalepDosyaService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TalepDosya> CreateTalepDosya(TalepDosyaDto talepDosya)
        {
            var talepdosyasi = TalepDosya.Create(talepDosya.DosyaAdi, talepDosya.DosyaTipi, talepDosya.TalepLogRef, talepDosya.InsUser);

            await _unitOfWork.TalepDosyaRepository.CreateTalepDosya(talepdosyasi);
            await _unitOfWork.CommitAsync();

            return talepdosyasi;
        }
    }
}
