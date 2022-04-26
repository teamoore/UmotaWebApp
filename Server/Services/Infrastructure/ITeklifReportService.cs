using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UmotaWebApp.Server.Services.Infrastructure
{
    public interface ITeklifReportService
    {
        public Task<int> KacAdetMusteriOnayiBekliyorTeklifVar(string firmaId,string kullanici);
    }
}
