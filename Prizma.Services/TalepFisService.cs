using FluentValidation;
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
    public class TalepFisService : ITalepFisService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TalepFisService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TalepFis> CreateTalepFis(TalepFisDto tf)
        {
            var yeniTalep = TalepFis.Create(tf.logref, tf.TurRef, tf.ProjeRef, tf.TalepEden);
            yeniTalep.ChangeTeslimatBilgileri(tf.TeslimYeriRef, tf.TeslimTarihi);
            yeniTalep.ChangeAciklama(tf.Aciklama);

            var talepValidator = new TalepFisValidator();
            talepValidator.ValidateAndThrow(yeniTalep);

            await _unitOfWork.TalepFisRepository.CreateTalepFisAsync(yeniTalep);
            await _unitOfWork.CommitAsync();

            return yeniTalep;
        }

        public async Task<List<TalepFisDto>> GetTalepFisListAsync(TalepFisRequestDto request)
        {
            return await _unitOfWork.TalepFisRepository.GetTalepFisListAsync(request.kullanicikodu);
        }
    }
}
