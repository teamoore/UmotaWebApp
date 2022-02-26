using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using UmotaWebApp.Server.Services.Extensions;
using UmotaWebApp.Server.Services.Infrastructure;
using UmotaWebApp.Server.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using UmotaWebApp.Server.Extensions;

namespace UmotaWebApp.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllersWithViews();
            services.AddRazorPages();

            services.ConfigureMapping();

            services.AddDbConnection();

            services.AddScoped<ISisKullaniciService, SisKullaniciService>();
            services.AddScoped<ISisFirmaService, SisFirmaService>();
            services.AddScoped<ISisMenuService, SisMenuService>();
            services.AddScoped<ICariKartService, CariKartService>();
            services.AddScoped<IRefGenerator, RefGeneratorService>();
            services.AddScoped<ITeklifService, TeklifService>();
            services.AddScoped<ITeklifDetayService, TeklifDetayService>();
            services.AddScoped<IMalzemeKartService, MalzemeKartService>();
            services.AddScoped<IPersonelService, PersonelService>();
            services.AddScoped<ISisFirmaDonemService, SisFirmaDonemService>();

            services.AddDbContext<UmotaMasterDbContext>(config =>
            {
                config.UseSqlServer(Configuration.GetUmotaConnectionString());
            });

            services.AddDbContext<UmotaCompanyDbContext>(config =>
            {
                config.UseSqlServer(Configuration.GetConnectionString("companyDb"));
            });


            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(op => {
                op.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["JwtIssuer"],
                    ValidAudience = Configuration["JwtAudience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtSecurityKey"]))
                };
            });

            services.AddHealthChecks();

            services.AddLogging();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });

        }
    }
}
