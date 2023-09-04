using FluentValidation;
using Prizma.Core;
using Prizma.Core.Model;
using Prizma.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UmotaWebApp.Shared;
using UmotaWebApp.Shared.ModelDto;
using AutoMapper;
using static Dapper.SqlMapper;


namespace Prizma.Services
{
    public class SiparisService : ISiparisService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper Mapper;

        public SiparisService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            Mapper = mapper;
        }

        public async Task<List<V040_Siparis>> LoadRecordsFromView(SiparisRequestDto request)
        {
           return await _unitOfWork.SiparisRepository.LoadRecordsFromView(request);
        }

        public async Task<SiparisDto> LoadRecordFromView(SiparisRequestDto request)
        {
            var response = await _unitOfWork.SiparisRepository.LoadRecordsFromView(request);
            var sipview = response.FirstOrDefault();

            var sipdto = new SiparisDto();
            Mapper.Map(sipview, sipdto);

            return sipdto;
        }
            public async Task<SiparisDto> SaveRecord(SiparisDto entity)
        {
            var Siparis = Mapper.Map<SiparisDto, Siparis>(entity);
            await _unitOfWork.SiparisRepository.SaveRecord(Siparis);

            return entity;
        }

        public async Task<Siparis> UpdateRecord(SiparisDto entity)
        {
            var row = await _unitOfWork.SiparisRepository.SingleOrDefaultAsync(x => x.logref == entity.logref);

            if (row == null)
                throw new System.NullReferenceException("Kayıt bulunamadı");

            Mapper.Map(entity, row);

            await _unitOfWork.CommitAsync();
            return row;

        }
    }
}
