using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Prizma.Core.Model;
using Prizma.Data.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UmotaWebApp.Shared;

namespace Prizma.Data
{
    public class PrizmaDbContext : DbContext
    {
        public DbSet<TalepDetay> TalepDetays { get; set; }
        public DbSet<Mahal> Mahals { get; set; }
        public DbSet<TalepFis> TalepFis { get; set; }
        public DbSet<Proje> Proje { get; set; }

        public DbSet<V030_TalepFis> v030_TalepFis { get; set; }


        public PrizmaDbContext(DbContextOptions<PrizmaDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TalepDetayConfiguration());
            modelBuilder.ApplyConfiguration(new MahalConfiguration());
            modelBuilder.ApplyConfiguration(new TalepFisConfiguration());
            modelBuilder.ApplyConfiguration(new ProjeConfiguration());
            modelBuilder.ApplyConfiguration(new v030TalepFisConfiguration());
        }
    }
}
