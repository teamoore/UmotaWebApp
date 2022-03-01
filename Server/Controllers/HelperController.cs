using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UmotaWebApp.Server.Services.Infrastructure;
using UmotaWebApp.Shared.ModelDto;
using UmotaWebApp.Shared.ServiceResponses;

namespace UmotaWebApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HelperController : ControllerBase
    {
        private readonly IRefGenerator RefService;
        private readonly ILogger<HelperController> Logger;
        private readonly IPersonelService PersonelService;
        

        public HelperController(IRefGenerator refGenerator, ILogger<HelperController> logger, IPersonelService personelService)
        {
            RefService = refGenerator;
            Logger = logger;
            PersonelService = personelService;
        }

        [HttpGet("GenerateRef")]
        public async Task<ServiceResponse<string>> GetRowRefNumber(string table, string keyField, string firmaId)
        {
            try
            {
                if (string.IsNullOrEmpty(table))
                    throw new ApiExcetion("tablo adı boş geldi.Ref üretilemedi !");

                return new ServiceResponse<string>()
                {
                    Value = await RefService.GenerateRowRef(table, keyField, firmaId)
                };
            }
            catch (ApiExcetion ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<string>();
                e.SetException(ex);
                return e;
            }
        }

        [HttpGet("GetTeslimSekliList")]
        public Task<ServiceResponse<List<string>>> GetTeslimSekliList()
        {
            try
            {
                var list = new List<string>();
                list.Add("ŞİRKETİMİZ DEPO TESLİM");
                list.Add("MÜŞTERİ ADRESİNE TESLİM");
                list.Add("KARGO ALICI ÖDEMELİ");
                list.Add("İHRACAT");

                var result = new ServiceResponse<List<string>>()
                {
                    Value = list
                };

                return Task.FromResult(result);
            }
            catch (Exception ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<List<string>>();
                e.SetException(ex);
                return Task.FromResult(e);
            }
        }


        [HttpGet("GetPersonelList")]
        public async Task<ServiceResponse<IEnumerable<PersonelDto>>> GetPersonelList(int logofirmno)
        {
            try
            {
                return new ServiceResponse<IEnumerable<PersonelDto>>()
                {
                    Value = await PersonelService.GetPersonelList(logofirmno)
                };
            }
            catch (Exception ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<IEnumerable<PersonelDto>>();
                e.SetException(ex);
                return e;
            }
        }

        [HttpGet("GetOdemePlaniList")]
        public async Task<ServiceResponse<IEnumerable<OdemePlaniDto>>> GetOdemePlaniList(int logofirmno)
        {
            try
            {
                return new ServiceResponse<IEnumerable<OdemePlaniDto>>()
                {
                    Value = await RefService.GetOdemePlaniList(logofirmno)
                };
            }
            catch (Exception ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<IEnumerable<OdemePlaniDto>>();
                e.SetException(ex);
                return e;
            }
        }

        [HttpGet("GetDovizList")]
        public async Task<ServiceResponse<IEnumerable<DovizDto>>> GetDovizList(int logofirmno)
        {
            try
            {
                return new ServiceResponse<IEnumerable<DovizDto>>()
                {
                    Value = await RefService.GetDovizList(logofirmno)
                };
            }
            catch (Exception ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<IEnumerable<DovizDto>>();
                e.SetException(ex);
                return e;
            }
        }

        [HttpGet("GetSabitDetayList")]
        public async Task<ServiceResponse<IEnumerable<SisSabitlerDetayDto>>> GetSabitDetayList(int tip)
        {
            try
            {
                return new ServiceResponse<IEnumerable<SisSabitlerDetayDto>>()
                {
                    Value = await RefService.GetSabitDetayList(tip)
                };
            }
            catch (Exception ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<IEnumerable<SisSabitlerDetayDto>>();
                e.SetException(ex);
                return e;
            }
        }

        [HttpGet("RefNoAl")]
        public async Task<ServiceResponse<int>> RefNoAl(string tablename, string firmaId)
        {
            try
            {
                if (string.IsNullOrEmpty(tablename))
                    throw new ApiExcetion("tablo adı boş geldi.Ref üretilemedi !");

                return new ServiceResponse<int>()
                {
                    Value = await RefService.RefNoAl(tablename, firmaId)
                };
            }
            catch (ApiExcetion ex)
            {
                Logger.Log(LogLevel.Error, ex.Message);

                var e = new ServiceResponse<int>();
                e.SetException(ex);
                return e;
            }
        }

    }
}
