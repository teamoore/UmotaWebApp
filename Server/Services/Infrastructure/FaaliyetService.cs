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

namespace UmotaWebApp.Server.Services.Infrastructure
{
    public class FaaliyetService : IFaaliyetService
    {
        public IMapper Mapper { get; }
        public IConfiguration Configuration { get; }
        private readonly DbConnection _sql;
        private ISisKullaniciService SisKullaniciService { get; }

        public FaaliyetService(IMapper mapper, IConfiguration configuration, DbConnection sql, ISisKullaniciService sisKullaniciService)
        {
            Mapper = mapper;
            Configuration = configuration;
            _sql = sql;
            SisKullaniciService = sisKullaniciService;
        }

        public async Task<FaaliyetDto> GetFaaliyetByRef(int logref, string firma_id)
        {
            using (SqlConnection db = new SqlConnection(Configuration.GetUmotaConnectionString(firma_id)))
            {
                db.Open();

                var sql = "select top 1 *, islem_sayisi IslemSayisi" +
                    " from " + Configuration.GetUmotaObjectName("v020_faaliyet", firmaId: firma_id) + " where logref=" + logref;

                var result = await db.QueryAsync<FaaliyetDto>(sql, commandType: CommandType.Text);

                db.Close();

                return result.SingleOrDefault();
            }
        }

        public async Task<List<FaaliyetDto>> GetFaaliyets(string firmaId, string kullanicikodu)
        {
            using (SqlConnection db = new SqlConnection(Configuration.GetUmotaConnectionString(firmaId)))
            {
                db.Open();

                var sql = "select top 100 *, islem_sayisi IslemSayisi" +
                    " from " + Configuration.GetUmotaObjectName("v020_faaliyet", firmaId: firmaId) + " a with(nolock) where 1=1";

                var tumFaaliyetleriGormeYetkisi = await SisKullaniciService.GetKullaniciYetkisiByKullaniciKodu(kullanicikodu, KullaniciYetkiKodlari.TumFaaliyetleriGorebilir);
                if (tumFaaliyetleriGormeYetkisi == 0)
                {
                    sql += " and (";
                    sql += "    (insuser = '" + kullanicikodu + "')";
                    sql += " )";
                }

                sql += " order by insdate desc";
                var result = await db.QueryAsync<FaaliyetDto>(sql, commandType: CommandType.Text);

                db.Close();

                return result.ToList();

            }

        }
        public async Task<List<FaaliyetDto>> SearchFaaliyet(FaaliyetRequestDto request)
        {
            var connectionstring = Configuration.GetUmotaConnectionString(firmaId: request.FirmaId.ToString());
            var optionsBuilder = new DbContextOptionsBuilder<UmotaCompanyDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);

            using (UmotaCompanyDbContext dbContext = new UmotaCompanyDbContext(optionsBuilder.Options))
            {
                var word = request.Aranacak.ToLower();

                return await dbContext.V020Faaliyets.Where(x => x.Yapilanlar.ToLower().Contains(word)
                || x.Grup1.ToLower().Contains(word)
                || x.Grup2.ToLower().Contains(word)
                || x.Grup3.ToLower().Contains(word)
                || x.Grup4.ToLower().Contains(word)
                || x.Grup5.ToLower().Contains(word)
                || x.Malzemeadi.ToLower().Contains(word)
                || x.Malzemekodu.ToLower().Contains(word)
                || x.Giren.ToLower().Contains(word)
                || x.Cariadi.ToLower().Contains(word)
                || x.Carikodu.ToLower().Contains(word)
                || x.Konu.ToLower().Contains(word)
                || x.Kisiadi.ToLower().Contains(word))
                    .OrderByDescending(x => x.Tarih)
                    .ProjectTo<FaaliyetDto>(Mapper.ConfigurationProvider).ToListAsync();
            }

        }

        public async Task<FaaliyetDto> SaveFaaliyet(FaaliyetRequestDto request)
        {
            var connectionstring = Configuration.GetUmotaConnectionString(firmaId: request.FirmaId.ToString());
            var optionsBuilder = new DbContextOptionsBuilder<UmotaCompanyDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);

            using (UmotaCompanyDbContext dbContext = new UmotaCompanyDbContext(optionsBuilder.Options))
            {
                var faaliyet = Mapper.Map<Faaliyet>(request.Faaliyet);
                await dbContext.Faaliyets.AddAsync(faaliyet);

                await dbContext.SaveChangesAsync();
                return Mapper.Map<FaaliyetDto>(faaliyet);
            }
        }
        public async Task<FaaliyetDto> UpdateFaaliyet(FaaliyetRequestDto request)
        {
            var connectionstring = Configuration.GetUmotaConnectionString(firmaId: request.FirmaId.ToString());
            var optionsBuilder = new DbContextOptionsBuilder<UmotaCompanyDbContext>();
            optionsBuilder.UseSqlServer(connectionstring);

            using (UmotaCompanyDbContext dbContext = new UmotaCompanyDbContext(optionsBuilder.Options))
            {
                var faaliyetRow = await dbContext.Faaliyets.Where(x => x.Logref == request.Faaliyet.Logref).SingleOrDefaultAsync();
                if (faaliyetRow == null)
                    throw new ApiException("Faaliyet bulunamadı");

                Mapper.Map(request.Faaliyet, faaliyetRow);
                await dbContext.SaveChangesAsync();

                return Mapper.Map<FaaliyetDto>(faaliyetRow);
            }


        }


    }
}
