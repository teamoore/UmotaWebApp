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
using UmotaWebApp.Shared.Consts;
using UmotaWebApp.Shared.CustomException;
using UmotaWebApp.Shared.ModelDto;
using UmotaWebApp.Shared.ModelDto.Request;

namespace UmotaWebApp.Server.Services.Infrastructure
{
    public class ServisService : IServisService
    {
        public IMapper Mapper { get; }
        public IConfiguration Configuration { get; }
        private readonly DbConnection _sql;
        private ISisKullaniciService SisKullaniciService { get; }

        public ServisService(IMapper mapper, IConfiguration configuration, DbConnection sql, ISisKullaniciService sisKullaniciService)
        {
            Mapper = mapper;
            Configuration = configuration;
            _sql = sql;
            SisKullaniciService = sisKullaniciService;
        }

        public async Task<ServisDto> GetServisByRef(int logref, string firma_id)
        {
            //using (SqlConnection db = new SqlConnection(Configuration.GetUmotaConnectionString(firma_id)))
            //{
            //    db.Open();

            //    var sql = "select top 1 *, bildirim_tarihi BildirimTarihi" +
            //        " from " + Configuration.GetUmotaObjectName("v012_servis", firmaId: firma_id) + " where logref=" + logref;

            //    var result = await db.QueryAsync<ServisDto>(sql, commandType: CommandType.Text);

            //    db.Close();

            //    return result.SingleOrDefault();
            //}

            var connectionstring = Configuration.GetUmotaConnectionString(firmaId: firma_id.ToString());
            var optionsBuilder = new DbContextOptionsBuilder<UmotaCompanyDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);

            using (UmotaCompanyDbContext dbContext = new UmotaCompanyDbContext(optionsBuilder.Options))
            {
                var results = await dbContext.V012Servis.Where(x => x.Logref == logref)
                    .ProjectTo<ServisDto>(Mapper.ConfigurationProvider)
                    .SingleOrDefaultAsync();

                return results;
            }
        }
        public async Task<List<ServisDto>> SearchServis(ServisRequestDto request)
        {
            using (SqlConnection db = new SqlConnection(Configuration.GetUmotaConnectionString(request.FirmaId.ToString())))
            {
                db.Open();
                var p = new DynamicParameters();

                string selectstr = "";
                if (request.TopRowCount > 0)
                    selectstr = "top " + request.TopRowCount;

                var sql = "select " + selectstr + " *, bildirim_tarihi BildirimTarihi" +
                    ", ilgili_kisi IlgiliKisi" +
                    " from " + Configuration.GetUmotaObjectName("v012_servis", firmaId: request.FirmaId.ToString()) + " a with(nolock) where 1=1";

                if (!string.IsNullOrWhiteSpace(request.SearchText))
                {
                    sql += " and(";
                    sql += "    a.cariadi like @SearchText ";
                    sql += " or a.carikodu like @SearchText ";
                    sql += " or a.bayikodu like @SearchText ";
                    sql += " or a.bayiadi like @SearchText ";
                    sql += " or a.serviskodu like @SearchText ";
                    sql += " or a.servisadi like @SearchText ";
                    sql += " or a.evrakno like @SearchText ";
                    sql += " or a.fisno like @SearchText ";
                    sql += " or a.ilgili_kisi like @SearchText ";
                    sql += " or a.yonlendirenkisi like @SearchText ";
                    sql += " or a.bayi_ilgili_kisi like @SearchText ";
                    sql += " or a.servis_ilgili_kisi like @SearchText ";
                    sql += " )";

                    p.Add("@SearchText", value: "%" + request.SearchText + "%", dbType: DbType.String);
                }

                if (request.BaslangicTarih != null)
                {
                    sql += " and a.tarih >= @bastar ";
                    p.Add("@bastar", value: request.BaslangicTarih, dbType: DbType.DateTime);
                }

                if (request.BitisTarih != null)
                {
                    var bittar = request.BitisTarih.Value.AddHours(23).AddMinutes(59);
                    sql += " and a.tarih <= @bittar ";
                    p.Add("@bittar", value: request.BitisTarih.Value.AddHours(23).AddMinutes(59), dbType: DbType.DateTime);
                }

                if (!string.IsNullOrWhiteSpace(request.Cariadi))
                {
                    sql += " and a.cariadi like @cariadi ";
                    p.Add("@cariadi", value: "%" + request.Cariadi + "%", dbType: DbType.String);
                }

                if (!string.IsNullOrWhiteSpace(request.Bayiadi))
                {
                    sql += " and a.bayiadi like @bayiadi ";
                    p.Add("@bayiadi", value: "%" + request.Bayiadi + "%", dbType: DbType.String);
                }

                if (!string.IsNullOrWhiteSpace(request.Servisadi))
                {
                    sql += " and a.servisadi like @servisadi ";
                    p.Add("@servisadi", value: "%" + request.Servisadi + "%", dbType: DbType.String);
                }

                if (!string.IsNullOrWhiteSpace(request.Kisiadi))
                {
                    sql += " and (a.ilgili_kisi like @kisiadi or a.yonlendirenkisi like @kisiadi or a.bayi_ilgili_kisi like @kisiadi or a.servis_ilgili_kisi like @kisiadi ) ";
                    p.Add("@kisiadi", value: "%" + request.Kisiadi + "%", dbType: DbType.String);
                }

                if (!string.IsNullOrWhiteSpace(request.Istipi))
                {
                    sql += " and a.istipi like @istipi ";
                    p.Add("@istipi", value: request.Istipi, dbType: DbType.String);
                }

                if (!string.IsNullOrWhiteSpace(request.Evrakno))
                {
                    sql += " and a.evrakno like @evrakno ";
                    p.Add("@evrakno", value: "%" + request.Evrakno + "%", dbType: DbType.String);
                }

                sql += " order by tarih desc";
                var result = await db.QueryAsync<ServisDto>(sql, p, commandType: CommandType.Text);

                db.Close();

                return result.ToList();
            }
        }
        public async Task<ServisDto> SaveServis(ServisRequestDto request)
        {
            var connectionstring = Configuration.GetUmotaConnectionString(firmaId: request.FirmaId.ToString());
            var optionsBuilder = new DbContextOptionsBuilder<UmotaCompanyDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);

