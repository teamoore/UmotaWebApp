using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using UmotaWebApp.Server.Logging;

namespace UmotaWebApp.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();

            var builder = WebApplication.CreateBuilder(args);

            // 1️⃣ Form limitlerini yükselt
            builder.Services.Configure<FormOptions>(options =>
            {
                options.MultipartBodyLengthLimit = long.MaxValue; // 2 GB+
                options.ValueLengthLimit = int.MaxValue;
                options.MultipartHeadersLengthLimit = int.MaxValue;
            });

            // 2️⃣ Kestrel limiti yükselt
            builder.WebHost.ConfigureKestrel(serverOptions =>
            {
                serverOptions.Limits.MaxRequestBodySize = long.MaxValue; // sınırsız
            });

            var app = builder.Build();

            // 3️⃣ Ayrıca runtime pipeline içinde de kontrol et (bazı hostinglerde gerekli)
            app.Use(async (context, next) =>
            {
                var bodySizeFeature = context.Features.Get<IHttpMaxRequestBodySizeFeature>();
                if (bodySizeFeature != null)
                    bodySizeFeature.MaxRequestBodySize = long.MaxValue;
                await next();
            });

            app.MapControllers();
            app.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureLogging(i =>
                {
                    i.ClearProviders();
                    i.SetMinimumLevel(LogLevel.Trace);
                    i.AddProvider(new UmotaLoggerProvider());
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                    .UseStartup<Startup>();
                });
    }
}
