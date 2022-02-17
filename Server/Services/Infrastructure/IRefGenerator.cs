using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UmotaWebApp.Server.Services.Infrastructure
{
    public interface IRefGenerator
    {
        public Task<string> GenerateRowRef(string table, string keyField);
    }
}
