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
    public class KaynakConfiguration : IEntityTypeConfiguration<Kaynak>
    {
        public void Configure(EntityTypeBuilder<Kaynak> builder)
        {
            builder.HasKey(e => e.logref);

            builder.ToTable("kaynak");

            builder.Property(e => e.parlogref).HasColumnName("parlogref");
            builder.Property(e => e.Kodu).HasColumnName("kodu");
            builder.Property(e => e.Adi).HasColumnName("adi");
            builder.Property(e => e.Seviye).HasColumnName("seviye");
            builder.Property(e => e.Uzunkodu).HasColumnName("uzunkodu");
            builder.Property(e => e.Uzunadi).HasColumnName("uzunadi");
            builder.Property(e => e.Aktiviteref).HasColumnName("aktiviteref");
            builder.Property(e => e.Kdvyuz).HasColumnName("kdvyuz");
            
            builder.Property(e => e.active).HasColumnName("active");
            builder.Property(e => e.status).HasColumnName("status");

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
