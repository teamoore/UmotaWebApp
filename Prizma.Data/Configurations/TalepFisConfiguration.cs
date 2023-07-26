using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prizma.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prizma.Data.Configurations
{
    internal class TalepFisConfiguration : IEntityTypeConfiguration<TalepFis>
    {
        public void Configure(EntityTypeBuilder<TalepFis> builder)
        {
            builder.ToTable("talep_fis");

            builder.HasKey(e => e.logref);
            builder.Property(e => e.logref)
                   .ValueGeneratedNever()
                   .HasColumnName("logref");

            builder.Property(t => t.FisNo).HasColumnName("fisno");
            builder.Property(t => t.Tarih).HasColumnName("tarih");
            builder.Property(t => t.Saat).HasColumnName("saat");
            builder.Property(t => t.TurRef).HasColumnName("turref");
            builder.Property(t => t.ProjeRef).HasColumnName("projeref");
            builder.Property(t => t.TalepEden).HasColumnName("talepeden");
            builder.Property(t => t.TeslimTarihi).HasColumnName("teslimtarihi");
            builder.Property(t => t.DurumRef).HasColumnName("durumref");
            builder.Property(t => t.status).HasColumnName("status");
            builder.Property(t => t.Oncelik).HasColumnName("oncelik");
            builder.Property(t => t.Aciklama).HasColumnName("aciklama");
            builder.Property(t => t.LgFirmaNo).HasColumnName("lgfirmano");
            builder.Property(t => t.TeslimYeriRef).HasColumnName("teslimyeriref");


            builder.Property(e => e.insdate)
              .HasColumnType("datetime")
              .HasColumnName("insdate");

            builder.Property(e => e.insuser)
                .HasMaxLength(21)
                .IsUnicode(false)
                .HasColumnName("insuser")
                .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

            builder.Property(e => e.upddate)
                .HasColumnType("datetime")
                .HasColumnName("upddate");

            builder.Property(e => e.upduser)
                .HasMaxLength(21)
                .IsUnicode(false)
                .HasColumnName("upduser")
                .UseCollation("SQL_Latin1_General_CP1254_CI_AS");
        }
    }
}
