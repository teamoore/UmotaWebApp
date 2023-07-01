using AutoMapper;
using Prizma.Core.Model;
using UmotaWebApp.Shared.ModelDto;

namespace UmotaWebApp.Server.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<TalepDetay, TalepDetayDTO>();
            CreateMap<TalepDetayDTO, TalepDetay>();

        }
    }
}
