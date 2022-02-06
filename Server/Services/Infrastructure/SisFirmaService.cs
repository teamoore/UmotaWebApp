using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using UmotaWebApp.Server.Data.Models;
using UmotaWebApp.Shared.ModelDto;

namespace UmotaWebApp.Server.Services.Infrastructure
{
    public class SisFirmaService : ISisFirmaService
    {
        public IMapper Mapper { get; }
        public UmotaMasterDbContext UmotaMasterDbContext { get; }
        public IConfiguration Configuration { get; }

        public SisFirmaService(IMapper mapper, UmotaMasterDbContext umotaMasterDbContext, IConfiguration  configuration)
        {
            Mapper = mapper;
            UmotaMasterDbContext = umotaMasterDbContext;
            Configuration = configuration;
        }
        
        public async Task<List<SisFirmaFirmaDonemDto>> GetFirmaDonems()
        {
            var result = from firma in UmotaMasterDbContext.SisFirmas
                         join firma_donem in UmotaMasterDbContext.SisFirmaDonems on firma.FirmaNo equals firma_donem.FirmaNo.ToString() into donemler
                         from firma_donem in donemler

                          select new 
                          {
                              firma, firma_donem
                          };

            var list = new List<SisFirmaFirmaDonemDto>();

            foreach (var item in result.ToList())
            {
                list.Add(new SisFirmaFirmaDonemDto()
                {
                    FirmaAdi = item.firma.FirmaAdi,
                    FirmaNo = item.firma.FirmaNo,
                    Yil = item.firma_donem.Yil,
                    Aciklama = item.firma_donem.Aciklama
                });
            }

            return await Task.FromResult(list);

        }
    }
}
