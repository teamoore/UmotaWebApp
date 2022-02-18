using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UmotaWebApp.Shared.ModelDto;

namespace UmotaWebApp.Server.Services.Infrastructure
{
    public interface ICariKartService
    {
        public Task<List<CariKartDto>> GetCariKartDtos();
        public Task<CariKartDto> GetCariKartByKod(string kod);
        public Task<CariKartDto> SaveCariKart(CariKartDto cari);
        public Task<CariKartDto> UpdateCariKart(CariKartDto cari);
        public Task<List<CariKartDto>> SearchCariKarts(CariKartDto cari);

    }
}
