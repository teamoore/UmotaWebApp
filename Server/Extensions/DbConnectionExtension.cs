using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;

namespace UmotaWebApp.Server.Extensions
{
    public static class DbConnectionExtension
    {
        public static IServiceCollection AddDbConnection(this IServiceCollection collection)
        {
            using var serviceProvider = collection.BuildServiceProvider();
            var configuration = serviceProvider.GetService<IConfiguration>();
            var companyDb = configuration.GetUmotaConnectionString(null);
            collection.AddTransient<DbConnection, SqlConnection>(i => new SqlConnection(companyDb));
            
            return collection;
        }

    }
}
