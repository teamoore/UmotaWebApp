using Prizma.Core;
using Prizma.Core.Model;
using Prizma.Core.Repositories;
using Prizma.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prizma.Services
{
    public class TalepDetayService : ITalepDetayService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TalepDetayService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<TalepDetay> CreateTalepDetay(TalepDetay talepDetay)
        {
            await _unitOfWork.TalepDetays.AddAsync(talepDetay);
            await _unitOfWork.CommitAsync();

            return talepDetay;
        }

        public async Task<IEnumerable<TalepDetay>> GetTalepDetayList()
        {
            return await _unitOfWork.TalepDetays.GetAllAsync();
        }
    }
}
