using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UmotaWebApp.Shared;

namespace Prizma.Data.Configurations
{
    public class v030TalepFisConfiguration : IEntityTypeConfiguration<V030_TalepFis>
    {
        public void Configure(EntityTypeBuilder<V030_TalepFis> builder)
        {
            builder.ToView("v030_talep_fis");
            builder.HasNoKey();

            builder.Property(t => t.LogRef).HasColumnName("logref");
            builder.Property(t => t.FisNo).HasColumnName("fisno");
            builder.Property(t => t.Tarih).HasColumnName("tarih");
            builder.Property(t => t.Saat).HasColumnName("saat");
            builder.Property(t => t.TurRef).HasColumnName("turref");
            builder.Property(t => t.ProjeRef).HasColumnName("projeref");
            builder.Property(t => t.TalepEden).HasColumnName("talepeden");
            builder.Property(t => t.TeslimTarihi).HasColumnName("teslimtarihi");
            builder.Property(t => t.DurumRef).HasColumnName("durumref");
            builder.Property(t => t.Status).HasColumnName("status");
            builder.Property(t => t.Oncelik).HasColumnName("oncelik");
            builder.Property(t => t.Aciklama).HasColumnName("aciklama");
            builder.Property(t => t.FirmaNo).HasColumnName("lgfirmano");
            builder.Property(t => t.TeslimYeriRef).HasColumnName("teslimyeriref");

            builder.Property(t => t.DurumiKodu).HasColumnName("durumikodu");
            builder.Property(t => t.DurumAdi).HasColumnName("durumadi");
            builder.Property(t => t.Renk1).HasColumnName("renk1");
            builder.Property(t => t.Renk2).HasColumnName("renk2");

            builder.Property(t => t.TuriKodu).HasColumnName("turikodu");
            builder.Property(t => t.TurAdi).HasColumnName("turadi");
            builder.Property(t => t.TurKodu).HasColumnName("turkodu");

            builder.Property(t => t.TeslimYeriiKodu).HasColumnName("teslimyeriikodu");
            builder.Property(t => t.TeslimYeriAdi).HasColumnName("teslimyeriadi");
            builder.Property(t => t.TeslimYeriKodu).HasColumnName("teslimyerikodu");
            builder.Property(t => t.ProjeKodu).HasColumnName("projekodu");
            builder.Property(t => t.ProjeAdi).HasColumnName("projeadi");
            builder.Property(t => t.ProjeSirketRef).HasColumnName("projesirketref");
            builder.Property(t => t.ProjeSirketKodu).HasColumnName("projesirketkodu");
            builder.Property(t => t.ProjeSirketAdi).HasColumnName("projesirketadi");

            builder.Property(e => e.InsDate)
              .HasColumnType("datetime")
              .HasColumnName("insdate");

            builder.Property(e => e.InsUser)
                .HasMaxLength(21)
                .IsUnicode(false)
                .HasColumnName("insuser")
                .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

            builder.Property(e => e.UpdDate)
                .HasColumnType("datetime")
                .HasColumnName("upddate");

            builder.Property(e => e.UpdUser)
                .HasMaxLength(21)
                .IsUnicode(false)
                .HasColumnName("upduser")
                .UseCollation("SQL_Latin1_General_CP1254_CI_AS");
        }
    }
}
