using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UmotaWebApp.Shared.ModelDto;

namespace UmotaWebApp.Server.Services.Infrastructure
{
    public interface IRefGenerator
    {
        public Task<string> GenerateRowRef(string table, string keyField);
        public Task<int> RefNoAl(string tablename);
        public Task<IEnumerable<OdemePlaniDto>> GetOdemePlaniList(int logofirmno);
        public Task<IEnumerable<SisSabitlerDetayDto>> GetSabitDetayList(int tip);
        public Task<IEnumerable<DovizDto>> GetDovizList(int logofirmno);
    }
}
