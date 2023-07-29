using Prizma.Core;
using Prizma.Core.Model;
using Prizma.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prizma.Services
{
    public class ProjeService : IProjeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProjeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<List<Proje>> GetAvailableProjeList()
        {
            return await _unitOfWork.ProjeRepository.GetProjeListAsync();
        }
    }
}
