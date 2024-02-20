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
    public class SiparisDetayConfiguration : IEntityTypeConfiguration<SiparisDetay>
    {
        public void Configure(EntityTypeBuilder<SiparisDetay> builder)
        {
            builder.HasKey(e => e.logref);

            builder.ToTable("siparis_detay");

            builder.Property(e => e.ParLogRef).HasColumnName("parlogref");
            builder.Property(e => e.SiraNo).HasColumnName("sirano");
            builder.Property(e => e.mahal1ref).HasColumnName("mahal1ref");
            builder.Property(e => e.mahal2ref).HasColumnName("mahal2ref");
            builder.Property(e => e.mahal3ref).HasColumnName("mahal3ref");
            builder.Property(e => e.mahal4ref).HasColumnName("mahal4ref");
            builder.Property(e => e.mahal5ref).HasColumnName("mahal5ref");
            builder.Property(e => e.Aktivite1Ref).HasColumnName("aktivite1ref");
            builder.Property(e => e.Aktivite2Ref).HasColumnName("aktivite2ref");
            builder.Property(e => e.Aktivite3Ref).HasColumnName("aktivite3ref");
            builder.Property(e => e.Aktivite4Ref).HasColumnName("aktivite4ref");
            builder.Property(e => e.Aktivite5Ref).HasColumnName("aktivite5ref");
            builder.Property(e => e.KaynakRef).HasColumnName("kaynakref");
            builder.Property(e => e.Miktar).HasColumnName("miktar");
            builder.Property(e => e.BirimRef).HasColumnName("birimref");
            builder.Property(e => e.Aciklama).HasColumnName("aciklama");
            builder.Property(e => e.TeslimYeriRef).HasColumnName("teslimyeriref");
            builder.Property(e => e.TeslimTarihi).HasColumnName("teslimtarihi");
            builder.Property(e => e.TalepRef).HasColumnName("talepref");
            builder.Property(e => e.TalepDetayRef).HasColumnName("talepdetayref");
            builder.Property(e => e.Fiyat).HasColumnName("fiyat");
            builder.Property(e => e.FDovizRef).HasColumnName("fdovizref");
            builder.Property(e => e.FDovizKuru).HasColumnName("fdovizkuru");
            builder.Property(e => e.Tutar).HasColumnName("tutar");
            builder.Property(e => e.TutarTL).HasColumnName("tutar_tl");
            builder.Property(e => e.TutarRD).HasColumnName("tutar_rd");
            builder.Property(e => e.TutarID).HasColumnName("tutar_id");
            builder.Property(e => e.IskYuz).HasColumnName("iskyuz");
            builder.Property(e => e.IskTut).HasColumnName("isktut");
            builder.Property(e => e.IskTutTL).HasColumnName("isktut_tl");
            builder.Property(e => e.IskTutRD).HasColumnName("isktut_rd");
            builder.Property(e => e.IskTutID).HasColumnName("isktut_id");
            builder.Property(e => e.KdvYuz).HasColumnName("kdvyuz");
            builder.Property(e => e.KdvKod).HasColumnName("kdvkod");
            builder.Property(e => e.KdvTut).HasColumnName("kdvtut");
            builder.Property(e => e.KdvTutTL).HasColumnName("kdvtut_tl");
            builder.Property(e => e.KdvTutRD).HasColumnName("kdvtut_rd");
            builder.Property(e => e.KdvTutID).HasColumnName("kdvtut_id");
            builder.Property(e => e.TutarNet).HasColumnName("tutarnet");
            builder.Property(e => e.TutarNetTL).HasColumnName("tutarnet_tl");
            builder.Property(e => e.TutarNetRD).HasColumnName("tutarnet_rd");
            builder.Property(e => e.TutarNetID).HasColumnName("tutarnet_id");
            builder.Property(e => e.SevkMiktar).HasColumnName("sevkmiktar");
            builder.Property(e => e.KalanMiktar).HasColumnName("kalanmiktar");
            builder.Property(e => e.TalepBirimMiktar).HasColumnName("talepbirimmiktar");
            builder.Property(e => e.TalepMiktarFarki).HasColumnName("talepmiktarfarki");

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
