using AutoMapper;
using AutoMapper.QueryableExtensions;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using UmotaWebApp.Server.Data.Models;
using UmotaWebApp.Server.Extensions;
using UmotaWebApp.Shared.CustomException;
using UmotaWebApp.Shared.ModelDto;

namespace UmotaWebApp.Server.Services.Infrastructure
{

    public class CariKartService : ICariKartService
    {
        public IMapper Mapper { get; }
        public IConfiguration Configuration { get; }

        public CariKartService(IConfiguration configuration,  IMapper mapper)
        {
            Configuration = configuration;
            Mapper = mapper;
        }
                
        public async Task<List<CariKartDto>> GetCariKarts(string firmaId)
        {
            if (string.IsNullOrEmpty(firmaId))
                throw new Exception("Firma Dönem seçimi yapınız");

            var connectionstring = Configuration.GetUmotaConnectionString(firmaId: firmaId);
            var optionsBuilder = new DbContextOptionsBuilder<UmotaCompanyDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);

            using (UmotaCompanyDbContext dbContext = new UmotaCompanyDbContext(optionsBuilder.Options))
            {
                var results = await dbContext.CariKarts.Where(x => x.Active == 0)
                                        .Take(100)
                                        .OrderBy(x => x.Logref)
                                        .ProjectTo<CariKartDto>(Mapper.ConfigurationProvider).ToListAsync();

                return results;
            }
        }
        public async Task<CariKartDto> SaveCariKart(CariKartRequestDto request)
        {
            var connectionstring = Configuration.GetUmotaConnectionString(firmaId: request.FirmaId.ToString());
            var optionsBuilder = new DbContextOptionsBuilder<UmotaCompanyDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);

