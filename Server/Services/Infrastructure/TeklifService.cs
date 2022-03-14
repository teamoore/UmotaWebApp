using AutoMapper;
using AutoMapper.QueryableExtensions;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using UmotaWebApp.Server.Data.Models;
using UmotaWebApp.Server.Extensions;
using UmotaWebApp.Shared.CustomException;
using UmotaWebApp.Shared.ModelDto;

namespace UmotaWebApp.Server.Services.Infrastructure
{
    public class TeklifService : ITeklifService
    {
        public IMapper Mapper { get; }
        public IConfiguration Configuration { get; }
        private readonly DbConnection _sql;

        public TeklifService(IMapper mapper, IConfiguration configuration, DbConnection sql)
        {
            Mapper = mapper;
            Configuration = configuration;
            _sql = sql;
        }

        public async Task<TeklifDto> GetTeklifByRef(int logref, string firma_id)
        {
            using (SqlConnection db = new SqlConnection(Configuration.GetUmotaConnectionString(firma_id)))
            {
                db.Open();

                var sql = "select top 1 *, lodeme_plani LodemePlani, ilgili_adi IlgiliAdi, teslim_sekli TeslimSekli, teslim_tarihi TeslimTarihi, sevk_edilecek_bayi_adi SevkEdilecekBayiAdi, sevk_ilgilisi SevkIlgilisi" +
                    " from " + Configuration.GetUmotaObjectName("v009_teklif", firmaId: firma_id) + " where logref=" + logref;

                var result = await db.QueryAsync<TeklifDto>(sql, commandType: CommandType.Text);

                db.Close();

                return result.SingleOrDefault();
            }
        }

        public async Task<List<TeklifDto>> GetTeklifDtos(string firmaId)
        {
            using (SqlConnection db = new SqlConnection(Configuration.GetUmotaConnectionString(firmaId)))
            {
                db.Open();

                var sql = "select top 100 *, lodeme_plani LodemePlani, ilgili_adi IlgiliAdi, teslim_sekli TeslimSekli, teslim_tarihi TeslimTarihi, sevk_edilecek_bayi_adi SevkEdilecekBayiAdi, sevk_ilgilisi SevkIlgilisi" +
                    " from " + Configuration.GetUmotaObjectName("v009_teklif", firmaId:firmaId) + " where 1=1";

                sql += " order by insdate desc";
                var result = await db.QueryAsync<TeklifDto>(sql, commandType: CommandType.Text);

                db.Close();

                return result.ToList();

            }

        }

        public async Task<TeklifDto> SaveTeklif(TeklifRequestDto request)
        {
            var connectionstring = Configuration.GetUmotaConnectionString(firmaId: request.FirmaId.ToString());
            var optionsBuilder = new DbContextOptionsBuilder<UmotaCompanyDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);

            using (UmotaCompanyDbContext dbContext = new UmotaCompanyDbContext(optionsBuilder.Options))
            {
                var teklif = Mapper.Map<Teklif>(request.Teklif);
                await dbContext.Teklifs.AddAsync(teklif);
                await dbContext.SaveChangesAsync();
                return Mapper.Map<TeklifDto>(teklif);
            }
        }

        public async Task<List<TeklifDto>> SearchTeklif(TeklifRequestDto request)
        {

            var connectionstring = Configuration.GetUmotaConnectionString(firmaId: request.FirmaId.ToString());
            var optionsBuilder = new DbContextOptionsBuilder<UmotaCompanyDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);

            using (UmotaCompanyDbContext dbContext = new UmotaCompanyDbContext(optionsBuilder.Options))
            {
                var word = request.Teklif.Aciklama1.ToLower();

                return await dbContext.V009Teklifs.Where(x => x.Aciklama1.ToLower().Contains(word)
                || x.Aciklama2.ToLower().Contains(word)
                || x.Aciklama3.ToLower().Contains(word)
                || x.Aciklama3.ToLower().Contains(word)
                || x.Aciklama4.ToLower().Contains(word)
                || x.Teklifno.ToLower().Contains(word)
                || x.Tbelgeno.ToLower().Contains(word)
                || x.Lpersoneladi.ToLower().Contains(word)
                || x.LcariAdi.ToLower().Contains(word)
                || x.LcariKodu.ToLower().Contains(word)
                || x.Proje.ToLower().Contains(word)
                || x.IlgiliAdi.ToLower().Contains(word))
                    .OrderByDescending(x => x.Tarih)
                    .ProjectTo<TeklifDto>(Mapper.ConfigurationProvider).ToListAsync();
            }


        }

        public async Task<TeklifDto> UpdateTeklif(TeklifRequestDto request)
        {

            var connectionstring = Configuration.GetUmotaConnectionString(firmaId: request.FirmaId.ToString());
            var optionsBuilder = new DbContextOptionsBuilder<UmotaCompanyDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);

            using (UmotaCompanyDbContext dbContext = new UmotaCompanyDbContext(optionsBuilder.Options))
            {
                var teklifRow = await dbContext.Teklifs.Where(x => x.Logref == request.Teklif.Logref).SingleOrDefaultAsync();
                if (teklifRow == null)
                    throw new ApiException("Teklif Detayı bulunamadı");

                // Güncellenen teklifi loga at
                var teklifLog = new TeklifLog();
                Mapper.Map(teklifRow, teklifLog);
                await dbContext.TeklifLogs.AddAsync(teklifLog);

                Mapper.Map(request.Teklif, teklifRow);
                await dbContext.SaveChangesAsync();

                return Mapper.Map<TeklifDto>(teklifRow);
            }


        }
    }
}
