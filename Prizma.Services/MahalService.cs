using Prizma.Core;
using Prizma.Core.Model;
using Prizma.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UmotaWebApp.Shared;

namespace Prizma.Services
{
    public class MahalService : IMahalService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MahalService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<V005Mahal>> GetMahals(int turref, int projeref)
        {
            return await _unitOfWork.MahalRepository.GetMahals(turref, projeref);
        }

        public async Task<IEnumerable<Mahal>> GetMahalsList()
        {
            return await _unitOfWork.MahalRepository.GetAllAsync();
        }
    }
}