            using (UmotaCompanyDbContext dbContext = new UmotaCompanyDbContext(optionsBuilder.Options))
            {
                //var cariRow = await dbContext.V001CariKarts.Where(x => x.Logref != request.CariKart.Logref && x.Kodu == request.CariKart.Kodu).SingleOrDefaultAsync();
                //if (cariRow != null)
                //    throw new ApiException("Cari Kodu daha önceden kullanılmış");

                if (!string.IsNullOrWhiteSpace(request.CariKart.Adi))
                {
                    var cariRow = await dbContext.V001CariKarts.Where(x => x.Logref != request.CariKart.Logref && x.Adi == request.CariKart.Adi).ToListAsync();
                    if (cariRow.Count > 0)
                        throw new ApiException("Cari Adı daha önceden kullanılmış");
                }
                if (!string.IsNullOrWhiteSpace(request.CariKart.Vdno))
                {
                    var cariRow = await dbContext.V001CariKarts.Where(x => x.Logref != request.CariKart.Logref && x.Vdno == request.CariKart.Vdno).ToListAsync();
                    if (cariRow.Count > 0)
                        throw new ApiException("Girilen Vergi/TC No daha önceden kullanılmış");
                }
                if (!string.IsNullOrWhiteSpace(request.CariKart.Tel1))
                {
                    var cariRow = await dbContext.V001CariKarts.Where(x => x.Logref != request.CariKart.Logref && x.Tel1 == request.CariKart.Tel1).ToListAsync();
                    if (cariRow.Count > 0)
                        throw new ApiException("Girilen Telefon No daha önceden kullanılmış");
                }

                var cariKart = Mapper.Map<CariKart>(request.CariKart);
                await dbContext.CariKarts.AddAsync(cariKart);
                await dbContext.SaveChangesAsync();
                return Mapper.Map<CariKartDto>(cariKart);
            }
        }
        public async Task<CariKartDto> UpdateCariKart(CariKartRequestDto request)
        {
            var connectionstring = Configuration.GetUmotaConnectionString(firmaId: request.FirmaId.ToString());
            var optionsBuilder = new DbContextOptionsBuilder<UmotaCompanyDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);

            using (UmotaCompanyDbContext dbContext = new UmotaCompanyDbContext(optionsBuilder.Options))
            {
                var cariKartRow = await dbContext.CariKarts.Where(x => x.Kodu == request.CariKart.Kodu).SingleOrDefaultAsync();
                if (cariKartRow == null)
                    throw new Exception("Cari kart bulunamadı");

                Mapper.Map(request.CariKart, cariKartRow);
                await dbContext.SaveChangesAsync();

                return Mapper.Map<CariKartDto>(cariKartRow);
            }
        }
        public async Task<List<CariKartDto>> SearchCariKarts(CariKartRequestDto request)
        {
            var connectionstring = Configuration.GetUmotaConnectionString(firmaId: request.FirmaId.ToString());
            var optionsBuilder = new DbContextOptionsBuilder<UmotaCompanyDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);

            using (UmotaCompanyDbContext dbContext = new UmotaCompanyDbContext(optionsBuilder.Options))
            {
                var word = request.CariKart.Adi.ToLower();
                var results = await dbContext.CariKarts.Where(x => (x.Active == 0) && 
                        (x.Adi.ToLower().Contains(word)
                        || x.Adi2.ToLower().Contains(word)
                        || x.Adres1.ToLower().Contains(word)
                        || x.Adres2.ToLower().Contains(word)
                        || x.Ilce.Contains(word)
                        || x.Web.Contains(word)
                        || x.Kodu.Contains(word)))
                    .ProjectTo<CariKartDto>(Mapper.ConfigurationProvider)
                    .OrderBy(x => x.Logref)
                    .ToListAsync();

                return results;
            }
        }

        public async Task<CariKartDto> GetCariKart(int logref, string firmaId)
        {
            if (string.IsNullOrEmpty(firmaId))
                throw new Exception("Firma Dönem seçimi yapınız");

            var connectionstring = Configuration.GetUmotaConnectionString(firmaId: firmaId);
            var optionsBuilder = new DbContextOptionsBuilder<UmotaCompanyDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);

            using (UmotaCompanyDbContext dbContext = new UmotaCompanyDbContext(optionsBuilder.Options))
            {
                IQueryable<CariKartDto> qry = dbContext.CariKarts.Where(i => i.Logref == logref)
                            .ProjectTo<CariKartDto>(Mapper.ConfigurationProvider);

                return await qry.SingleOrDefaultAsync();
            }
        }
        public async Task<SevkAdresDto> SaveCariKartAdres(SevkAdresRequestDto request)
        {
            var connectionstring = Configuration.GetUmotaConnectionString(firmaId: request.FirmaId.ToString());

            if (request.SevkAdres.Clientref > 0)
            {
                using (SqlConnection db = new SqlConnection(connectionstring))
                {
                    string LogoDbName = Configuration["LogoDbName"];
                    string LogoFirmaNo = request.LogoFirmaNo.Value.ToString("000");
                    string LogoTableName = string.Format("{0}.[dbo].[LG_{1}_SHIPINFO]", LogoDbName, LogoFirmaNo);

                    string sqlstring = string.Format("SELECT COUNT(*) SAY FROM " + LogoTableName + " with(nolock) where CLIENTREF= {0} and CODE= '{1}' ", request.SevkAdres.Clientref, request.SevkAdres.Sevkkodu);

                    int say = await db.QueryFirstAsync<int>(sqlstring, commandType: CommandType.Text);

                    if (say > 0)
                        throw new ApiException("Bu Carinin aynı Koda sahip başka bir sevk adresi daha var");

                    sqlstring = "INSERT INTO " + LogoTableName;
                    sqlstring += " ([CLIENTREF],[CODE],[NAME],[SPECODE],[CYPHCODE],[ADDR1],[ADDR2],[CITY],[COUNTRY],[POSTCODE],[TELNRS1],[TELNRS2],[FAXNR],[CAPIBLOCK_CREATEDBY],[CAPIBLOCK_CREADEDDATE],[CAPIBLOCK_CREATEDHOUR],[CAPIBLOCK_CREATEDMIN],[CAPIBLOCK_CREATEDSEC],[CAPIBLOCK_MODIFIEDBY],[CAPIBLOCK_MODIFIEDHOUR],[CAPIBLOCK_MODIFIEDMIN],[CAPIBLOCK_MODIFIEDSEC],[SITEID],[RECSTATUS],[ORGLOGICREF],[TRADINGGRP],[VATNR],[TAXNR],[TAXOFFICE],[TOWNCODE],[TOWN],[DISTRICTCODE],[DISTRICT],[CITYCODE],[COUNTRYCODE],[ACTIVE],[TEXTINC],[EMAILADDR],[INCHANGE],[TELCODES1],[TELCODES2],[FAXCODE],[LONGITUDE],[LATITUTE],[CITYID],[TOWNID],[SHIPBEGTIME1],[SHIPBEGTIME2],[SHIPBEGTIME3],[SHIPENDTIME1],[SHIPENDTIME2],[SHIPENDTIME3],[POSTLABELCODE],[SENDERLABELCODE],[TITLE],[DEFAULTFLG],[TCKNO],[SNAME],[SSURNAME],[POSTCODELEDESP],[SENDERCODELEDESP],[ISPERSCOMP],[GUID]) ";
                    sqlstring += " VALUES ";
                    sqlstring += " (@CLIENTREF,@CODE,@NAME,'','',@ADDR1,@ADDR2,@CITY,'TÜRKİYE',@POSTCODE,@TELNRS1,@TELNRS2,'',88,GetDate(),DATEPART(HOUR,GetDate()),DATEPART(MINUTE,GetDate()),DATEPART(SECOND,GetDate()),0,0,0,0,0,0,0,'','','','','',@TOWN,'','','','TR',0,0,@EMAILADDR,@INCHANGE,'','','','','','','',0,0,0,0,0,0,'','',@NAME,0,'','','','','',0,@GUID) ";

                    var p = new DynamicParameters();
                    p.Add("@CLIENTREF", request.SevkAdres.Clientref);
                    p.Add("@CODE", request.SevkAdres.Sevkkodu);
                    p.Add("@NAME", request.SevkAdres.SevkEdilecekBayiAdi);
                    p.Add("@ADDR1", request.SevkAdres.Sevkadres1);
                    p.Add("@ADDR2", request.SevkAdres.Sevkadres2);
                    p.Add("@CITY", request.SevkAdres.Il);
                    p.Add("@POSTCODE", request.SevkAdres.Postakodu);
                    p.Add("@TELNRS1", request.SevkAdres.Tel1);
                    p.Add("@TELNRS2", request.SevkAdres.Tel2);
                    p.Add("@TOWN", request.SevkAdres.Ilce);
                    p.Add("@EMAILADDR", request.SevkAdres.Mail);
                    p.Add("@INCHANGE", request.SevkAdres.SevkIlgilisi);
                    p.Add("@GUID", Guid.NewGuid().ToString());

                    await db.QueryAsync<double>(sqlstring, p, commandType: CommandType.Text);


                    sqlstring = string.Format("SELECT MAX(LOGICALREF) FROM " + LogoTableName + " with(nolock) where CLIENTREF= {0} and CODE= '{1}' ", request.SevkAdres.Clientref, request.SevkAdres.Sevkkodu);
                    int logref = await db.QueryFirstAsync<int>(sqlstring, commandType: CommandType.Text);
                    request.SevkAdres.Logref = logref; 
                }

                return request.SevkAdres;
            }
            else
            {
                var optionsBuilder = new DbContextOptionsBuilder<UmotaCompanyDbContext>();
                optionsBuilder.UseSqlServer(connectionstring);

                using (UmotaCompanyDbContext dbContext = new UmotaCompanyDbContext(optionsBuilder.Options))
                {
                    if (!string.IsNullOrWhiteSpace(request.SevkAdres.Sevkkodu))
                    {
                        var cariRow = await dbContext.V004Sevkadres.Where(x => x.Clientref == request.SevkAdres.Clientref && x.Sevkkodu == request.SevkAdres.Sevkkodu).ToListAsync();
                        if (cariRow.Count > 0)
                            throw new ApiException("Bu Carinin aynı Koda sahip başka bir sevk adresi daha var");
                    }

                    var adresKart = Mapper.Map<SevkAdres>(request.SevkAdres);
                    await dbContext.SevkAdreses.AddAsync(adresKart);
                    await dbContext.SaveChangesAsync();
                    return Mapper.Map<SevkAdresDto>(adresKart);
                }
            }
        }
    }
}
