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
    public class v040SiparisConfiguration : IEntityTypeConfiguration<V040_Siparis>
    {
        public void Configure(EntityTypeBuilder<V040_Siparis> builder)
        {
            builder.ToView("v040_siparis");
            builder.HasNoKey();

            builder.Property(t => t.LogRef).HasColumnName("logref");
            builder.Property(t => t.FisNo).HasColumnName("fisno");
            builder.Property(t => t.Tarih).HasColumnName("tarih");
            builder.Property(t => t.Saat).HasColumnName("saat");
            builder.Property(t => t.CariRef).HasColumnName("cariref");
            builder.Property(t => t.ProjeRef).HasColumnName("projeref");
            builder.Property(t => t.DurumRef).HasColumnName("durumref");
            builder.Property(t => t.Status).HasColumnName("status");
            builder.Property(t => t.lgFirmaNo).HasColumnName("lgfirmano");

            builder.Property(t => t.DurumiKodu).HasColumnName("durumikodu");
            builder.Property(t => t.DurumAdi).HasColumnName("durumadi");
            builder.Property(t => t.Renk1).HasColumnName("renk1");
            builder.Property(t => t.Renk2).HasColumnName("renk2");

            builder.Property(t => t.CariKodu).HasColumnName("carikodu");
            builder.Property(t => t.CariAdi).HasColumnName("cariadi");

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
