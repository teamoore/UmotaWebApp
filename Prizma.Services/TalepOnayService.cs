using Prizma.Core;
using Prizma.Core.Model;
using Prizma.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UmotaWebApp.Shared;
using UmotaWebApp.Shared.ModelDto;
using UmotaWebApp.Shared.ModelDto.Request;

namespace Prizma.Services
{
    public class TalepOnayService : ITalepOnayService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TalepOnayService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<V032_TalepOnay>> GetTalepFisOnayListAsnyc(TalepOnayRequestDto request)
        {
            return await _unitOfWork.TalepOnayRepository.GetTalepFisOnayListAsnyc(request);
        }

        public async Task<int> TalepDurumGuncelle(TalepOnayRequestDto request)
        {
            return await _unitOfWork.TalepOnayRepository.TalepDurumGuncelle(request);
        }

        public async Task<int> TalepOnayRota(TalepOnayRequestDto request)
        {
           return await _unitOfWork.TalepOnayRepository.TalepOnayRota(request);
        }

        public async Task<bool> UploadTalepDosya(TalepDosyaRequestDto request)
        {
            var td = TalepDosya.Create(request.FileName, request.FileType, request.TalepLogRef, request.InsUser);
            await _unitOfWork.TalepDosyaRepository.CreateTalepDosya(td);
            await _unitOfWork.CommitAsync();

            return true;
        }
        public async Task<int> TalepGetOnayLineRef(TalepOnayRequestDto request)
        {
            return await _unitOfWork.TalepOnayRepository.TalepGetOnayLineRef(request);
        }
        public async Task<int> TalepOnayla(TalepOnayRequestDto request)
        {
            return await _unitOfWork.TalepOnayRepository.TalepOnayla(request);
        }
    }
}
