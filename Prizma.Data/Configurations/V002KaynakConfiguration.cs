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
    public class V002KaynakConfiguration : IEntityTypeConfiguration<V002_Kaynak>
    {
        public void Configure(EntityTypeBuilder<V002_Kaynak> builder)
        {
            builder.HasNoKey().ToView("v002_kaynak");

            builder.Property(e => e.Logref).HasColumnName("logref");
            builder.Property(e => e.Parlogref).HasColumnName("parlogref");
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

            builder.Property(e => e.Aktivitekodu).HasColumnName("aktivitekodu");
            builder.Property(e => e.Aktiviteadi).HasColumnName("aktiviteadi");
            builder.Property(e => e.Aktiviteref2).HasColumnName("aktiviteref2");
            builder.Property(e => e.Aktivitekodu2).HasColumnName("aktivitekodu2");
            builder.Property(e => e.Aktiviteadi2).HasColumnName("aktiviteadi2");
            builder.Property(e => e.Aktiviteref3).HasColumnName("aktiviteref3");
            builder.Property(e => e.Aktivitekodu3).HasColumnName("aktivitekodu3");
            builder.Property(e => e.Aktiviteadi3).HasColumnName("aktiviteadi3");
        }
    }
}
