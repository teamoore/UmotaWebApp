using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using UmotaWebApp.Server.Extensions;
using UmotaWebApp.Shared.ModelDto;

namespace UmotaWebApp.Server.Services.Infrastructure
{
    public class RaporService : IRaporService
    {
        public IConfiguration Configuration { get; }

        public RaporService(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public async Task<List<ProjeDetayRaporuDto>> ProjeDetayRaporu(ProjeDetayRaporuReq request)
        {
            using (SqlConnection db = new SqlConnection(Configuration.GetUmotaConnectionString()))
            {
                // Eğer request içindeki FirmNr veya FirmNr2 boş ya da 0 ise
                // Configuration'daki varsayılan değerleri ata
                int firmNr = request.FirmNr > 0
                    ? request.FirmNr
                    : Convert.ToInt32(Configuration["LogoFirmaNo"]);

                int firmNr2 = request.FirmNr2 > 0
                    ? request.FirmNr2
                    : Convert.ToInt32(Configuration["LogoFirmaNo2"]);


                var p = new DynamicParameters();
                p.Add("@FirmNr", firmNr);
                p.Add("@FirmNr2", firmNr2);
                p.Add("@ProjeKodu", request.ProjeKodu);
                p.Add("@ProjeOzelKod", request.ProjeOzelKod);
                p.Add("@GelirGider", request.GelirGider);
                var res = await db.QueryAsync<ProjeDetayRaporuDto>("UmotaRaporSP_ProjeDetayRaporu", p, commandType: CommandType.StoredProcedure);
                return res.ToList();
            }
        }
    }
}
