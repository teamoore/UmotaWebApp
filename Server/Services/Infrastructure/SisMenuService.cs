using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using UmotaWebApp.Server.Data.Models;
using UmotaWebApp.Shared.CustomException;
using UmotaWebApp.Shared.ModelDto;

namespace UmotaWebApp.Server.Services.Infrastructure
{
    public class SisMenuService : ISisMenuService
    {
        public IMapper Mapper { get; }
        public UmotaMasterDbContext db { get; }
        public IConfiguration Configuration { get; }

        public SisMenuService(IMapper mapper, UmotaMasterDbContext umotaMasterDbContext, IConfiguration configuration)
        {
            Mapper = mapper;
            db = umotaMasterDbContext;
            Configuration = configuration;
        }

        public async Task<List<SisMenuDto>> GetSisMenuler()
        {
            var menuler = await db.SisMenulers.OrderBy(i => i.MenuId)
                .ProjectTo<SisMenuDto>(Mapper.ConfigurationProvider).ToListAsync();

            if (menuler == null)
                throw new ApiException("Menüleri çekerken hata oluştu");

            return menuler;
        }
    }
}
