using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UmotaWebApp.Client.ServiceHelpers
{
    public interface IDataHelper<T>
    {
        public Task<T> LoadRecord(int logref);
        public Task<List<T>> LoadRecords();
        public Task<T> SaveRecord(T request);
        public Task<T> UpdateRecord(T request);
        public Task<T> DeleteRecord(T request);
    }
}