            using (UmotaCompanyDbContext dbContext = new UmotaCompanyDbContext(optionsBuilder.Options))
            {
                var servis = Mapper.Map<Servi>(request.Servis);
                await dbContext.Servis.AddAsync(servis);

                await dbContext.SaveChangesAsync();
                return Mapper.Map<ServisDto>(servis);
            }
        }
        public async Task<ServisDto> UpdateServis(ServisRequestDto request)
        {
            var connectionstring = Configuration.GetUmotaConnectionString(firmaId: request.FirmaId.ToString());
            var optionsBuilder = new DbContextOptionsBuilder<UmotaCompanyDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);

            using (UmotaCompanyDbContext dbContext = new UmotaCompanyDbContext(optionsBuilder.Options))
            {
                var servisRow = await dbContext.Servis.Where(x => x.Logref == request.Servis.Logref).SingleOrDefaultAsync();
                if (servisRow == null)
                    throw new ApiException("Servis kaydı bulunamadı");

                Mapper.Map(request.Servis, servisRow);
                await dbContext.SaveChangesAsync();

                return Mapper.Map<ServisDto>(servisRow);
            }


        }
        public async Task<bool> DeleteServis(int logref, string firmaId, string kullanici)
        {
            if (string.IsNullOrEmpty(firmaId))
                throw new Exception("Firma Dönem seçimi yapınız");

            var connectionstring = Configuration.GetUmotaConnectionString(firmaId: firmaId);
            var optionsBuilder = new DbContextOptionsBuilder<UmotaCompanyDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);

            using (UmotaCompanyDbContext dbContext = new UmotaCompanyDbContext(optionsBuilder.Options))
            {
                var row = await dbContext.Servis.Where(x => x.Logref == logref)
                .FirstOrDefaultAsync();
                if (row == null)
                    throw new Exception("Silinecek kayıt bulunamadı");

                row.Status = 2;
                row.Upddate = DateTime.Now;
                row.Upduser = kullanici;

                await dbContext.SaveChangesAsync();

                return true;
            }


        }

    }
}
