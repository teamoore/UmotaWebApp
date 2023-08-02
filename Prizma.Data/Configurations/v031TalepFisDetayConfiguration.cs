using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UmotaWebApp.Shared.ViewModel;

namespace Prizma.Data.Configurations
{
    public class v031TalepFisDetayConfiguration : IEntityTypeConfiguration<V031_TalepDetay>
    {
        public void Configure(EntityTypeBuilder<V031_TalepDetay> builder)
        {
            builder.HasNoKey().ToView("v031_talep_detay");

            builder.Property(e => e.Aciklama)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("aciklama");
            builder.Property(e => e.Aktivite1adi)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("aktivite1adi");
            builder.Property(e => e.Aktivite1kodu)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("aktivite1kodu");
            builder.Property(e => e.Aktivite1ref).HasColumnName("aktivite1ref");
            builder.Property(e => e.Aktivite2adi)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("aktivite2adi");
            builder.Property(e => e.Aktivite2kodu)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("aktivite2kodu");
            builder.Property(e => e.Aktivite2ref).HasColumnName("aktivite2ref");
            builder.Property(e => e.Aktivite3adi)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("aktivite3adi");
            builder.Property(e => e.Aktivite3kodu)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("aktivite3kodu");
            builder.Property(e => e.Aktivite3ref).HasColumnName("aktivite3ref");
            builder.Property(e => e.Aktivite4adi)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("aktivite4adi");
            builder.Property(e => e.Aktivite4kodu)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("aktivite4kodu");
            builder.Property(e => e.Aktivite4ref).HasColumnName("aktivite4ref");
            builder.Property(e => e.Aktivite5adi)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("aktivite5adi");
            builder.Property(e => e.Aktivite5kodu)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("aktivite5kodu");
            builder.Property(e => e.Aktivite5ref).HasColumnName("aktivite5ref");
            builder.Property(e => e.Birimadi)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("birimadi");
            builder.Property(e => e.Birimkodu)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("birimkodu");
            builder.Property(e => e.Birimref).HasColumnName("birimref");
            builder.Property(e => e.Durumadi)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("durumadi");
            builder.Property(e => e.Durumikodu).HasColumnName("durumikodu");
            builder.Property(e => e.Durumref).HasColumnName("durumref");
            builder.Property(e => e.Fismiktar).HasColumnName("fismiktar");
            builder.Property(e => e.Insdate)
                .HasColumnType("datetime")
                .HasColumnName("insdate");
            builder.Property(e => e.Insuser)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("insuser");
            builder.Property(e => e.Kalanmiktar).HasColumnName("kalanmiktar");
            builder.Property(e => e.Kaynakadi)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("kaynakadi");
            builder.Property(e => e.Kaynakkodu)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("kaynakkodu");
            builder.Property(e => e.Kaynakref).HasColumnName("kaynakref");
            builder.Property(e => e.Logref).HasColumnName("logref");
            builder.Property(e => e.Mahal1adi)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("mahal1adi");
            builder.Property(e => e.Mahal1kodu)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("mahal1kodu");
            builder.Property(e => e.Mahal1ref).HasColumnName("mahal1ref");
            builder.Property(e => e.Mahal2adi)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("mahal2adi");
            builder.Property(e => e.Mahal2kodu)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("mahal2kodu");
            builder.Property(e => e.Mahal2ref).HasColumnName("mahal2ref");
            builder.Property(e => e.Mahal3adi)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("mahal3adi");
            builder.Property(e => e.Mahal3kodu)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("mahal3kodu");
            builder.Property(e => e.Mahal3ref).HasColumnName("mahal3ref");
            builder.Property(e => e.Mahal4adi)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("mahal4adi");
            builder.Property(e => e.Mahal4kodu)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("mahal4kodu");
            builder.Property(e => e.Mahal4ref).HasColumnName("mahal4ref");
            builder.Property(e => e.Mahal5adi)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("mahal5adi");
            builder.Property(e => e.Mahal5kodu)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("mahal5kodu");
            builder.Property(e => e.Mahal5ref).HasColumnName("mahal5ref");
            builder.Property(e => e.Marka)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("marka");
            builder.Property(e => e.Miktar).HasColumnName("miktar");
            builder.Property(e => e.Parlogref).HasColumnName("parlogref");
            builder.Property(e => e.Plfismiktar).HasColumnName("plfismiktar");
            builder.Property(e => e.Plsipmiktar).HasColumnName("plsipmiktar");
            builder.Property(e => e.Renk1).HasColumnName("renk1");
            builder.Property(e => e.Renk2).HasColumnName("renk2");
            builder.Property(e => e.Sipmiktar).HasColumnName("sipmiktar");
            builder.Property(e => e.Sirano).HasColumnName("sirano");
            builder.Property(e => e.Status).HasColumnName("status");
            builder.Property(e => e.Teslimtarihi)
                .HasColumnType("datetime")
                .HasColumnName("teslimtarihi");
            builder.Property(e => e.Teslimyeriadi)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("teslimyeriadi");
            builder.Property(e => e.Teslimyeriref).HasColumnName("teslimyeriref");
            builder.Property(e => e.Upddate)
                .HasColumnType("datetime")
                .HasColumnName("upddate");
            builder.Property(e => e.Upduser)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("upduser");
        }
    }
}
