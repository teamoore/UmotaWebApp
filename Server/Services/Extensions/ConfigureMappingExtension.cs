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

            /*
                CreateMap<Sites, SitesDto>()
                    .ForMember(x => x.Description, y => y.MapFrom(z => z.Name + " " + z.Address));

                CreateMap<SitesDto, Sites>();

                CreateMap<Blocks, BlocksDto>()
                    .ForMember(x => x.BlockName, y => y.MapFrom(z => z.Name + " " + z.Code));

                CreateMap<BlocksDto, Blocks>()
                    .ForMember(x => x.Name, y => y.MapFrom(z => z.BlockName));

                CreateMap<Apartments, ApartmentDto>()
                    .ReverseMap();

                CreateMap<ApartmentDto, Apartments>();
            */

        }
        }
    
}
