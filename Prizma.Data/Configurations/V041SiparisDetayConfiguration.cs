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
    public class V041SiparisDetayConfiguration : IEntityTypeConfiguration<V041_SiparisDetay>
    {
        public void Configure(EntityTypeBuilder<V041_SiparisDetay> builder)
        {
            builder.HasNoKey().ToView("v041_siparis_detay");

            builder.Property(e => e.Parlogref).HasColumnName("parlogref");
            builder.Property(e => e.Sirano).HasColumnName("sirano");
            builder.Property(e => e.Mahal1ref).HasColumnName("mahal1ref");
            builder.Property(e => e.Mahal1kodu).HasColumnName("mahal1kodu");
            builder.Property(e => e.Mahal1adi).HasColumnName("mahal1adi");
            builder.Property(e => e.Mahal2ref).HasColumnName("mahal2ref");
            builder.Property(e => e.Mahal2kodu).HasColumnName("mahal2kodu");
            builder.Property(e => e.Mahal2adi).HasColumnName("mahal2adi");
            builder.Property(e => e.Mahal3ref).HasColumnName("mahal3ref");
            builder.Property(e => e.Mahal3kodu).HasColumnName("mahal3kodu");
            builder.Property(e => e.Mahal3adi).HasColumnName("mahal3adi");
            builder.Property(e => e.Mahal4ref).HasColumnName("mahal4ref");
            builder.Property(e => e.Mahal4kodu).HasColumnName("mahal4kodu");
            builder.Property(e => e.Mahal4adi).HasColumnName("mahal4adi");
            builder.Property(e => e.Mahal5ref).HasColumnName("mahal5ref");
            builder.Property(e => e.Mahal5kodu).HasColumnName("mahal5kodu");
            builder.Property(e => e.Mahal5adi).HasColumnName("mahal5adi");
            builder.Property(e => e.Aktivite1ref).HasColumnName("aktivite1ref");
            builder.Property(e => e.Aktivite1kodu).HasColumnName("aktivite1kodu");
            builder.Property(e => e.Aktivite1adi).HasColumnName("aktivite1adi");
            builder.Property(e => e.Aktivite2ref).HasColumnName("aktivite2ref");
            builder.Property(e => e.Aktivite2kodu).HasColumnName("aktivite2kodu");
            builder.Property(e => e.Aktivite2adi).HasColumnName("aktivite2adi");
            builder.Property(e => e.Aktivite3ref).HasColumnName("aktivite3ref");
            builder.Property(e => e.Aktivite3kodu).HasColumnName("aktivite3kodu");
            builder.Property(e => e.Aktivite3adi).HasColumnName("aktivite3adi");
            builder.Property(e => e.Aktivite4ref).HasColumnName("aktivite4ref");
            builder.Property(e => e.Aktivite4kodu).HasColumnName("aktivite4kodu");
            builder.Property(e => e.Aktivite4adi).HasColumnName("aktivite4adi");
            builder.Property(e => e.Aktivite5ref).HasColumnName("aktivite5ref");
            builder.Property(e => e.Aktivite5kodu).HasColumnName("aktivite5kodu");
            builder.Property(e => e.Aktivite5adi).HasColumnName("aktivite5adi");
            builder.Property(e => e.Kaynakref).HasColumnName("kaynakref");
            builder.Property(e => e.Kaynakkodu).HasColumnName("kaynakkodu");
            builder.Property(e => e.Kaynakadi).HasColumnName("kaynakadi");
            builder.Property(e => e.Miktar).HasColumnName("miktar");
            builder.Property(e => e.Birimref).HasColumnName("birimref");
            builder.Property(e => e.Birimkodu).HasColumnName("birimkodu");
            builder.Property(e => e.Birimadi).HasColumnName("birimadi");
            builder.Property(e => e.Aciklama).HasColumnName("aciklama");
            builder.Property(e => e.Teslimyeriref).HasColumnName("teslimyeriref");
            builder.Property(e => e.Teslimtarihi).HasColumnName("teslimtarihi");
            builder.Property(e => e.TalepRef).HasColumnName("talepref");
            builder.Property(e => e.TalepDetayRef).HasColumnName("talepdetayref");
            builder.Property(e => e.Fiyat).HasColumnName("fiyat");
            builder.Property(e => e.FDovizRef).HasColumnName("fdovizref");
            builder.Property(e => e.FDovizKodu).HasColumnName("fdovizkodu");
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
            builder.Property(e => e.TalepFisNo).HasColumnName("talepfisno");
            builder.Property(e => e.TalepDetaySiraNo).HasColumnName("talepdetaysirano");
            builder.Property(e => e.TalepMiktar).HasColumnName("talepmiktar");
            builder.Property(e => e.TalepDetayBirimRef).HasColumnName("talepdetaybirimref");
            builder.Property(e => e.TalepDetayBirimKodu).HasColumnName("talepdetaybirimkodu");

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
