using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Prizma.Core.Model;
using Prizma.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UmotaWebApp.Shared;
using UmotaWebApp.Shared.Enum;
using UmotaWebApp.Shared.ModelDto;

namespace Prizma.Data.Repositories
{
    public class TalepFisRepository : Repository<TalepFis>, ITalepFisRepository
    {
        private PrizmaDbContext dbContext
        {
            get { return Context as PrizmaDbContext; }
        }
        public TalepFisRepository(PrizmaDbContext dbContext) :base(dbContext) 
        { 
        }
        
        public async Task<TalepFis> CreateTalepFisAsync(TalepFis entity)
        {
            await dbContext.TalepFis.AddAsync(entity);
            await dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<List<TalepFisDto>> GetTalepFisListAsync(string kullanici)
        {
            var qry = from t in dbContext.TalepFis
                      join p in dbContext.Proje on t.ProjeRef equals p.logref

                      where t.insuser == kullanici
                      orderby t.insdate descending
                      select new TalepFisDto()
                      {
                          ProjeAdi = p.Adi,
                          TalepEden = t.TalepEden,
                          Aciklama = t.Aciklama,
                          TeslimTarihi = t.TeslimTarihi,
                          TeslimYeriRef = t.TeslimYeriRef,
                          insuser = t.insuser
                      };

            return await qry.ToListAsync();
        }

        public async Task<List<V030_TalepFis>> GetV030_TalepFisListAsync(TalepFisRequestDto request)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            string sql = "select";
            if (request.TopRowCount > 0 )
            {
                sql += " top " + request.TopRowCount;
            }
            sql += " a.* from v030_talep_fis a with(nolock)";
            if (request.TalepFis != null && request.TalepFis.logref != 0)
            {
                sql += " where a.logref = " + request.TalepFis.logref;
            } else
            {
                sql += " where 1 = 1";
                if (request.BaslangicTarih.HasValue)
                {
                    sql += " and a.tarih >= @bastar";
                    parameters.Add(new SqlParameter("@bastar", request.BaslangicTarih));
                }
                if (request.BitisTarih.HasValue)
                {
                    sql += " and a.tarih <= @bittar";
                    parameters.Add(new SqlParameter("@bittar", request.BitisTarih));
                }
                if (request.DurumRef.HasValue && request.DurumRef > 0)
                    sql += " and a.durumref = " + request.DurumRef;
                if (request.ProjeRef.HasValue && request.ProjeRef > 0)
                    sql += " and a.projeref = " + request.ProjeRef;
                if (request.TurRef.HasValue && request.TurRef > 0)
                    sql += " and a.turref = " + request.TurRef;
                if (!string.IsNullOrEmpty(request.DurumIKoduSecimList))
                    sql += " and a.durumikodu in (" + request.DurumIKoduSecimList + ")";
                if (request.OnayBekleyen == true)
                {
                    sql += " and exists ";
                    sql += " (select aa.logref from v032_talep_onay aa with(nolock)";
                    sql += "  where aa.onayuser like '%" + request.kullanicikodu + ";%'";
                    sql += "  and aa.talepref = a.logref";
                    sql += "  and aa.onayikodu = " + (int)SharedEnums.OnayDurumu.Bekliyor;
                    sql += "  and aa.active = 0 ";
                    sql += "  and not exists ";
                    sql += "  (select aaa.logref from v032_talep_onay aaa with(nolock)";
                    sql += "   where aaa.talepref = aa.talepref";
                    sql += "   and aaa.onaysira < aa.onaysira";
                    sql += "   and aaa.active = 0";
                    sql += "   and aaa.onayikodu <> " + (int)SharedEnums.OnayDurumu.Onaylandi;
                    sql += "  )";
                    sql += "  and not exists ";
                    sql += "  (select aaa.logref from v032_talep_onay aaa with(nolock)";
                    sql += "   where aaa.talepref = aa.talepref";
                    sql += "   and aaa.onaysira > aa.onaysira";
                    sql += "   and aaa.active = 0";
                    sql += "   and aaa.onayikodu <> " + (int)SharedEnums.OnayDurumu.Bekliyor;
                    sql += "  )";
                    sql += " )";
                }

                if (request.TumTalepleriGormeYetkisi == false)
                {
                    sql += " and (";
                    sql += " a.insuser like '" + request.kullanicikodu + "'";
                    sql += " or exists  ";
                    sql += "   (select aa.logref from v011_kullanici_detay_proje aa WITH(NOLOCK)";
                    sql += "    where aa.kullanici_kodu like '" + request.kullanicikodu + "'";
                    sql += "    and aa.projeref = a.projeref";
                    sql += "    and aa.active = 0 )";
                    sql += " )";
                }

                if (!string.IsNullOrWhiteSpace(request.SearchText))
                {
                    parameters.Add(new SqlParameter("@SearchText", "%" + request.SearchText + "%"));
                    sql += " and (";
                    sql += "    a.aciklama like @SearchText";
                    sql += " or a.projeadi like @SearchText";
                    sql += " or a.turadi like @SearchText";
                    sql += " or a.talepeden like @SearchText";
                    sql += " or a.fisno like @SearchText";
                    sql += " )";
                }
            }


            var result = dbContext.v030_TalepFis.FromSqlRaw(sql, parameters.ToArray());
            return await result.ToListAsync();

            //var qry = dbContext.v030_TalepFis.AsQueryable();

            //if (request.TalepFis != null)
            //{
            //    if (request.TalepFis.logref != 0)
            //        qry = qry.Where(x => x.LogRef == request.TalepFis.logref); 
            //}

            //if (request.DurumRef.HasValue)
            //    qry = qry.Where(x => x.DurumRef == request.DurumRef);

            //if (request.ProjeRef.HasValue)
            //    qry = qry.Where(x => x.ProjeRef == request.ProjeRef);

            //return await qry.ToListAsync();
        }
    }
}
