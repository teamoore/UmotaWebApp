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
    internal class TalepDosyaConfiguration : IEntityTypeConfiguration<TalepDosya>
    {
        public void Configure(EntityTypeBuilder<TalepDosya> builder)
        {
            builder.ToTable("talep_dosya");
            builder.HasKey(x => x.logref);

            builder.Property(x => x.TalepLogRef).HasColumnName("taleplogref");
            builder.Property(x => x.DosyaAdi).HasColumnName("dosyaadi");
            builder.Property(x => x.DosyaTipi).HasColumnName("dosyatipi");

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
