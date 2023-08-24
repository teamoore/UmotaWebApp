﻿using Microsoft.EntityFrameworkCore;
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
        public DbSet<V031_TalepDetay> v031_TalepFisDetay { get; set; }
        public DbSet<TalepOnay> TalepOnaay { get; set; }
        public DbSet<V032_TalepOnay> v032_TalepOnay { get; set; }
        public DbSet<V001Aktivite> v001Aktivite { get; set; }

        public DbSet<V005Mahal> v005Mahal { get; set; }
        public DbSet<V040_Siparis> v040_Siparis { get; set; }

        public DbSet<TalepDosya> TalepDosya { get; set; }

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
            modelBuilder.ApplyConfiguration(new v040SiparisConfiguration());
            modelBuilder.ApplyConfiguration(new v031TalepFisDetayConfiguration());
            modelBuilder.ApplyConfiguration(new v001AktiviteConfiguration());
            modelBuilder.ApplyConfiguration(new v005MahalConfiguration());
            modelBuilder.ApplyConfiguration(new TalepOnayConfiguration());
            modelBuilder.ApplyConfiguration(new v032TalepOnayConfiguration());
            modelBuilder.ApplyConfiguration(new TalepDosyaConfiguration());
        }
    }
}
