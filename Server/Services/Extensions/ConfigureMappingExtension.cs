using System;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using UmotaWebApp.Server.Data.Models;
using UmotaWebApp.Shared.ModelDto;

namespace UmotaWebApp.Server.Services.Extensions
{

    public static class ConfigureMappingExtension
    {
        public static IServiceCollection ConfigureMapping(this IServiceCollection service)
        {
            var mappingConfig = new MapperConfiguration(mc => { mc.AddProfile(new MappingProfile()); });

            IMapper mapper = mappingConfig.CreateMapper();

            service.AddSingleton(mapper);

            return service;
        }
    }

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            AllowNullDestinationValues = true;
            AllowNullCollections = true;

            CreateMap<SisKullanici, SisKullaniciDto>().ReverseMap();
            CreateMap<SisMenuler, SisMenuDto>().ReverseMap();
            CreateMap<SisFirmaDonemYetki, SisFirmaDonemYetkiDto>().ReverseMap();
            CreateMap<CariKart, CariKartDto>().ReverseMap();
            CreateMap<Teklif, TeklifDto>().ReverseMap();
        }
    }

}
