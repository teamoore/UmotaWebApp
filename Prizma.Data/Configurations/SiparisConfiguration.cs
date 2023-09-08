using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Prizma.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UmotaWebApp.Shared;

namespace Prizma.Data.Configurations
{
    public class SiparisConfiguration : IEntityTypeConfiguration<Siparis>
    {
        public void Configure(EntityTypeBuilder<Siparis> builder)
        {
            builder.ToTable("siparis");

            builder.HasKey(e => e.logref);
            builder.Property(e => e.logref)
                   .ValueGeneratedNever()
                   .HasColumnName("logref");

            builder.Property(t => t.FisNo).HasColumnName("fisno");
            builder.Property(t => t.Tarih).HasColumnName("tarih");
            builder.Property(t => t.Saat).HasColumnName("saat");
            builder.Property(t => t.CariRef).HasColumnName("cariref");
            builder.Property(t => t.ProjeRef).HasColumnName("projeref");
            builder.Property(t => t.DurumRef).HasColumnName("durumref");
            builder.Property(t => t.DovizRefRD).HasColumnName("dovizref_rd");
            builder.Property(t => t.DovizKuruRD).HasColumnName("dovizkuru_rd");
            builder.Property(t => t.NetToplamRD).HasColumnName("nettoplam_rd");
            builder.Property(t => t.DovizRefID).HasColumnName("dovizref_id");
            builder.Property(t => t.DovizKurTurID).HasColumnName("dovizkurtur_id");
            builder.Property(t => t.DovizKuruID).HasColumnName("dovizkuru_id");
            builder.Property(t => t.NetToplamID).HasColumnName("nettoplam_id");
            builder.Property(t => t.NetToplamTL).HasColumnName("nettoplam_tl");
            builder.Property(t => t.LgFirmaNo).HasColumnName("lgfirmano");
            builder.Property(t => t.DosyaEki).HasColumnName("dosyaeki");
            builder.Property(t => t.Iptal).HasColumnName("iptal");
            builder.Property(t => t.IptalUser).HasColumnName("iptaluser");
            builder.Property(t => t.IptalDate).HasColumnName("iptaldate");
            builder.Property(t => t.IptalNedeni).HasColumnName("iptalnedeni");

            builder.Property(t => t.status).HasColumnName("status");
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
