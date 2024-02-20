using Prizma.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prizma.Core.Services
{
    public interface IProjeService
    {
        Task<List<Proje>> GetAvailableProjeList();
    }
}
