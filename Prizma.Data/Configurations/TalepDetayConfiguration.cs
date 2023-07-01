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
    public class TalepDetayConfiguration : IEntityTypeConfiguration<TalepDetay>
    {
        public void Configure(EntityTypeBuilder<TalepDetay> builder)
        {
            builder.HasKey(e => e.logref);
            
            builder.ToTable("talep_detay");

            builder.Property(e => e.logref)
                   .ValueGeneratedNever()
                   .HasColumnName("logref");

            builder.Property(e => e.Aciklama)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("aciklama")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

            builder.Property(e => e.Miktar).HasColumnName("miktar");
            builder.Property(e => e.BirimRef).HasColumnName("birimref");

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
