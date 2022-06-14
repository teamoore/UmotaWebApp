using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.Common;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UmotaWebApp.Server.Data.Models;
using UmotaWebApp.Server.Extensions;
using UmotaWebApp.Shared.ModelDto;
using UmotaWebApp.Shared.ModelDto.Request;

namespace UmotaWebApp.Server.Services.Infrastructure
{
    public class VazifeService : IVazifeService
    {
        public IMapper Mapper { get; }
        public IConfiguration Configuration { get; }

        public VazifeService(IMapper mapper, IConfiguration configuration)
        {
            Mapper = mapper;
            Configuration = configuration;
        }
        public async Task<VazifeDto> GetVazife(short firmaId, int logref)
        {
            var connectionstring = Configuration.GetUmotaConnectionString(firmaId: firmaId.ToString());
            var optionsBuilder = new DbContextOptionsBuilder<UmotaCompanyDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);

            using (UmotaCompanyDbContext dbContext = new UmotaCompanyDbContext(optionsBuilder.Options))
            {
                var results = await dbContext.Vazifes.Where(x => x.Logref == logref)
                    .ProjectTo<VazifeDto>(Mapper.ConfigurationProvider)
                    .SingleOrDefaultAsync();

                return results;
            }
        }

        public async Task<List<VazifeDto>> GetVazifes(VazifeRequestDto request)
        {
            //var connectionstring = Configuration.GetUmotaConnectionString(firmaId: request.FirmaId.ToString());
            //var optionsBuilder = new DbContextOptionsBuilder<UmotaCompanyDbContext>();
            //optionsBuilder.UseSqlServer(connectionstring);

            //using (UmotaCompanyDbContext dbContext = new UmotaCompanyDbContext(optionsBuilder.Options))
            //{
            //    List<VazifeDto> results = null;

            //    if (request.AdminView == false)
            //        results = await dbContext.Vazifes.Where(x => (x.Insuser == request.User || x.AtananKisi == request.User) && x.Status < 2)
            //                        .ProjectTo<VazifeDto>(Mapper.ConfigurationProvider).ToListAsync();
            //    else
            //        results = await dbContext.Vazifes.Where(x => x.Status < 2)
            //                    .ProjectTo<VazifeDto>(Mapper.ConfigurationProvider).ToListAsync();
            //    return results;
            //}

            using (SqlConnection db = new SqlConnection(Configuration.GetUmotaConnectionString(request.FirmaId.ToString())))
            {
                db.Open();
                var p = new DynamicParameters();

                string selectstr = "";
                if (request.TopRowCount > 0)
                    selectstr = "top " + request.TopRowCount;

                var sql = "select " + selectstr + " a.*, a.vazife_tipi VazifeTipi, a.atanan_kisi AtananKisi, a.cari_adi Cariadi, a.son_tarih SonTarih, a.baslangic_tarihi BaslangicTarihi, a.bitirme_tarihi BitirmeTarihi, b.tamadi KisiAdi" +
                    " from " + Configuration.GetUmotaObjectName("vazife", firmaId: request.FirmaId.ToString()) + " a with(nolock) " +
                    " left outer join  " + Configuration.GetUmotaObjectName("kisiler", firmaId: request.FirmaId.ToString()) + " b with(nolock) on a.kisiref = b.logref " +
                    " where a.status < 2";

                if (!string.IsNullOrWhiteSpace(request.AtananUser))
                {
                    sql += " and a.atanan_kisi = '" + request.AtananUser + "'";
                }

                if (!string.IsNullOrWhiteSpace(request.InsUser))
                {
                    sql += " and a.insuser = '" + request.InsUser + "'";
                }

                if (!string.IsNullOrWhiteSpace(request.SearchText))
                {
                    sql += " and(";
                    sql += "    a.cari_adi like @SearchText ";
                    sql += " or a.baslik like @SearchText ";
                    sql += " or a.aciklama like @SearchText ";
                    sql += " )";

                    p.Add("@SearchText", value: "%" + request.SearchText + "%", dbType: DbType.String);
                }

                if (request.BaslangicTarih != null)
                {
                    sql += " and a.son_tarih >= @bastar ";
                    p.Add("@bastar", value: request.BaslangicTarih, dbType: DbType.DateTime);
                }

                if (request.BitisTarih != null)
                {
                    var bittar = request.BitisTarih.Value.AddHours(23).AddMinutes(59);
                    sql += " and a.son_tarih <= @bittar ";
                    p.Add("@bittar", value: request.BitisTarih.Value.AddHours(23).AddMinutes(59), dbType: DbType.DateTime);
                }

                if (!string.IsNullOrWhiteSpace(request.Cariadi))
                {
                    sql += " and a.cari_adi like @cariadi ";
                    p.Add("@cariadi", value: "%" + request.Cariadi + "%", dbType: DbType.String);
                }

                if (!string.IsNullOrWhiteSpace(request.Kisiadi))
                {
                    sql += " and b.tamadi like @kisiadi ";
                    p.Add("@kisiadi", value: "%" + request.Kisiadi + "%", dbType: DbType.String);
                }

                if (request.Oncelik > 0)
                {
                    sql += " and a.oncelik = " + request.Oncelik;
                }

                if (request.Yapildi == 0)
                {
                    sql += " and a.yapildi = 0";
                }
                if (request.Yapildi == 1)
                {
                    sql += " and a.yapildi = 1";
                }

                sql += " order by vazife_tipi desc, son_tarih asc";
                var result = await db.QueryAsync<VazifeDto>(sql, p, commandType: CommandType.Text);

                db.Close();

                return result.ToList();
            }
        }

            public async Task<VazifeDto> SaveVazife(VazifeRequestDto request)
        {
            var connectionstring = Configuration.GetUmotaConnectionString(firmaId: request.FirmaId.ToString());
            var optionsBuilder = new DbContextOptionsBuilder<UmotaCompanyDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);

            using (UmotaCompanyDbContext dbContext = new UmotaCompanyDbContext(optionsBuilder.Options))
            {
                var vazife = Mapper.Map<Vazife>(request.Vazife);

                await dbContext.Vazifes.AddAsync(vazife);
                await dbContext.SaveChangesAsync();

                return Mapper.Map<VazifeDto>(vazife);
            }
        }

        public async Task<VazifeDto> UpdateVazife(VazifeRequestDto request)
        {
            var connectionstring = Configuration.GetUmotaConnectionString(firmaId: request.FirmaId.ToString());
            var optionsBuilder = new DbContextOptionsBuilder<UmotaCompanyDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);

            using (UmotaCompanyDbContext dbContext = new UmotaCompanyDbContext(optionsBuilder.Options))
            {
                var row = await dbContext.Vazifes.Where(x => x.Logref == request.Vazife.Logref).SingleOrDefaultAsync();
                if (row == null)
                    throw new Exception("Kayıt bulunamadı");

                Mapper.Map(request.Vazife, row);
                await dbContext.SaveChangesAsync();

                return Mapper.Map<VazifeDto>(row);
            }
        }

        public Task<int> GetVazifeCount(VazifeRequestDto request)
        {
            var connectionstring = Configuration.GetUmotaConnectionString(firmaId: request.FirmaId.ToString());
            var optionsBuilder = new DbContextOptionsBuilder<UmotaCompanyDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);

            using (UmotaCompanyDbContext dbContext = new UmotaCompanyDbContext(optionsBuilder.Options))
            {
                var results = dbContext.Vazifes.Where(x => (x.AtananKisi == request.User) && x.Status < 2 && x.Yapildi == 0).Count();
                return Task.FromResult(results);
            }
        }
    }
}
