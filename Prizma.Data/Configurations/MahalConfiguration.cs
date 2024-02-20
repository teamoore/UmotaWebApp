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
    public class MahalConfiguration : IEntityTypeConfiguration<Mahal>
    {
        public void Configure(EntityTypeBuilder<Mahal> builder)
        {
            builder.HasKey(e => e.logref);

            builder.ToTable("mahal");

            builder.Property(e => e.Adi).HasColumnName("adi");
            builder.Property(e => e.Kodu).HasColumnName("kodu");
            builder.Property(e => e.DurumRef).HasColumnName("durumref");
            builder.Property(e => e.TurRef).HasColumnName("turref");
            builder.Property(e => e.Active).HasColumnName("active");

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
