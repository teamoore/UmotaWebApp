using FluentValidation;
using Prizma.Core;
using Prizma.Core.Model;
using Prizma.Core.Repositories;
using Prizma.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UmotaWebApp.Shared.ModelDto;

namespace Prizma.Services
{
    public class TalepDetayService : ITalepDetayService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TalepDetayService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TalepDetay> CreateTalepDetay(TalepDetayDTO td)
        {
            var yeniTalep = TalepDetay.Create(td.Aciklama, td.Miktar, td.BirimRef);

            var validator = new TalepDetayValidator();
            validator.ValidateAndThrow(yeniTalep);

            await _unitOfWork.TalepDetayRepository.AddAsync(yeniTalep);
            await _unitOfWork.CommitAsync();

            return yeniTalep;
        }

        public async Task<IEnumerable<TalepDetay>> GetTalepDetayList()
        {
            return await _unitOfWork.TalepDetayRepository.GetTalepDetayListAsync();
        }
    }
}
