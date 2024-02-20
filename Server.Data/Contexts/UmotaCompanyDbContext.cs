using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace UmotaWebApp.Server.Data.Models
{
    public partial class UmotaCompanyDbContext : DbContext
    {
        public UmotaCompanyDbContext()
        {
        }

        public UmotaCompanyDbContext(DbContextOptions<UmotaCompanyDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CariKart> CariKarts { get; set; }
        public virtual DbSet<CariKartLog> CariKartLogs { get; set; }
        public virtual DbSet<CariKullandiklariUrunler> CariKullandiklariUrunlers { get; set; }
        public virtual DbSet<Faaliyet> Faaliyets { get; set; }
        public virtual DbSet<FiltreHar> FiltreHars { get; set; }
        public virtual DbSet<FiltreHarDetay> FiltreHarDetays { get; set; }
        public virtual DbSet<FiltreSure> FiltreSures { get; set; }
        public virtual DbSet<FiltreSureLog> FiltreSureLogs { get; set; }
        public virtual DbSet<Gorev> Gorevs { get; set; }
        public virtual DbSet<GorevUser> GorevUsers { get; set; }
        public virtual DbSet<Kisiler> Kisilers { get; set; }
        public virtual DbSet<KullaniciTanimlari> KullaniciTanimlaris { get; set; }
        public virtual DbSet<MalzKalite> MalzKalites { get; set; }
        public virtual DbSet<MalzKaliteLog> MalzKaliteLogs { get; set; }
        public virtual DbSet<MalzKart> MalzKarts { get; set; }
        public virtual DbSet<MalzKartLog> MalzKartLogs { get; set; }
        public virtual DbSet<Refno> Refnos { get; set; }
        public virtual DbSet<Servi> Servis { get; set; }
        public virtual DbSet<ServisEskiler> ServisEskilers { get; set; }
        public virtual DbSet<ServisHakedi> ServisHakedis { get; set; }
        public virtual DbSet<ServisHakedisLog> ServisHakedisLogs { get; set; }
        public virtual DbSet<ServisLog> ServisLogs { get; set; }
        public virtual DbSet<ServisMalzemeler> ServisMalzemelers { get; set; }
        public virtual DbSet<ServisMalzemelerLog> ServisMalzemelerLogs { get; set; }
        public virtual DbSet<Teklif> Teklifs { get; set; }
        public virtual DbSet<TeklifDosya> TeklifDosyas { get; set; }
        public virtual DbSet<TeklifDosyaPath> TeklifDosyaPaths { get; set; }
        public virtual DbSet<TeklifDosyaPathLog> TeklifDosyaPathLogs { get; set; }
        public virtual DbSet<TeklifDurumDetay> TeklifDurumDetays { get; set; }
        public virtual DbSet<TeklifFinansOnay> TeklifFinansOnays { get; set; }
        public virtual DbSet<TeklifFinansOnayLog> TeklifFinansOnayLogs { get; set; }
        public virtual DbSet<TeklifLog> TeklifLogs { get; set; }
        public virtual DbSet<TeklifOnaylamaYetkileri> TeklifOnaylamaYetkileris { get; set; }
        public virtual DbSet<TeklifRotaLog> TeklifRotaLogs { get; set; }
        public virtual DbSet<TeklifRotum> TeklifRota { get; set; }
        public virtual DbSet<TeklifSabitler> TeklifSabitlers { get; set; }
        public virtual DbSet<TeklifSabitlerLog> TeklifSabitlerLogs { get; set; }
        public virtual DbSet<Teklifdetay> Teklifdetays { get; set; }
        public virtual DbSet<TeklifdetayLog> TeklifdetayLogs { get; set; }
        public virtual DbSet<UmtMuhasebeTablo> UmtMuhasebeTablos { get; set; }
        public virtual DbSet<UmtMuhasebeTabloDetay> UmtMuhasebeTabloDetays { get; set; }
        public virtual DbSet<V001CariKart> V001CariKarts { get; set; }
        public virtual DbSet<V001CariKart2> V001CariKart2s { get; set; }
        public virtual DbSet<V002Malzemeler> V002Malzemelers { get; set; }
        public virtual DbSet<V004Sevkadre> V004Sevkadres { get; set; }
        public virtual DbSet<V009Teklif> V009Teklifs { get; set; }
        public virtual DbSet<V009Teklif2> V009Teklif2s { get; set; }
        public virtual DbSet<V010Teklifdetay> V010Teklifdetays { get; set; }
        public virtual DbSet<V011TeklifRotum> V011TeklifRota { get; set; }
        public virtual DbSet<V012Servi> V012Servis { get; set; }
        public virtual DbSet<V012ServisMalzemeler> V012ServisMalzemelers { get; set; }
        public virtual DbSet<V013ServisHakedi> V013ServisHakedis { get; set; }
        public virtual DbSet<V015Kisiler> V015Kisilers { get; set; }
        public virtual DbSet<V020Faaliyet> V020Faaliyets { get; set; }
        public virtual DbSet<V029Teklif> V029Teklifs { get; set; }
        public virtual DbSet<V029Teklif2> V029Teklif2s { get; set; }
        public virtual DbSet<V040FiltreSure> V040FiltreSures { get; set; }
        public virtual DbSet<V041FiltreMontaj> V041FiltreMontajs { get; set; }
        public virtual DbSet<V042FiltreMontaj> V042FiltreMontajs { get; set; }
        public virtual DbSet<V050MalzKalite> V050MalzKalites { get; set; }
        public virtual DbSet<Vazife> Vazifes { get; set; }

        public virtual DbSet<Takvim> Takvims { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=TIMURGUNDOGDU\\SQLEXPRESS;Database=UmotaUnoPazar_001;user=umota; password=123456;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Turkish_CI_AS");

            modelBuilder.Entity<CariKart>(entity =>
            {
                entity.HasKey(e => e.Logref)
                    .HasName("pk_cari_kart");

                entity.ToTable("cari_kart");

                entity.Property(e => e.Logref)
                    .ValueGeneratedNever()
                    .HasColumnName("logref");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Adi)
                    .HasMaxLength(51)
                    .IsUnicode(false)
                    .HasColumnName("adi")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

                entity.Property(e => e.Adi2)
                    .HasMaxLength(51)
                    .IsUnicode(false)
                    .HasColumnName("adi2")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

                entity.Property(e => e.Adres1)
                    .HasMaxLength(51)
                    .IsUnicode(false)
                    .HasColumnName("adres1")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

                entity.Property(e => e.Adres2)
                    .HasMaxLength(51)
                    .IsUnicode(false)
                    .HasColumnName("adres2")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

                entity.Property(e => e.Faks)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasColumnName("faks")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

                entity.Property(e => e.Il)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("il")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

                entity.Property(e => e.Ilce)
                    .HasMaxLength(51)
                    .IsUnicode(false)
                    .HasColumnName("ilce")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

                entity.Property(e => e.Ilceref).HasColumnName("ilceref");

                entity.Property(e => e.Ilref).HasColumnName("ilref");

                entity.Property(e => e.Insdate)
                    .HasColumnType("datetime")
                    .HasColumnName("insdate");

                entity.Property(e => e.Insuser)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("insuser")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

                entity.Property(e => e.Kodu)
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("kodu")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

                entity.Property(e => e.Logoref).HasColumnName("logoref");

                entity.Property(e => e.Mail)
                    .HasMaxLength(51)
                    .IsUnicode(false)
                    .HasColumnName("mail")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

                entity.Property(e => e.Nakliye)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nakliye")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

                entity.Property(e => e.Nakliyeodeme)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nakliyeodeme")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

                entity.Property(e => e.Odmplnref).HasColumnName("odmplnref");

                entity.Property(e => e.Ozelkod)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("ozelkod")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

                entity.Property(e => e.Ozelkod2)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("ozelkod2")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

                entity.Property(e => e.Ozelkod3)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("ozelkod3")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

                entity.Property(e => e.Ozelkod4)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("ozelkod4")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

                entity.Property(e => e.Ozelkod5)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("ozelkod5")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

                entity.Property(e => e.Postakodu)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("postakodu")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

                entity.Property(e => e.Sahismi).HasColumnName("sahismi");

                entity.Property(e => e.Semt)
                    .HasMaxLength(51)
                    .IsUnicode(false)
                    .HasColumnName("semt")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

                entity.Property(e => e.Semtref).HasColumnName("semtref");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Tel1)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasColumnName("tel1")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

                entity.Property(e => e.Tel2)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasColumnName("tel2")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

                entity.Property(e => e.Ulke)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("ulke")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

                entity.Property(e => e.Ulkeref).HasColumnName("ulkeref");

                entity.Property(e => e.Upddate)
                    .HasColumnType("datetime")
                    .HasColumnName("upddate");

                entity.Property(e => e.Upduser)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("upduser")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

                entity.Property(e => e.Vdadi)
                    .HasMaxLength(31)
                    .IsUnicode(false)
                    .HasColumnName("vdadi")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

                entity.Property(e => e.Vdno)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("vdno")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

                entity.Property(e => e.Web)
                    .HasMaxLength(41)
                    .IsUnicode(false)
                    .HasColumnName("web")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");
            });

            modelBuilder.Entity<CariKartLog>(entity =>
            {
                entity.HasKey(e => e.Recref)
                    .HasName("pk_cari_kart_log");

                entity.ToTable("cari_kart_log");

                entity.Property(e => e.Recref).HasColumnName("recref");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Adi)
                    .HasMaxLength(51)
                    .IsUnicode(false)
                    .HasColumnName("adi")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

                entity.Property(e => e.Adi2)
                    .HasMaxLength(51)
                    .IsUnicode(false)
                    .HasColumnName("adi2")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

                entity.Property(e => e.Adres1)
                    .HasMaxLength(51)
                    .IsUnicode(false)
                    .HasColumnName("adres1")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

                entity.Property(e => e.Adres2)
                    .HasMaxLength(51)
                    .IsUnicode(false)
                    .HasColumnName("adres2")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

                entity.Property(e => e.Faks)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasColumnName("faks")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

                entity.Property(e => e.Il)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("il")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

                entity.Property(e => e.Ilce)
                    .HasMaxLength(51)
                    .IsUnicode(false)
                    .HasColumnName("ilce")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

                entity.Property(e => e.Ilceref).HasColumnName("ilceref");

                entity.Property(e => e.Ilref).HasColumnName("ilref");

                entity.Property(e => e.Insdate)
                    .HasColumnType("datetime")
                    .HasColumnName("insdate");

                entity.Property(e => e.Insuser)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("insuser")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

                entity.Property(e => e.Kodu)
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("kodu")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

                entity.Property(e => e.Logoref).HasColumnName("logoref");

                entity.Property(e => e.Logref).HasColumnName("logref");

                entity.Property(e => e.Mail)
                    .HasMaxLength(51)
                    .IsUnicode(false)
                    .HasColumnName("mail")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

                entity.Property(e => e.Nakliye)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nakliye")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

                entity.Property(e => e.Nakliyeodeme)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nakliyeodeme")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

                entity.Property(e => e.Odmplnref).HasColumnName("odmplnref");

                entity.Property(e => e.Ozelkod)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("ozelkod")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

                entity.Property(e => e.Ozelkod2)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("ozelkod2")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

                entity.Property(e => e.Ozelkod3)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("ozelkod3")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

                entity.Property(e => e.Ozelkod4)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("ozelkod4")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

                entity.Property(e => e.Ozelkod5)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("ozelkod5")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

                entity.Property(e => e.Postakodu)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("postakodu")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

                entity.Property(e => e.Sahismi).HasColumnName("sahismi");

                entity.Property(e => e.Semt)
                    .HasMaxLength(51)
                    .IsUnicode(false)
                    .HasColumnName("semt")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

                entity.Property(e => e.Semtref).HasColumnName("semtref");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Tel1)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasColumnName("tel1")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

                entity.Property(e => e.Tel2)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasColumnName("tel2")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

                entity.Property(e => e.Ulke)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("ulke")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

                entity.Property(e => e.Ulkeref).HasColumnName("ulkeref");

                entity.Property(e => e.Upddate)
                    .HasColumnType("datetime")
                    .HasColumnName("upddate");

                entity.Property(e => e.Upduser)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("upduser")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

                entity.Property(e => e.Vdadi)
                    .HasMaxLength(31)
                    .IsUnicode(false)
                    .HasColumnName("vdadi")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

                entity.Property(e => e.Vdno)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("vdno")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

                entity.Property(e => e.Web)
                    .HasMaxLength(41)
                    .IsUnicode(false)
                    .HasColumnName("web")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");
            });

            modelBuilder.Entity<CariKullandiklariUrunler>(entity =>
            {
                entity.HasKey(e => e.Logref);

                entity.ToTable("cari_kullandiklari_urunler");

                entity.Property(e => e.Logref)
                    .ValueGeneratedNever()
                    .HasColumnName("logref");

                entity.Property(e => e.Aciklama)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("aciklama");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Birim)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("birim");

                entity.Property(e => e.Cariref).HasColumnName("cariref");

                entity.Property(e => e.Doviz)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("doviz");

                entity.Property(e => e.Fiyat).HasColumnName("fiyat");

                entity.Property(e => e.Grubu)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("grubu");

                entity.Property(e => e.Insdate)
                    .HasColumnType("datetime")
                    .HasColumnName("insdate");

                entity.Property(e => e.Insuser)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("insuser");

                entity.Property(e => e.Malzemeadi)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("malzemeadi");

                entity.Property(e => e.Malzemekodu)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("malzemekodu");

                entity.Property(e => e.Markaadi)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("markaadi");

                entity.Property(e => e.Mensei)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("mensei");

                entity.Property(e => e.Sec).HasColumnName("sec");

                entity.Property(e => e.Sekli)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("sekli");

                entity.Property(e => e.Sirano).HasColumnName("sirano");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.TuketimMiktari).HasColumnName("tuketim_miktari");

                entity.Property(e => e.Upddate)
                    .HasColumnType("datetime")
                    .HasColumnName("upddate");

                entity.Property(e => e.Upduser)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("upduser");
            });

            modelBuilder.Entity<Faaliyet>(entity =>
            {
                entity.HasKey(e => e.Logref);

                entity.ToTable("faaliyet");

                entity.Property(e => e.Logref)
                    .ValueGeneratedNever()
                    .HasColumnName("logref");

                entity.Property(e => e.Cariref).HasColumnName("cariref");

                entity.Property(e => e.Giren)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("giren");

                entity.Property(e => e.Grup1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("grup1");

                entity.Property(e => e.Grup2)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("grup2");

                entity.Property(e => e.Grup3)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("grup3");

                entity.Property(e => e.Grup4)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("grup4");

                entity.Property(e => e.Grup5)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("grup5");

                entity.Property(e => e.Insdate)
                    .HasColumnType("datetime")
                    .HasColumnName("insdate");

                entity.Property(e => e.Insuser)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("insuser");

                entity.Property(e => e.IslemSayisi).HasColumnName("islem_sayisi");

                entity.Property(e => e.Islemturu).HasColumnName("islemturu");

                entity.Property(e => e.Kisiref).HasColumnName("kisiref");

                entity.Property(e => e.Kisiref2).HasColumnName("kisiref2");

                entity.Property(e => e.Kisiref3).HasColumnName("kisiref3");

                entity.Property(e => e.Kisiref4).HasColumnName("kisiref4");

                entity.Property(e => e.Kisiref5).HasColumnName("kisiref5");

                entity.Property(e => e.Konu)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("konu");

                entity.Property(e => e.Malzemeref).HasColumnName("malzemeref");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Tarih)
                    .HasColumnType("datetime")
                    .HasColumnName("tarih");

                entity.Property(e => e.Upddate)
                    .HasColumnType("datetime")
                    .HasColumnName("upddate");

                entity.Property(e => e.Upduser)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("upduser");

                entity.Property(e => e.Yapilanlar)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("yapilanlar");
            });

            modelBuilder.Entity<Vazife>(entity =>
            {
                entity.HasKey(e => e.Logref);

                entity.ToTable("vazife");

                entity.Property(e => e.Logref)
                    .HasColumnName("logref");

                entity.Property(e => e.AtananKisi).HasColumnName("atanan_kisi");
                entity.Property(e => e.Baslik).HasColumnName("baslik");
                entity.Property(e => e.Aciklama).HasColumnName("aciklama");
                entity.Property(e => e.Oncelik).HasColumnName("oncelik");
                entity.Property(e => e.Yapildi).HasColumnName("yapildi");

                entity.Property(e => e.CariAdi).HasColumnName("cari_adi");
                entity.Property(e => e.CariRef).HasColumnName("cariref");
                entity.Property(e => e.KisiRef).HasColumnName("kisiref");
                entity.Property(e => e.VazifeTipi).HasColumnName("vazife_tipi");
                entity.Property(e => e.BaslangicTarihi).HasColumnName("baslangic_tarihi");
                entity.Property(e => e.BitirmeTarihi).HasColumnName("bitirme_tarihi");
                entity.Property(e => e.Arsiv).HasColumnName("arsiv");

                entity.Property(e => e.Insdate)
                    .HasColumnType("datetime")
                    .HasColumnName("insdate");

                entity.Property(e => e.Insuser)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("insuser");


                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.SonTarih)
                    .HasColumnType("datetime")
                    .HasColumnName("son_tarih");

                entity.Property(e => e.Upddate)
                    .HasColumnType("datetime")
                    .HasColumnName("upddate");

                entity.Property(e => e.Upduser)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("upduser");
            });

            modelBuilder.Entity<Takvim>(entity =>
            {
                entity.HasKey(e => e.Logref);

                entity.ToTable("takvim");

                entity.Property(e => e.Logref)
                    .HasColumnName("logref");

                entity.Property(e => e.CariRef).HasColumnName("cariref");
                entity.Property(e => e.VazifeRef).HasColumnName("vaziferef");
                entity.Property(e => e.KisiRef).HasColumnName("kisiref");

                entity.Property(e => e.Baslik)
                    .HasMaxLength(140)
                    .IsUnicode(false)
                    .HasColumnName("baslik");

                entity.Property(e => e.Aciklama)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("aciklama");

                entity.Property(e => e.Cari_Adi)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("cari_adi");

                entity.Property(e => e.Cari_Kodu)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("cari_kodu");

                entity.Property(e => e.Yapildi)
                    .HasColumnType("tinyint")
                    .HasColumnName("yapildi");

                entity.Property(e => e.Tarih)
                    .HasColumnType("datetime")
                    .HasColumnName("tarih");

                entity.Property(e => e.Insdate)
                    .HasColumnType("datetime")
                    .HasColumnName("insdate");

                entity.Property(e => e.Insuser)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("insuser");

                entity.Property(e => e.Status)
                .HasColumnType("tinyint")
                .HasColumnName("status");
            });

            modelBuilder.Entity<FiltreHar>(entity =>
            {
                entity.HasKey(e => e.Logref);

                entity.ToTable("filtre_har");

                entity.Property(e => e.Logref)
                    .ValueGeneratedNever()
                    .HasColumnName("logref");

                entity.Property(e => e.Aciklama)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("aciklama");

                entity.Property(e => e.Durum).HasColumnName("durum");

                entity.Property(e => e.Insdate)
                    .HasColumnType("datetime")
                    .HasColumnName("insdate");

                entity.Property(e => e.Insuser)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("insuser");

                entity.Property(e => e.LstokFiltreAdi)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("lstok_filtre_adi");

                entity.Property(e => e.LstokFiltreId).HasColumnName("lstok_filtre_id");

                entity.Property(e => e.LstokFiltreKodu)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("lstok_filtre_kodu");

                entity.Property(e => e.LstokMainAdi)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("lstok_main_adi");

                entity.Property(e => e.LstokMainId).HasColumnName("lstok_main_id");

                entity.Property(e => e.LstokMainKodu)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("lstok_main_kodu");

                entity.Property(e => e.MontajTarihi)
                    .HasColumnType("datetime")
                    .HasColumnName("montaj_tarihi");

                entity.Property(e => e.MontajYeri)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("montaj_yeri");

                entity.Property(e => e.Neden)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("neden");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Teklifdetayref).HasColumnName("teklifdetayref");

                entity.Property(e => e.Teklifref).HasColumnName("teklifref");

                entity.Property(e => e.TekrarlamaSekli)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("tekrarlama_sekli");

                entity.Property(e => e.TekrarlamaSuresi).HasColumnName("tekrarlama_suresi");

                entity.Property(e => e.Upddate)
                    .HasColumnType("datetime")
                    .HasColumnName("upddate");

                entity.Property(e => e.Upduser)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("upduser");
            });

            modelBuilder.Entity<FiltreHarDetay>(entity =>
            {
                entity.HasKey(e => e.Logref);

                entity.ToTable("filtre_har_detay");

                entity.Property(e => e.Logref)
                    .ValueGeneratedNever()
                    .HasColumnName("logref");

                entity.Property(e => e.Aciklama)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("aciklama");

                entity.Property(e => e.Durum).HasColumnName("durum");

                entity.Property(e => e.FiltreHarRef).HasColumnName("filtre_har_ref");

                entity.Property(e => e.Insdate)
                    .HasColumnType("datetime")
                    .HasColumnName("insdate");

                entity.Property(e => e.Insuser)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("insuser");

                entity.Property(e => e.LstokFiltreAdi)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("lstok_filtre_adi");

                entity.Property(e => e.LstokFiltreId).HasColumnName("lstok_filtre_id");

                entity.Property(e => e.LstokFiltreKodu)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("lstok_filtre_kodu");

                entity.Property(e => e.SevkTarihi)
                    .HasColumnType("datetime")
                    .HasColumnName("sevk_tarihi");

                entity.Property(e => e.Teklifdetayref).HasColumnName("teklifdetayref");

                entity.Property(e => e.Teklifref).HasColumnName("teklifref");

                entity.Property(e => e.Upddate)
                    .HasColumnType("datetime")
                    .HasColumnName("upddate");

                entity.Property(e => e.Upduser)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("upduser");

                entity.Property(e => e.YenilemeTarihi)
                    .HasColumnType("datetime")
                    .HasColumnName("yenileme_tarihi");
            });

            modelBuilder.Entity<FiltreSure>(entity =>
            {
                entity.HasKey(e => e.Logref);

                entity.ToTable("filtre_sure");

                entity.Property(e => e.Logref)
                    .ValueGeneratedNever()
                    .HasColumnName("logref");

                entity.Property(e => e.Aciklama)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("aciklama");

                entity.Property(e => e.Insdate)
                    .HasColumnType("datetime")
                    .HasColumnName("insdate");

                entity.Property(e => e.Insuser)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("insuser");

                entity.Property(e => e.LstokAdi)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("lstok_adi");

                entity.Property(e => e.LstokId).HasColumnName("lstok_id");

                entity.Property(e => e.LstokKodu)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("lstok_kodu");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.TekrarlamaSekli)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("tekrarlama_sekli");

                entity.Property(e => e.TekrarlamaSuresi).HasColumnName("tekrarlama_suresi");

                entity.Property(e => e.Upddate)
                    .HasColumnType("datetime")
                    .HasColumnName("upddate");

                entity.Property(e => e.Upduser)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("upduser");
            });

            modelBuilder.Entity<FiltreSureLog>(entity =>
            {
                entity.HasKey(e => e.Recref);

                entity.ToTable("filtre_sure_log");

                entity.Property(e => e.Recref).HasColumnName("recref");

                entity.Property(e => e.Aciklama)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("aciklama");

                entity.Property(e => e.Insdate)
                    .HasColumnType("datetime")
                    .HasColumnName("insdate");

                entity.Property(e => e.Insuser)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("insuser");

                entity.Property(e => e.Logref).HasColumnName("logref");

                entity.Property(e => e.LstokAdi)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("lstok_adi");

                entity.Property(e => e.LstokId).HasColumnName("lstok_id");

                entity.Property(e => e.LstokKodu)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("lstok_kodu");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.TekrarlamaSekli)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("tekrarlama_sekli");

                entity.Property(e => e.TekrarlamaSuresi).HasColumnName("tekrarlama_suresi");

                entity.Property(e => e.Upddate)
                    .HasColumnType("datetime")
                    .HasColumnName("upddate");

                entity.Property(e => e.Upduser)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("upduser");
            });

            modelBuilder.Entity<Gorev>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("gorev");

                entity.Property(e => e.Insdate)
                    .HasColumnType("datetime")
                    .HasColumnName("insdate");

                entity.Property(e => e.Konu)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("konu");

                entity.Property(e => e.KullaniciKodu)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("kullanici_kodu");

                entity.Property(e => e.Logref).HasColumnName("logref");

                entity.Property(e => e.Oncelik).HasColumnName("oncelik");

                entity.Property(e => e.Tablelogref).HasColumnName("tablelogref");

                entity.Property(e => e.Tablename)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tablename");

                entity.Property(e => e.Tarih)
                    .HasColumnType("datetime")
                    .HasColumnName("tarih");

                entity.Property(e => e.Teklifref).HasColumnName("teklifref");

                entity.Property(e => e.Upddate)
                    .HasColumnType("datetime")
                    .HasColumnName("upddate");

                entity.Property(e => e.Yapilacaklar)
                    .HasColumnType("text")
                    .HasColumnName("yapilacaklar");
            });

            modelBuilder.Entity<GorevUser>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("gorev_user");

                entity.Property(e => e.Durum).HasColumnName("durum");

                entity.Property(e => e.Faaliyet).HasColumnName("faaliyet");

                entity.Property(e => e.KullaniciKodu)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("kullanici_kodu");

                entity.Property(e => e.Logref).HasColumnName("logref");

                entity.Property(e => e.Okundu).HasColumnName("okundu");

                entity.Property(e => e.Parlogref).HasColumnName("parlogref");

                entity.Property(e => e.Tamamlama).HasColumnName("tamamlama");

                entity.Property(e => e.TamamlamaTarihi)
                    .HasColumnType("datetime")
                    .HasColumnName("tamamlama_tarihi");

                entity.Property(e => e.Upddate)
                    .HasColumnType("datetime")
                    .HasColumnName("upddate");

                entity.Property(e => e.Yapilanlar)
                    .HasColumnType("text")
                    .HasColumnName("yapilanlar");
            });

            modelBuilder.Entity<Kisiler>(entity =>
            {
                entity.HasKey(e => e.Logref);

                entity.ToTable("kisiler");

                entity.Property(e => e.Logref)
                    .ValueGeneratedNever()
                    .HasColumnName("logref");

                entity.Property(e => e.Aciklama)
                    .HasColumnType("text")
                    .HasColumnName("aciklama");

                entity.Property(e => e.Adi)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("adi");

                entity.Property(e => e.Adres)
                    .HasColumnType("text")
                    .HasColumnName("adres");

                entity.Property(e => e.Bolum)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("bolum");

                entity.Property(e => e.Cariadi)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cariadi");

                entity.Property(e => e.Cariref).HasColumnName("cariref");

                entity.Property(e => e.Ceptel)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("ceptel");

                entity.Property(e => e.Digtel)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("digtel");

                entity.Property(e => e.DogumTarihi)
                    .HasColumnType("datetime")
                    .HasColumnName("dogum_tarihi");

                entity.Property(e => e.Evtel)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("evtel");

                entity.Property(e => e.Faks)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("faks");

                entity.Property(e => e.Insdate)
                    .HasColumnType("datetime")
                    .HasColumnName("insdate");

                entity.Property(e => e.Insuser)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("insuser");

                entity.Property(e => e.Istel)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("istel");

                entity.Property(e => e.Mail)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("mail");

                entity.Property(e => e.Pozisyon)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("pozisyon");

                entity.Property(e => e.Soyadi)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("soyadi");

                entity.Property(e => e.Tamadi)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("tamadi");

                entity.Property(e => e.Upddate)
                    .HasColumnType("datetime")
                    .HasColumnName("upddate");

                entity.Property(e => e.Upduser)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("upduser");

                entity.Property(e => e.Varsayilan).HasColumnName("varsayilan");
            });

            modelBuilder.Entity<KullaniciTanimlari>(entity =>
            {
                entity.HasKey(e => e.Logref);

                entity.ToTable("kullanici_tanimlari");

                entity.Property(e => e.Logref)
                    .ValueGeneratedNever()
                    .HasColumnName("logref");

                entity.Property(e => e.Insdate)
                    .HasColumnType("datetime")
                    .HasColumnName("insdate");

                entity.Property(e => e.Insuser)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("insuser");

                entity.Property(e => e.KullaniciKodu)
                    .IsRequired()
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("kullanici_kodu");

                entity.Property(e => e.Modul).HasColumnName("modul");

                entity.Property(e => e.Plasiyerkodu)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("plasiyerkodu");

                entity.Property(e => e.Plasiyerref).HasColumnName("plasiyerref");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Teklifinsuserkodu)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("teklifinsuserkodu");

                entity.Property(e => e.Upddate)
                    .HasColumnType("datetime")
                    .HasColumnName("upddate");

                entity.Property(e => e.Upduser)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("upduser");
            });

            modelBuilder.Entity<MalzKalite>(entity =>
            {
                entity.HasKey(e => e.Logref);

                entity.ToTable("malz_kalite");

                entity.Property(e => e.Logref)
                    .ValueGeneratedNever()
                    .HasColumnName("logref");

                entity.Property(e => e.Acik)
                    .HasColumnType("text")
                    .HasColumnName("acik");

                entity.Property(e => e.AcikIng)
                    .HasColumnType("text")
                    .HasColumnName("acik_ing");

                entity.Property(e => e.Aciklama)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("aciklama");

                entity.Property(e => e.Insdate)
                    .HasColumnType("datetime")
                    .HasColumnName("insdate");

                entity.Property(e => e.Insuser)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("insuser");

                entity.Property(e => e.Malzemeref).HasColumnName("malzemeref");

                entity.Property(e => e.Metin)
                    .HasColumnType("text")
                    .HasColumnName("metin");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Teknik)
                    .HasColumnType("text")
                    .HasColumnName("teknik");

                entity.Property(e => e.TeknikIng)
                    .HasColumnType("text")
                    .HasColumnName("teknik_ing");

                entity.Property(e => e.Tip)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("tip");

                entity.Property(e => e.Upddate)
                    .HasColumnType("datetime")
                    .HasColumnName("upddate");

                entity.Property(e => e.Upduser)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("upduser");
            });

            modelBuilder.Entity<MalzKaliteLog>(entity =>
            {
                entity.HasKey(e => e.Recref);

                entity.ToTable("malz_kalite_log");

                entity.Property(e => e.Recref).HasColumnName("recref");

                entity.Property(e => e.Acik)
                    .HasColumnType("text")
                    .HasColumnName("acik");

                entity.Property(e => e.AcikIng)
                    .HasColumnType("text")
                    .HasColumnName("acik_ing");

                entity.Property(e => e.Aciklama)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("aciklama");

                entity.Property(e => e.Insdate)
                    .HasColumnType("datetime")
                    .HasColumnName("insdate");

                entity.Property(e => e.Insuser)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("insuser");

                entity.Property(e => e.Logref).HasColumnName("logref");

                entity.Property(e => e.Malzemeref).HasColumnName("malzemeref");

                entity.Property(e => e.Metin)
                    .HasColumnType("text")
                    .HasColumnName("metin");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Teknik)
                    .HasColumnType("text")
                    .HasColumnName("teknik");

                entity.Property(e => e.TeknikIng)
                    .HasColumnType("text")
                    .HasColumnName("teknik_ing");

                entity.Property(e => e.Tip)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("tip");

                entity.Property(e => e.Upddate)
                    .HasColumnType("datetime")
                    .HasColumnName("upddate");

                entity.Property(e => e.Upduser)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("upduser");
            });

            modelBuilder.Entity<MalzKart>(entity =>
            {
                entity.HasKey(e => e.Logref)
                    .HasName("pk_malz_kart");

                entity.ToTable("malz_kart");

                entity.Property(e => e.Logref)
                    .ValueGeneratedNever()
                    .HasColumnName("logref");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Adi)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("adi");

                entity.Property(e => e.Adi3)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("adi3");

                entity.Property(e => e.Alfiyat).HasColumnName("alfiyat");

                entity.Property(e => e.AlfiyatDov)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("alfiyat_dov");

                entity.Property(e => e.Birim)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("birim");

                entity.Property(e => e.Birimset)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("birimset");

                entity.Property(e => e.Boy).HasColumnName("boy");

                entity.Property(e => e.En).HasColumnName("en");

                entity.Property(e => e.Grupkodu)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("grupkodu");

                entity.Property(e => e.Hacim).HasColumnName("hacim");

                entity.Property(e => e.Insdate)
                    .HasColumnType("datetime")
                    .HasColumnName("insdate");

                entity.Property(e => e.Insuser)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("insuser");

                entity.Property(e => e.Kdv).HasColumnName("kdv");

                entity.Property(e => e.Kodu)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("kodu");

                entity.Property(e => e.Logokodu)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("logokodu");

                entity.Property(e => e.Logoref).HasColumnName("logoref");

                entity.Property(e => e.Marka)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("marka");

                entity.Property(e => e.Mensei)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("mensei");

                entity.Property(e => e.Ozelkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ozelkod");

                entity.Property(e => e.Ozelkod2)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ozelkod2");

                entity.Property(e => e.Ozelkod3)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ozelkod3");

                entity.Property(e => e.Ozelkod4)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ozelkod4");

                entity.Property(e => e.Satfiyat).HasColumnName("satfiyat");

                entity.Property(e => e.SatfiyatDov)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("satfiyat_dov");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Unitsetllogref).HasColumnName("unitsetllogref");

                entity.Property(e => e.Unitsetref).HasColumnName("unitsetref");

                entity.Property(e => e.Upddate)
                    .HasColumnType("datetime")
                    .HasColumnName("upddate");

                entity.Property(e => e.Upduser)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("upduser");

                entity.Property(e => e.Yukseklik).HasColumnName("yukseklik");

                entity.Property(e => e.TedarikciAdi)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("tedarikciadi");
            });

            modelBuilder.Entity<MalzKartLog>(entity =>
            {
                entity.HasKey(e => e.Recref)
                    .HasName("pk_malz_kart_log");

                entity.ToTable("malz_kart_log");

                entity.Property(e => e.Recref).HasColumnName("recref");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Adi)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("adi");

                entity.Property(e => e.Adi3)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("adi3");

                entity.Property(e => e.Alfiyat).HasColumnName("alfiyat");

                entity.Property(e => e.AlfiyatDov)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("alfiyat_dov");

                entity.Property(e => e.Birim)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("birim");

                entity.Property(e => e.Birimset)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("birimset");

                entity.Property(e => e.Boy).HasColumnName("boy");

                entity.Property(e => e.En).HasColumnName("en");

                entity.Property(e => e.Grupkodu)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("grupkodu");

                entity.Property(e => e.Hacim).HasColumnName("hacim");

                entity.Property(e => e.Insdate)
                    .HasColumnType("datetime")
                    .HasColumnName("insdate");

                entity.Property(e => e.Insuser)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("insuser");

                entity.Property(e => e.Kdv).HasColumnName("kdv");

                entity.Property(e => e.Kodu)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("kodu");

                entity.Property(e => e.Logokodu)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("logokodu");

                entity.Property(e => e.Logoref).HasColumnName("logoref");

                entity.Property(e => e.Logref).HasColumnName("logref");

                entity.Property(e => e.Marka)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("marka");

                entity.Property(e => e.Mensei)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("mensei");

                entity.Property(e => e.Ozelkod)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ozelkod");

                entity.Property(e => e.Ozelkod2)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ozelkod2");

                entity.Property(e => e.Ozelkod3)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ozelkod3");

                entity.Property(e => e.Ozelkod4)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ozelkod4");

                entity.Property(e => e.Satfiyat).HasColumnName("satfiyat");

                entity.Property(e => e.SatfiyatDov)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("satfiyat_dov");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Unitsetllogref).HasColumnName("unitsetllogref");

                entity.Property(e => e.Unitsetref).HasColumnName("unitsetref");

                entity.Property(e => e.Upddate)
                    .HasColumnType("datetime")
                    .HasColumnName("upddate");

                entity.Property(e => e.Upduser)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("upduser");

                entity.Property(e => e.Yukseklik).HasColumnName("yukseklik");

                entity.Property(e => e.TedarikciAdi)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("tedarikciadi");
            });

            modelBuilder.Entity<Refno>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("refno");

                entity.Property(e => e.Increment).HasColumnName("increment");

                entity.Property(e => e.Lastrefno).HasColumnName("lastrefno");

                entity.Property(e => e.Tablename)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tablename");
            });

            modelBuilder.Entity<Servi>(entity =>
            {
                entity.HasKey(e => e.Logref);

                entity.ToTable("servis");

                entity.Property(e => e.Logref)
                    .ValueGeneratedNever()
                    .HasColumnName("logref");

                entity.Property(e => e.Bastarih)
                    .HasColumnType("datetime")
                    .HasColumnName("bastarih");

                entity.Property(e => e.BayiIlgiliKisi)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("bayi_ilgili_kisi");

                entity.Property(e => e.BayiIlgiliTel)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("bayi_ilgili_tel");

                entity.Property(e => e.Bayiref).HasColumnName("bayiref");

                entity.Property(e => e.BildirimTarihi)
                    .HasColumnType("datetime")
                    .HasColumnName("bildirim_tarihi");

                entity.Property(e => e.Bittarih)
                    .HasColumnType("datetime")
                    .HasColumnName("bittarih");

                entity.Property(e => e.Cariref).HasColumnName("cariref");

                entity.Property(e => e.Durum)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("durum");

                entity.Property(e => e.Evrakno)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("evrakno");

                entity.Property(e => e.Fisno)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("fisno");

                entity.Property(e => e.Garanti).HasColumnName("garanti");

                entity.Property(e => e.IlgiliKisi)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ilgili_kisi");

                entity.Property(e => e.IlgiliTel)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ilgili_tel");

                entity.Property(e => e.Insdate)
                    .HasColumnType("datetime")
                    .HasColumnName("insdate");

                entity.Property(e => e.Insuser)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("insuser");

                entity.Property(e => e.IsTanimi)
                    .HasColumnType("text")
                    .HasColumnName("is_tanimi");

                entity.Property(e => e.IslemAdresi)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("islem_adresi");

                entity.Property(e => e.IslemBolge)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("islem_bolge");

                entity.Property(e => e.IslemIlce)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("islem_ilce");

                entity.Property(e => e.IslemSehir)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("islem_sehir");

                entity.Property(e => e.IslemSehirRef).HasColumnName("islem_sehir_ref");

                entity.Property(e => e.Istipi)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("istipi");

                entity.Property(e => e.Karaliste).HasColumnName("karaliste");

                entity.Property(e => e.KimYonlendirdi)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("kim_yonlendirdi");

                entity.Property(e => e.LbayiAdi)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("lbayi_adi");

                entity.Property(e => e.LbayiKodu)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("lbayi_kodu");

                entity.Property(e => e.LcariAdi)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("lcari_adi");

                entity.Property(e => e.LcariKodu)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("lcari_kodu");

                entity.Property(e => e.LtservisAdi)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("ltservis_adi");

                entity.Property(e => e.LtservisKodu)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("ltservis_kodu");

                entity.Property(e => e.Mailbayi).HasColumnName("mailbayi");

                entity.Property(e => e.Mailbayitar).HasColumnName("mailbayitar");

                entity.Property(e => e.Mailmusteri).HasColumnName("mailmusteri");

                entity.Property(e => e.Mailmusteritar)
                    .HasColumnType("datetime")
                    .HasColumnName("mailmusteritar");

                entity.Property(e => e.Mailservis).HasColumnName("mailservis");

                entity.Property(e => e.Mailservistar)
                    .HasColumnType("datetime")
                    .HasColumnName("mailservistar");

                entity.Property(e => e.Not1)
                    .HasColumnType("text")
                    .HasColumnName("not1");

                entity.Property(e => e.Orderref)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("orderref");

                entity.Property(e => e.Serinovar).HasColumnName("serinovar");

                entity.Property(e => e.ServisIlgiliKisi)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("servis_ilgili_kisi");

                entity.Property(e => e.ServisIlgiliTel)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("servis_ilgili_tel");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Tarih)
                    .HasColumnType("datetime")
                    .HasColumnName("tarih");

                entity.Property(e => e.Toptutar).HasColumnName("toptutar");

                entity.Property(e => e.Tservisref).HasColumnName("tservisref");

                entity.Property(e => e.Upddate)
                    .HasColumnType("datetime")
                    .HasColumnName("upddate");

                entity.Property(e => e.Upduser)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("upduser");

                entity.Property(e => e.Yapilanlar)
                    .HasColumnType("text")
                    .HasColumnName("yapilanlar");

                entity.Property(e => e.Yil).HasColumnName("yil");

                entity.Property(e => e.Yonlendirenkisi)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("yonlendirenkisi");
            });

            modelBuilder.Entity<ServisEskiler>(entity =>
            {
                entity.HasKey(e => e.Logref);

                entity.ToTable("servis_eskiler");

                entity.Property(e => e.Logref).HasColumnName("logref");

                entity.Property(e => e.Aciklama)
                    .HasColumnType("ntext")
                    .HasColumnName("aciklama");

                entity.Property(e => e.Bolgeadi)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("bolgeadi");

                entity.Property(e => e.Ektra).HasColumnName("ektra");

                entity.Property(e => e.Fisno)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("fisno");

                entity.Property(e => e.Iladi)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("iladi");

                entity.Property(e => e.Islemtarihi)
                    .HasColumnType("datetime")
                    .HasColumnName("islemtarihi");

                entity.Property(e => e.Istipi)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("istipi");

                entity.Property(e => e.Km).HasColumnName("km");

                entity.Property(e => e.Kmtl).HasColumnName("kmtl");

                entity.Property(e => e.Marka)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("marka");

                entity.Property(e => e.Model)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("model");

                entity.Property(e => e.Montajtarihi)
                    .HasColumnType("datetime")
                    .HasColumnName("montajtarihi");

                entity.Property(e => e.Musteriadi)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("musteriadi");

                entity.Property(e => e.Ozelnot)
                    .HasColumnType("ntext")
                    .HasColumnName("ozelnot");

                entity.Property(e => e.Serino)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("serino");

                entity.Property(e => e.Servisadi)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("servisadi");

                entity.Property(e => e.Servisno)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("servisno");

                entity.Property(e => e.Tabelaadi)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("tabelaadi");

                entity.Property(e => e.Toplambedel).HasColumnName("toplambedel");

                entity.Property(e => e.Ucret).HasColumnName("ucret");

                entity.Property(e => e.Yil).HasColumnName("yil");

                entity.Property(e => e.Yolmasrafi).HasColumnName("yolmasrafi");
            });

            modelBuilder.Entity<ServisHakedi>(entity =>
            {
                entity.HasKey(e => e.Logref);

                entity.ToTable("servis_hakedis");

                entity.Property(e => e.Logref)
                    .ValueGeneratedNever()
                    .HasColumnName("logref");

                entity.Property(e => e.Fatno)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("fatno");

                entity.Property(e => e.Fattar)
                    .HasColumnType("datetime")
                    .HasColumnName("fattar");

                entity.Property(e => e.Hno)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("hno");

                entity.Property(e => e.Insdate)
                    .HasColumnType("datetime")
                    .HasColumnName("insdate");

                entity.Property(e => e.Insuser)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("insuser");

                entity.Property(e => e.Mailgittimi).HasColumnName("mailgittimi");

                entity.Property(e => e.Mailtar)
                    .HasColumnType("datetime")
                    .HasColumnName("mailtar");

                entity.Property(e => e.Odemedurumu)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("odemedurumu");

                entity.Property(e => e.Servisref).HasColumnName("servisref");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Tarih)
                    .HasColumnType("datetime")
                    .HasColumnName("tarih");

                entity.Property(e => e.Tutar).HasColumnName("tutar");

                entity.Property(e => e.Upddate)
                    .HasColumnType("datetime")
                    .HasColumnName("upddate");

                entity.Property(e => e.Upduser)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("upduser");
            });

            modelBuilder.Entity<ServisHakedisLog>(entity =>
            {
                entity.HasKey(e => e.Recref);

                entity.ToTable("servis_hakedis_log");

                entity.Property(e => e.Recref).HasColumnName("recref");

                entity.Property(e => e.Fatno)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("fatno");

                entity.Property(e => e.Fattar)
                    .HasColumnType("datetime")
                    .HasColumnName("fattar");

                entity.Property(e => e.Hno)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("hno");

                entity.Property(e => e.Insdate)
                    .HasColumnType("datetime")
                    .HasColumnName("insdate");

                entity.Property(e => e.Insuser)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("insuser");

                entity.Property(e => e.Logref).HasColumnName("logref");

                entity.Property(e => e.Mailgittimi).HasColumnName("mailgittimi");

                entity.Property(e => e.Mailtar)
                    .HasColumnType("datetime")
                    .HasColumnName("mailtar");

                entity.Property(e => e.Odemedurumu)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("odemedurumu");

                entity.Property(e => e.Servisref).HasColumnName("servisref");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Tarih)
                    .HasColumnType("datetime")
                    .HasColumnName("tarih");

                entity.Property(e => e.Tutar).HasColumnName("tutar");

                entity.Property(e => e.Upddate)
                    .HasColumnType("datetime")
                    .HasColumnName("upddate");

                entity.Property(e => e.Upduser)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("upduser");
            });

            modelBuilder.Entity<ServisLog>(entity =>
            {
                entity.HasKey(e => e.Recref);

                entity.ToTable("servis_log");

                entity.Property(e => e.Recref).HasColumnName("recref");

                entity.Property(e => e.Bastarih)
                    .HasColumnType("datetime")
                    .HasColumnName("bastarih");

                entity.Property(e => e.BayiIlgiliKisi)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("bayi_ilgili_kisi");

                entity.Property(e => e.BayiIlgiliTel)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("bayi_ilgili_tel");

                entity.Property(e => e.Bayiref).HasColumnName("bayiref");

                entity.Property(e => e.BildirimTarihi)
                    .HasColumnType("datetime")
                    .HasColumnName("bildirim_tarihi");

                entity.Property(e => e.Bittarih)
                    .HasColumnType("datetime")
                    .HasColumnName("bittarih");

                entity.Property(e => e.Cariref).HasColumnName("cariref");

                entity.Property(e => e.Durum)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("durum");

                entity.Property(e => e.Evrakno)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("evrakno");

                entity.Property(e => e.Fisno)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("fisno");

                entity.Property(e => e.Garanti).HasColumnName("garanti");

                entity.Property(e => e.IlgiliKisi)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ilgili_kisi");

                entity.Property(e => e.IlgiliTel)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ilgili_tel");

                entity.Property(e => e.Insdate)
                    .HasColumnType("datetime")
                    .HasColumnName("insdate");

                entity.Property(e => e.Insuser)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("insuser");

                entity.Property(e => e.IsTanimi)
                    .HasColumnType("text")
                    .HasColumnName("is_tanimi");

                entity.Property(e => e.IslemAdresi)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("islem_adresi");

                entity.Property(e => e.IslemBolge)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("islem_bolge");

                entity.Property(e => e.IslemIlce)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("islem_ilce");

                entity.Property(e => e.IslemSehir)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("islem_sehir");

                entity.Property(e => e.IslemSehirRef).HasColumnName("islem_sehir_ref");

                entity.Property(e => e.Istipi)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("istipi");

                entity.Property(e => e.Karaliste).HasColumnName("karaliste");

                entity.Property(e => e.KimYonlendirdi)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("kim_yonlendirdi");

                entity.Property(e => e.LbayiAdi)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("lbayi_adi");

                entity.Property(e => e.LbayiKodu)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("lbayi_kodu");

                entity.Property(e => e.LcariAdi)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("lcari_adi");

                entity.Property(e => e.LcariKodu)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("lcari_kodu");

                entity.Property(e => e.Logref).HasColumnName("logref");

                entity.Property(e => e.LtservisAdi)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("ltservis_adi");

                entity.Property(e => e.LtservisKodu)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("ltservis_kodu");

                entity.Property(e => e.Mailbayi).HasColumnName("mailbayi");

                entity.Property(e => e.Mailbayitar).HasColumnName("mailbayitar");

                entity.Property(e => e.Mailmusteri).HasColumnName("mailmusteri");

                entity.Property(e => e.Mailmusteritar)
                    .HasColumnType("datetime")
                    .HasColumnName("mailmusteritar");

                entity.Property(e => e.Mailservis).HasColumnName("mailservis");

                entity.Property(e => e.Mailservistar)
                    .HasColumnType("datetime")
                    .HasColumnName("mailservistar");

                entity.Property(e => e.Not1)
                    .HasColumnType("text")
                    .HasColumnName("not1");

                entity.Property(e => e.Orderref)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("orderref");

                entity.Property(e => e.Serinovar).HasColumnName("serinovar");

                entity.Property(e => e.ServisIlgiliKisi)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("servis_ilgili_kisi");

                entity.Property(e => e.ServisIlgiliTel)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("servis_ilgili_tel");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Tarih)
                    .HasColumnType("datetime")
                    .HasColumnName("tarih");

                entity.Property(e => e.Toptutar).HasColumnName("toptutar");

                entity.Property(e => e.Tservisref).HasColumnName("tservisref");

                entity.Property(e => e.Upddate)
                    .HasColumnType("datetime")
                    .HasColumnName("upddate");

                entity.Property(e => e.Upduser)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("upduser");

                entity.Property(e => e.Yapilanlar)
                    .HasColumnType("text")
                    .HasColumnName("yapilanlar");

                entity.Property(e => e.Yil).HasColumnName("yil");

                entity.Property(e => e.Yonlendirenkisi)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("yonlendirenkisi");
            });

            modelBuilder.Entity<ServisMalzemeler>(entity =>
            {
                entity.HasKey(e => e.Logref);

                entity.ToTable("servis_malzemeler");

                entity.Property(e => e.Logref)
                    .ValueGeneratedNever()
                    .HasColumnName("logref");

                entity.Property(e => e.Aciklama)
                    .HasColumnType("text")
                    .HasColumnName("aciklama");

                entity.Property(e => e.Birim)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("birim");

                entity.Property(e => e.Durum)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("durum");

                entity.Property(e => e.Fiyat).HasColumnName("fiyat");

                entity.Property(e => e.Garanti).HasColumnName("garanti");

                entity.Property(e => e.Insdate)
                    .HasColumnType("datetime")
                    .HasColumnName("insdate");

                entity.Property(e => e.Insuser)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("insuser");

                entity.Property(e => e.LstokAdi)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("lstok_adi");

                entity.Property(e => e.LstokKodu)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("lstok_kodu");

                entity.Property(e => e.Miktar).HasColumnName("miktar");

                entity.Property(e => e.Serino)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("serino");

                entity.Property(e => e.Servisref).HasColumnName("servisref");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Stokref).HasColumnName("stokref");

                entity.Property(e => e.Tur)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("tur");

                entity.Property(e => e.Tutar).HasColumnName("tutar");

                entity.Property(e => e.Upddate)
                    .HasColumnType("datetime")
                    .HasColumnName("upddate");

                entity.Property(e => e.Upduser)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("upduser");
            });

            modelBuilder.Entity<ServisMalzemelerLog>(entity =>
            {
                entity.HasKey(e => e.Recref);

                entity.ToTable("servis_malzemeler_log");

                entity.Property(e => e.Recref).HasColumnName("recref");

                entity.Property(e => e.Aciklama)
                    .HasColumnType("text")
                    .HasColumnName("aciklama");

                entity.Property(e => e.Birim)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("birim");

                entity.Property(e => e.Durum)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("durum");

                entity.Property(e => e.Fiyat).HasColumnName("fiyat");

                entity.Property(e => e.Garanti).HasColumnName("garanti");

                entity.Property(e => e.Insdate)
                    .HasColumnType("datetime")
                    .HasColumnName("insdate");

                entity.Property(e => e.Insuser)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("insuser");

                entity.Property(e => e.Logref).HasColumnName("logref");

                entity.Property(e => e.LstokAdi)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("lstok_adi");

                entity.Property(e => e.LstokKodu)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("lstok_kodu");

                entity.Property(e => e.Miktar).HasColumnName("miktar");

                entity.Property(e => e.Serino)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("serino");

                entity.Property(e => e.Servisref).HasColumnName("servisref");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Stokref).HasColumnName("stokref");

                entity.Property(e => e.Tur)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("tur");

                entity.Property(e => e.Tutar).HasColumnName("tutar");

                entity.Property(e => e.Upddate)
                    .HasColumnType("datetime")
                    .HasColumnName("upddate");

                entity.Property(e => e.Upduser)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("upduser");
            });

            modelBuilder.Entity<Teklif>(entity =>
            {
                entity.HasKey(e => e.Logref);

                entity.ToTable("teklif");

                entity.Property(e => e.Logref)
                    .ValueGeneratedNever()
                    .HasColumnName("logref");

                entity.Property(e => e.Aciklama1)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("aciklama1");

                entity.Property(e => e.Aciklama2)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("aciklama2");

                entity.Property(e => e.Aciklama3)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("aciklama3");

                entity.Property(e => e.Aciklama4)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("aciklama4");

                entity.Property(e => e.Cariref).HasColumnName("cariref");

                entity.Property(e => e.Carisevkadrref).HasColumnName("carisevkadrref");

                entity.Property(e => e.Caritip).HasColumnName("caritip");

                entity.Property(e => e.Dovizkuru).HasColumnName("dovizkuru");

                entity.Property(e => e.Dovizkuruid).HasColumnName("dovizkuruid");

                entity.Property(e => e.Dovizref).HasColumnName("dovizref");

                entity.Property(e => e.Dovizrefid).HasColumnName("dovizrefid");

                entity.Property(e => e.Duruminfo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("duruminfo");

                entity.Property(e => e.Gniskoran).HasColumnName("gniskoran");

                entity.Property(e => e.Gnisktutar).HasColumnName("gnisktutar");

                entity.Property(e => e.Gnistip).HasColumnName("gnistip");

                entity.Property(e => e.IlgiliAdi)
                    .HasMaxLength(51)
                    .IsUnicode(false)
                    .HasColumnName("ilgili_adi");

                entity.Property(e => e.Insdate)
                    .HasColumnType("datetime")
                    .HasColumnName("insdate");

                entity.Property(e => e.Insuser)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("insuser");

                entity.Property(e => e.LcariAdi)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("lcari_adi");

                entity.Property(e => e.LcariKodu)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("lcari_kodu");

                entity.Property(e => e.LcariSevkadrKodu)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("lcari_sevkadr_kodu");

                entity.Property(e => e.Ldonem)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("ldonem")
                    .IsFixedLength(true);

                entity.Property(e => e.Lfirma)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("lfirma")
                    .IsFixedLength(true);

                entity.Property(e => e.LodemePlani).HasColumnName("lodeme_plani");

                entity.Property(e => e.LodemePlaniKodu)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("lodeme_plani_kodu");

                entity.Property(e => e.Logoentegre)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("logoentegre");

                entity.Property(e => e.Logosipref).HasColumnName("logosipref");

                entity.Property(e => e.Logotar)
                    .HasColumnType("datetime")
                    .HasColumnName("logotar");

                entity.Property(e => e.Lpersoneladi)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("lpersoneladi");

                entity.Property(e => e.Lpersonelref).HasColumnName("lpersonelref");

                entity.Property(e => e.Notlar)
                    .HasColumnType("text")
                    .HasColumnName("notlar");

                entity.Property(e => e.Proje)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("proje");

                entity.Property(e => e.Revizyon).HasColumnName("revizyon");

                entity.Property(e => e.Revzno)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("revzno");

                entity.Property(e => e.Saat)
                    .HasColumnType("datetime")
                    .HasColumnName("saat");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Tarih)
                    .HasColumnType("datetime")
                    .HasColumnName("tarih");

                entity.Property(e => e.Tbelgeno)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("tbelgeno");

                entity.Property(e => e.Teklifno)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("teklifno");

                entity.Property(e => e.TeslimSekli)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("teslim_sekli");

                entity.Property(e => e.TeslimTarihi)
                    .HasColumnType("datetime")
                    .HasColumnName("teslim_tarihi");

                entity.Property(e => e.Trcode).HasColumnName("trcode");

                entity.Property(e => e.Tutar).HasColumnName("tutar");

                entity.Property(e => e.Tutarmatrah).HasColumnName("tutarmatrah");

                entity.Property(e => e.Tutarmatrahrd).HasColumnName("tutarmatrahrd");

                entity.Property(e => e.Tutarmatrahtl).HasColumnName("tutarmatrahtl");

                entity.Property(e => e.Tutarrd).HasColumnName("tutarrd");

                entity.Property(e => e.Tutartl).HasColumnName("tutartl");

                entity.Property(e => e.Upddate)
                    .HasColumnType("datetime")
                    .HasColumnName("upddate");

                entity.Property(e => e.Upduser)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("upduser");
            });

            modelBuilder.Entity<TeklifDosya>(entity =>
            {
                entity.HasKey(e => e.Logref);

                entity.ToTable("teklif_dosya");

                entity.Property(e => e.Logref)
                    .ValueGeneratedNever()
                    .HasColumnName("logref");

                entity.Property(e => e.Aciklama)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("aciklama");

                entity.Property(e => e.Grup)
                    .HasMaxLength(51)
                    .IsUnicode(false)
                    .HasColumnName("grup");

                entity.Property(e => e.Idata)
                    .HasColumnType("image")
                    .HasColumnName("idata");

                entity.Property(e => e.Ifiledate)
                    .HasColumnType("datetime")
                    .HasColumnName("ifiledate");

                entity.Property(e => e.Ifilename)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("ifilename");

                entity.Property(e => e.Ifilepath)
                    .HasColumnType("text")
                    .HasColumnName("ifilepath");

                entity.Property(e => e.Ifilesizekb).HasColumnName("ifilesizekb");

                entity.Property(e => e.Ifilesizekbzip).HasColumnName("ifilesizekbzip");

                entity.Property(e => e.Insdate)
                    .HasColumnType("datetime")
                    .HasColumnName("insdate");

                entity.Property(e => e.Insuser)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("insuser");

                entity.Property(e => e.Itype)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("itype");

                entity.Property(e => e.Parlogref).HasColumnName("parlogref");

                entity.Property(e => e.TeklifRotaLogref).HasColumnName("teklif_rota_logref");

                entity.Property(e => e.Upddate)
                    .HasColumnType("datetime")
                    .HasColumnName("upddate");

                entity.Property(e => e.Upduser)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("upduser");
            });

            modelBuilder.Entity<TeklifDosyaPath>(entity =>
            {
                entity.HasKey(e => e.Logref);

                entity.ToTable("teklif_dosya_path");

                entity.Property(e => e.Logref)
                    .ValueGeneratedNever()
                    .HasColumnName("logref");

                entity.Property(e => e.Aciklama)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("aciklama");

                entity.Property(e => e.Filename)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("filename");

                entity.Property(e => e.Grup)
                    .HasMaxLength(51)
                    .IsUnicode(false)
                    .HasColumnName("grup");

                entity.Property(e => e.Insdate)
                    .HasColumnType("datetime")
                    .HasColumnName("insdate");

                entity.Property(e => e.Insuser)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("insuser");

                entity.Property(e => e.Parlogref).HasColumnName("parlogref");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.TeklifRotaLogref).HasColumnName("teklif_rota_logref");

                entity.Property(e => e.Upddate)
                    .HasColumnType("datetime")
                    .HasColumnName("upddate");

                entity.Property(e => e.Upduser)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("upduser");
            });

            modelBuilder.Entity<TeklifDosyaPathLog>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("teklif_dosya_path_log");

                entity.Property(e => e.Aciklama)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("aciklama");

                entity.Property(e => e.Filename)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("filename");

                entity.Property(e => e.Grup)
                    .HasMaxLength(51)
                    .IsUnicode(false)
                    .HasColumnName("grup");

                entity.Property(e => e.Insdate)
                    .HasColumnType("datetime")
                    .HasColumnName("insdate");

                entity.Property(e => e.Insuser)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("insuser");

                entity.Property(e => e.Logref).HasColumnName("logref");

                entity.Property(e => e.Parlogref).HasColumnName("parlogref");

                entity.Property(e => e.Recref)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("recref");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.TeklifRotaLogref).HasColumnName("teklif_rota_logref");

                entity.Property(e => e.Upddate)
                    .HasColumnType("datetime")
                    .HasColumnName("upddate");

                entity.Property(e => e.Upduser)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("upduser");
            });

            modelBuilder.Entity<TeklifDurumDetay>(entity =>
            {
                entity.HasKey(e => e.Refid);

                entity.ToTable("teklif_durum_detay");

                entity.Property(e => e.Refid).HasColumnName("refid");

                entity.Property(e => e.Aciklama)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("aciklama");

                entity.Property(e => e.Duruminfo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("duruminfo");

                entity.Property(e => e.KullaniciKodu)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("kullanici_kodu");

                entity.Property(e => e.Tarih)
                    .HasColumnType("datetime")
                    .HasColumnName("tarih");

                entity.Property(e => e.Teklifref).HasColumnName("teklifref");
            });

            modelBuilder.Entity<TeklifFinansOnay>(entity =>
            {
                entity.HasKey(e => e.Logref);

                entity.ToTable("teklif_finans_onay");

                entity.Property(e => e.Logref)
                    .ValueGeneratedNever()
                    .HasColumnName("logref");

                entity.Property(e => e.Bas).HasColumnName("bas");

                entity.Property(e => e.Bit).HasColumnName("bit");

                entity.Property(e => e.Insdate)
                    .HasColumnType("datetime")
                    .HasColumnName("insdate");

                entity.Property(e => e.Insuser)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("insuser");

                entity.Property(e => e.Onay1)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("onay1");

                entity.Property(e => e.Onay2)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("onay2");

                entity.Property(e => e.Onay3)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("onay3");

                entity.Property(e => e.Upddate)
                    .HasColumnType("datetime")
                    .HasColumnName("upddate");

                entity.Property(e => e.Upduser)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("upduser");
            });

            modelBuilder.Entity<TeklifFinansOnayLog>(entity =>
            {
                entity.HasKey(e => e.Recref);

                entity.ToTable("teklif_finans_onay_log");

                entity.Property(e => e.Recref).HasColumnName("recref");

                entity.Property(e => e.Bas).HasColumnName("bas");

                entity.Property(e => e.Bit).HasColumnName("bit");

                entity.Property(e => e.Insdate)
                    .HasColumnType("datetime")
                    .HasColumnName("insdate");

                entity.Property(e => e.Insuser)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("insuser");

                entity.Property(e => e.Logref).HasColumnName("logref");

                entity.Property(e => e.Onay1)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("onay1");

                entity.Property(e => e.Onay2)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("onay2");

                entity.Property(e => e.Onay3)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("onay3");

                entity.Property(e => e.Upddate)
                    .HasColumnType("datetime")
                    .HasColumnName("upddate");

                entity.Property(e => e.Upduser)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("upduser");
            });

            modelBuilder.Entity<TeklifLog>(entity =>
            {
                entity.HasKey(e => e.Recref);

                entity.ToTable("teklif_log");

                entity.Property(e => e.Recref).HasColumnName("recref");

                entity.Property(e => e.Aciklama1)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("aciklama1");

                entity.Property(e => e.Aciklama2)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("aciklama2");

                entity.Property(e => e.Aciklama3)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("aciklama3");

                entity.Property(e => e.Aciklama4)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("aciklama4");

                entity.Property(e => e.Cariref).HasColumnName("cariref");

                entity.Property(e => e.Carisevkadrref).HasColumnName("carisevkadrref");

                entity.Property(e => e.Caritip).HasColumnName("caritip");

                entity.Property(e => e.Dovizkuru).HasColumnName("dovizkuru");

                entity.Property(e => e.Dovizkuruid).HasColumnName("dovizkuruid");

                entity.Property(e => e.Dovizref).HasColumnName("dovizref");

                entity.Property(e => e.Dovizrefid).HasColumnName("dovizrefid");

                entity.Property(e => e.Duruminfo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("duruminfo");

                entity.Property(e => e.Gniskoran).HasColumnName("gniskoran");

                entity.Property(e => e.Gnisktutar).HasColumnName("gnisktutar");

                entity.Property(e => e.Gnistip).HasColumnName("gnistip");

                entity.Property(e => e.IlgiliAdi)
                    .HasMaxLength(51)
                    .IsUnicode(false)
                    .HasColumnName("ilgili_adi");

                entity.Property(e => e.Insdate)
                    .HasColumnType("datetime")
                    .HasColumnName("insdate");

                entity.Property(e => e.Insuser)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("insuser");

                entity.Property(e => e.LcariAdi)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("lcari_adi");

                entity.Property(e => e.LcariKodu)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("lcari_kodu");

                entity.Property(e => e.LcariSevkadrKodu)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("lcari_sevkadr_kodu");

                entity.Property(e => e.Ldonem)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("ldonem")
                    .IsFixedLength(true);

                entity.Property(e => e.Lfirma)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("lfirma")
                    .IsFixedLength(true);

                entity.Property(e => e.LodemePlani).HasColumnName("lodeme_plani");

                entity.Property(e => e.LodemePlaniKodu)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("lodeme_plani_kodu");

                entity.Property(e => e.Logoentegre)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("logoentegre");

                entity.Property(e => e.Logosipref).HasColumnName("logosipref");

                entity.Property(e => e.Logotar)
                    .HasColumnType("datetime")
                    .HasColumnName("logotar");

                entity.Property(e => e.Logref).HasColumnName("logref");

                entity.Property(e => e.Lpersoneladi)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("lpersoneladi");

                entity.Property(e => e.Lpersonelref).HasColumnName("lpersonelref");

                entity.Property(e => e.Notlar)
                    .HasColumnType("text")
                    .HasColumnName("notlar");

                entity.Property(e => e.Proje)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("proje");

                entity.Property(e => e.Revizyon).HasColumnName("revizyon");

                entity.Property(e => e.Revzno)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("revzno");

                entity.Property(e => e.Saat)
                    .HasColumnType("datetime")
                    .HasColumnName("saat");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Tarih)
                    .HasColumnType("datetime")
                    .HasColumnName("tarih");

                entity.Property(e => e.Tbelgeno)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("tbelgeno");

                entity.Property(e => e.Teklifno)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("teklifno");

                entity.Property(e => e.TeslimSekli)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("teslim_sekli");

                entity.Property(e => e.TeslimTarihi)
                    .HasColumnType("datetime")
                    .HasColumnName("teslim_tarihi");

                entity.Property(e => e.Trcode).HasColumnName("trcode");

                entity.Property(e => e.Tutar).HasColumnName("tutar");

                entity.Property(e => e.Tutarmatrah).HasColumnName("tutarmatrah");

                entity.Property(e => e.Tutarmatrahrd).HasColumnName("tutarmatrahrd");

                entity.Property(e => e.Tutarmatrahtl).HasColumnName("tutarmatrahtl");

                entity.Property(e => e.Tutarrd).HasColumnName("tutarrd");

                entity.Property(e => e.Tutartl).HasColumnName("tutartl");

                entity.Property(e => e.Upddate)
                    .HasColumnType("datetime")
                    .HasColumnName("upddate");

                entity.Property(e => e.Upduser)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("upduser");
            });

            modelBuilder.Entity<TeklifOnaylamaYetkileri>(entity =>
            {
                entity.HasKey(e => e.Logref);

                entity.ToTable("teklif_onaylama_yetkileri");

                entity.Property(e => e.Logref)
                    .ValueGeneratedNever()
                    .HasColumnName("logref");

                entity.Property(e => e.Duruminfo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("duruminfo");

                entity.Property(e => e.Insdate)
                    .HasColumnType("datetime")
                    .HasColumnName("insdate");

                entity.Property(e => e.Insuser)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("insuser");

                entity.Property(e => e.PersonelKodu)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("personel_kodu");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Upddate)
                    .HasColumnType("datetime")
                    .HasColumnName("upddate");

                entity.Property(e => e.Upduser)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("upduser");
            });

            modelBuilder.Entity<TeklifRotaLog>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("teklif_rota_log");

                entity.Property(e => e.Durum).HasColumnName("durum");

                entity.Property(e => e.Insdate)
                    .HasColumnType("datetime")
                    .HasColumnName("insdate");

                entity.Property(e => e.Insuser)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("insuser");

                entity.Property(e => e.Irsref).HasColumnName("irsref");

                entity.Property(e => e.IsinAdi)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("isin_adi");

                entity.Property(e => e.Istekler)
                    .HasColumnType("text")
                    .HasColumnName("istekler");

                entity.Property(e => e.Kisiler)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("kisiler");

                entity.Property(e => e.Logref).HasColumnName("logref");

                entity.Property(e => e.OncelikSirasi).HasColumnName("oncelik_sirasi");

                entity.Property(e => e.Opadi)
                    .IsRequired()
                    .HasMaxLength(51)
                    .IsUnicode(false)
                    .HasColumnName("opadi");

                entity.Property(e => e.Opbitistarihi)
                    .HasColumnType("datetime")
                    .HasColumnName("opbitistarihi");

                entity.Property(e => e.Operasyonref).HasColumnName("operasyonref");

                entity.Property(e => e.Opfason).HasColumnName("opfason");

                entity.Property(e => e.Opharturref).HasColumnName("opharturref");

                entity.Property(e => e.Opkodu)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("opkodu");

                entity.Property(e => e.Opozelkod)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("opozelkod");

                entity.Property(e => e.Opsira).HasColumnName("opsira");

                entity.Property(e => e.Optanim)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("optanim");

                entity.Property(e => e.Recref)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("recref");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.TalepTarihi)
                    .HasColumnType("datetime")
                    .HasColumnName("talep_tarihi");

                entity.Property(e => e.TasarimGordu).HasColumnName("tasarim_gordu");

                entity.Property(e => e.Teklifref).HasColumnName("teklifref");

                entity.Property(e => e.Upddate)
                    .HasColumnType("datetime")
                    .HasColumnName("upddate");

                entity.Property(e => e.Upduser)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("upduser");

                entity.Property(e => e.Yapilanlar)
                    .HasColumnType("text")
                    .HasColumnName("yapilanlar");
            });

            modelBuilder.Entity<TeklifRotum>(entity =>
            {
                entity.HasKey(e => e.Logref);

                entity.ToTable("teklif_rota");

                entity.Property(e => e.Logref)
                    .ValueGeneratedNever()
                    .HasColumnName("logref");

                entity.Property(e => e.Durum).HasColumnName("durum");

                entity.Property(e => e.Insdate)
                    .HasColumnType("datetime")
                    .HasColumnName("insdate");

                entity.Property(e => e.Insuser)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("insuser");

                entity.Property(e => e.Irsref).HasColumnName("irsref");

                entity.Property(e => e.IsinAdi)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("isin_adi");

                entity.Property(e => e.Istekler)
                    .HasColumnType("text")
                    .HasColumnName("istekler");

                entity.Property(e => e.Kisiler)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("kisiler");

                entity.Property(e => e.OncelikSirasi).HasColumnName("oncelik_sirasi");

                entity.Property(e => e.Opadi)
                    .IsRequired()
                    .HasMaxLength(51)
                    .IsUnicode(false)
                    .HasColumnName("opadi");

                entity.Property(e => e.Opbitistarihi)
                    .HasColumnType("datetime")
                    .HasColumnName("opbitistarihi");

                entity.Property(e => e.Operasyonref).HasColumnName("operasyonref");

                entity.Property(e => e.Opfason).HasColumnName("opfason");

                entity.Property(e => e.Opharturref).HasColumnName("opharturref");

                entity.Property(e => e.Opkodu)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("opkodu");

                entity.Property(e => e.Opozelkod)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("opozelkod");

                entity.Property(e => e.Opsira).HasColumnName("opsira");

                entity.Property(e => e.Optanim)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("optanim");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.TalepTarihi)
                    .HasColumnType("datetime")
                    .HasColumnName("talep_tarihi");

                entity.Property(e => e.TasarimGordu).HasColumnName("tasarim_gordu");

                entity.Property(e => e.Teklifref).HasColumnName("teklifref");

                entity.Property(e => e.Upddate)
                    .HasColumnType("datetime")
                    .HasColumnName("upddate");

                entity.Property(e => e.Upduser)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("upduser");

                entity.Property(e => e.Yapilanlar)
                    .HasColumnType("text")
                    .HasColumnName("yapilanlar");
            });

            modelBuilder.Entity<TeklifSabitler>(entity =>
            {
                entity.HasKey(e => e.Logref);

                entity.ToTable("teklif_sabitler");

                entity.Property(e => e.Logref)
                    .ValueGeneratedNever()
                    .HasColumnName("logref");

                entity.Property(e => e.Insdate)
                    .HasColumnType("datetime")
                    .HasColumnName("insdate");

                entity.Property(e => e.Insuser)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("insuser");

                entity.Property(e => e.Isk).HasColumnName("isk");

                entity.Property(e => e.Isk1).HasColumnName("isk1");

                entity.Property(e => e.Isk2).HasColumnName("isk2");

                entity.Property(e => e.Isk3).HasColumnName("isk3");

                entity.Property(e => e.Upddate)
                    .HasColumnType("datetime")
                    .HasColumnName("upddate");

                entity.Property(e => e.Upduser)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("upduser");
            });

            modelBuilder.Entity<TeklifSabitlerLog>(entity =>
            {
                entity.HasKey(e => e.Recref);

                entity.ToTable("teklif_sabitler_log");

                entity.Property(e => e.Recref).HasColumnName("recref");

                entity.Property(e => e.Insdate)
                    .HasColumnType("datetime")
                    .HasColumnName("insdate");

                entity.Property(e => e.Insuser)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("insuser");

                entity.Property(e => e.Isk).HasColumnName("isk");

                entity.Property(e => e.Isk1).HasColumnName("isk1");

                entity.Property(e => e.Isk2).HasColumnName("isk2");

                entity.Property(e => e.Isk3).HasColumnName("isk3");

                entity.Property(e => e.Logref).HasColumnName("logref");

                entity.Property(e => e.Upddate)
                    .HasColumnType("datetime")
                    .HasColumnName("upddate");

                entity.Property(e => e.Upduser)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("upduser");
            });

            modelBuilder.Entity<Teklifdetay>(entity =>
            {
                entity.HasKey(e => e.Logref);

                entity.ToTable("teklifdetay");

                entity.Property(e => e.Logref)
                    .ValueGeneratedNever()
                    .HasColumnName("logref");

                entity.Property(e => e.Aciklama)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("aciklama");

                entity.Property(e => e.Cizimkodu)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("cizimkodu");

                entity.Property(e => e.Dovizkuru).HasColumnName("dovizkuru");

                entity.Property(e => e.Dovizref).HasColumnName("dovizref");

                entity.Property(e => e.Duruminfo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("duruminfo");

                entity.Property(e => e.Ebat)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ebat");

                entity.Property(e => e.FiltreHarRef).HasColumnName("filtre_har_ref");

                entity.Property(e => e.Fiyat).HasColumnName("fiyat");

                entity.Property(e => e.Fiyattl).HasColumnName("fiyattl");

                entity.Property(e => e.Insdate)
                    .HasColumnType("datetime")
                    .HasColumnName("insdate");

                entity.Property(e => e.Insuser)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("insuser");

                entity.Property(e => e.Isktut1).HasColumnName("isktut1");

                entity.Property(e => e.Isktut1id).HasColumnName("isktut1id");

                entity.Property(e => e.Isktut1rd).HasColumnName("isktut1rd");

                entity.Property(e => e.Isktut1tl).HasColumnName("isktut1tl");

                entity.Property(e => e.Isktut2).HasColumnName("isktut2");

                entity.Property(e => e.Isktut2id).HasColumnName("isktut2id");

                entity.Property(e => e.Isktut2rd).HasColumnName("isktut2rd");

                entity.Property(e => e.Isktut2tl).HasColumnName("isktut2tl");

                entity.Property(e => e.Isktut3).HasColumnName("isktut3");

                entity.Property(e => e.Isktut3id).HasColumnName("isktut3id");

                entity.Property(e => e.Isktut3rd).HasColumnName("isktut3rd");

                entity.Property(e => e.Isktut3tl).HasColumnName("isktut3tl");

                entity.Property(e => e.Isktut4).HasColumnName("isktut4");

                entity.Property(e => e.Isktut4id).HasColumnName("isktut4id");

                entity.Property(e => e.Isktut4rd).HasColumnName("isktut4rd");

                entity.Property(e => e.Isktut4tl).HasColumnName("isktut4tl");

                entity.Property(e => e.Iskyuz1).HasColumnName("iskyuz1");

                entity.Property(e => e.Iskyuz2).HasColumnName("iskyuz2");

                entity.Property(e => e.Iskyuz3).HasColumnName("iskyuz3");

                entity.Property(e => e.Iskyuz4).HasColumnName("iskyuz4");

                entity.Property(e => e.Kdvkod).HasColumnName("kdvkod");

                entity.Property(e => e.Kdvmatrah).HasColumnName("kdvmatrah");

                entity.Property(e => e.Kdvmatrahid).HasColumnName("kdvmatrahid");

                entity.Property(e => e.Kdvmatrahrd).HasColumnName("kdvmatrahrd");

                entity.Property(e => e.Kdvmatrahtl).HasColumnName("kdvmatrahtl");

                entity.Property(e => e.Kdvtut).HasColumnName("kdvtut");

                entity.Property(e => e.Kdvtutid).HasColumnName("kdvtutid");

                entity.Property(e => e.Kdvtutrd).HasColumnName("kdvtutrd");

                entity.Property(e => e.Kdvtuttl).HasColumnName("kdvtuttl");

                entity.Property(e => e.Kdvyuz).HasColumnName("kdvyuz");

                entity.Property(e => e.Ldonem)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("ldonem")
                    .IsFixedLength(true);

                entity.Property(e => e.Lfirma)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("lfirma")
                    .IsFixedLength(true);

                entity.Property(e => e.LstokAdi)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("lstok_adi");

                entity.Property(e => e.LstokId).HasColumnName("lstok_id");

                entity.Property(e => e.LstokKodu)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("lstok_kodu");

                entity.Property(e => e.Maliyet1).HasColumnName("maliyet1");

                entity.Property(e => e.Maliyet1id).HasColumnName("maliyet1id");

                entity.Property(e => e.Maliyet2).HasColumnName("maliyet2");

                entity.Property(e => e.Maliyet2id).HasColumnName("maliyet2id");

                entity.Property(e => e.Marka)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("marka");

                entity.Property(e => e.Mensei)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("mensei");

                entity.Property(e => e.Miktar).HasColumnName("miktar");

                entity.Property(e => e.Nettutar).HasColumnName("nettutar");

                entity.Property(e => e.Nettutarid).HasColumnName("nettutarid");

                entity.Property(e => e.Nettutarrd).HasColumnName("nettutarrd");

                entity.Property(e => e.Nettutartl).HasColumnName("nettutartl");

                entity.Property(e => e.Siplogref).HasColumnName("siplogref");

                entity.Property(e => e.Sipnosira)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("sipnosira");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Teklifref).HasColumnName("teklifref");

                entity.Property(e => e.TeslimTarihi)
                    .HasColumnType("datetime")
                    .HasColumnName("teslim_tarihi");

                entity.Property(e => e.Tutar).HasColumnName("tutar");

                entity.Property(e => e.Tutarid).HasColumnName("tutarid");

                entity.Property(e => e.Tutarrd).HasColumnName("tutarrd");

                entity.Property(e => e.Tutartl).HasColumnName("tutartl");

                entity.Property(e => e.Unitsetllogref).HasColumnName("unitsetllogref");

                entity.Property(e => e.Unitsetref).HasColumnName("unitsetref");

                entity.Property(e => e.Upddate)
                    .HasColumnType("datetime")
                    .HasColumnName("upddate");

                entity.Property(e => e.Upduser)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("upduser");
                
                entity.Property(e => e.Mahal).HasColumnName("mahal");
            });

            modelBuilder.Entity<TeklifdetayLog>(entity =>
            {
                entity.HasKey(e => e.Recref);

                entity.ToTable("teklifdetay_log");

                entity.Property(e => e.Recref).HasColumnName("recref");

                entity.Property(e => e.Aciklama)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("aciklama");

                entity.Property(e => e.Cizimkodu)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("cizimkodu");

                entity.Property(e => e.Dovizkuru).HasColumnName("dovizkuru");

                entity.Property(e => e.Dovizref).HasColumnName("dovizref");

                entity.Property(e => e.Duruminfo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("duruminfo");

                entity.Property(e => e.Ebat)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ebat");

                entity.Property(e => e.FiltreHarRef).HasColumnName("filtre_har_ref");

                entity.Property(e => e.Fiyat).HasColumnName("fiyat");

                entity.Property(e => e.Fiyattl).HasColumnName("fiyattl");

                entity.Property(e => e.Insdate)
                    .HasColumnType("datetime")
                    .HasColumnName("insdate");

                entity.Property(e => e.Insuser)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("insuser");

                entity.Property(e => e.Isktut1).HasColumnName("isktut1");

                entity.Property(e => e.Isktut1id).HasColumnName("isktut1id");

                entity.Property(e => e.Isktut1rd).HasColumnName("isktut1rd");

                entity.Property(e => e.Isktut1tl).HasColumnName("isktut1tl");

                entity.Property(e => e.Isktut2).HasColumnName("isktut2");

                entity.Property(e => e.Isktut2id).HasColumnName("isktut2id");

                entity.Property(e => e.Isktut2rd).HasColumnName("isktut2rd");

                entity.Property(e => e.Isktut2tl).HasColumnName("isktut2tl");

                entity.Property(e => e.Isktut3).HasColumnName("isktut3");

                entity.Property(e => e.Isktut3id).HasColumnName("isktut3id");

                entity.Property(e => e.Isktut3rd).HasColumnName("isktut3rd");

                entity.Property(e => e.Isktut3tl).HasColumnName("isktut3tl");

                entity.Property(e => e.Isktut4).HasColumnName("isktut4");

                entity.Property(e => e.Isktut4id).HasColumnName("isktut4id");

                entity.Property(e => e.Isktut4rd).HasColumnName("isktut4rd");

                entity.Property(e => e.Isktut4tl).HasColumnName("isktut4tl");

                entity.Property(e => e.Iskyuz1).HasColumnName("iskyuz1");

                entity.Property(e => e.Iskyuz2).HasColumnName("iskyuz2");

                entity.Property(e => e.Iskyuz3).HasColumnName("iskyuz3");

                entity.Property(e => e.Iskyuz4).HasColumnName("iskyuz4");

                entity.Property(e => e.Kdvkod).HasColumnName("kdvkod");

                entity.Property(e => e.Kdvmatrah).HasColumnName("kdvmatrah");

                entity.Property(e => e.Kdvmatrahid).HasColumnName("kdvmatrahid");

                entity.Property(e => e.Kdvmatrahrd).HasColumnName("kdvmatrahrd");

                entity.Property(e => e.Kdvmatrahtl).HasColumnName("kdvmatrahtl");

                entity.Property(e => e.Kdvtut).HasColumnName("kdvtut");

                entity.Property(e => e.Kdvtutid).HasColumnName("kdvtutid");

                entity.Property(e => e.Kdvtutrd).HasColumnName("kdvtutrd");

                entity.Property(e => e.Kdvtuttl).HasColumnName("kdvtuttl");

                entity.Property(e => e.Kdvyuz).HasColumnName("kdvyuz");

                entity.Property(e => e.Ldonem)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("ldonem")
                    .IsFixedLength(true);

                entity.Property(e => e.Lfirma)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("lfirma")
                    .IsFixedLength(true);

                entity.Property(e => e.Logref).HasColumnName("logref");

                entity.Property(e => e.LstokAdi)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("lstok_adi");

                entity.Property(e => e.LstokId).HasColumnName("lstok_id");

                entity.Property(e => e.LstokKodu)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("lstok_kodu");

                entity.Property(e => e.Maliyet1).HasColumnName("maliyet1");

                entity.Property(e => e.Maliyet1id).HasColumnName("maliyet1id");

                entity.Property(e => e.Maliyet2).HasColumnName("maliyet2");

                entity.Property(e => e.Maliyet2id).HasColumnName("maliyet2id");

                entity.Property(e => e.Marka)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("marka");

                entity.Property(e => e.Mensei)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("mensei");

                entity.Property(e => e.Miktar).HasColumnName("miktar");

                entity.Property(e => e.Nettutar).HasColumnName("nettutar");

                entity.Property(e => e.Nettutarid).HasColumnName("nettutarid");

                entity.Property(e => e.Nettutarrd).HasColumnName("nettutarrd");

                entity.Property(e => e.Nettutartl).HasColumnName("nettutartl");

                entity.Property(e => e.Siplogref).HasColumnName("siplogref");

                entity.Property(e => e.Sipnosira)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("sipnosira");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Teklifref).HasColumnName("teklifref");

                entity.Property(e => e.TeslimTarihi)
                    .HasColumnType("datetime")
                    .HasColumnName("teslim_tarihi");

                entity.Property(e => e.Tutar).HasColumnName("tutar");

                entity.Property(e => e.Tutarid).HasColumnName("tutarid");

                entity.Property(e => e.Tutarrd).HasColumnName("tutarrd");

                entity.Property(e => e.Tutartl).HasColumnName("tutartl");

                entity.Property(e => e.Unitsetllogref).HasColumnName("unitsetllogref");

                entity.Property(e => e.Unitsetref).HasColumnName("unitsetref");

                entity.Property(e => e.Upddate)
                    .HasColumnType("datetime")
                    .HasColumnName("upddate");

                entity.Property(e => e.Upduser)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("upduser");

                entity.Property(e => e.Mahal).HasColumnName("mahal");
            });

            modelBuilder.Entity<UmtMuhasebeTablo>(entity =>
            {
                entity.HasKey(e => e.Logref);

                entity.ToTable("umt_muhasebe_tablo");

                entity.Property(e => e.Logref).HasColumnName("logref");

                entity.Property(e => e.Aciklama)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("aciklama");

                entity.Property(e => e.Firma).HasColumnName("firma");

                entity.Property(e => e.Kodu)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("kodu");

                entity.Property(e => e.Sirano).HasColumnName("sirano");
            });

            modelBuilder.Entity<UmtMuhasebeTabloDetay>(entity =>
            {
                entity.HasKey(e => e.Logref);

                entity.ToTable("umt_muhasebe_tablo_detay");

                entity.HasIndex(e => new { e.Parlogref, e.Hesno }, "IX_umt_muhasebe_tablo_detay")
                    .IsUnique();

                entity.Property(e => e.Logref).HasColumnName("logref");

                entity.Property(e => e.Hesadi)
                    .HasMaxLength(51)
                    .IsUnicode(false)
                    .HasColumnName("hesadi");

                entity.Property(e => e.Hesno)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("hesno");

                entity.Property(e => e.Ozelkod2)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("ozelkod2");

                entity.Property(e => e.Parlogref).HasColumnName("parlogref");
            });

            modelBuilder.Entity<V001CariKart>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("v001_cari_kart");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Adi)
                    .HasMaxLength(201)
                    .IsUnicode(false)
                    .HasColumnName("adi");

                entity.Property(e => e.Adres1)
                    .HasMaxLength(201)
                    .IsUnicode(false)
                    .HasColumnName("adres1");

                entity.Property(e => e.Adres2)
                    .HasMaxLength(201)
                    .IsUnicode(false)
                    .HasColumnName("adres2");

                entity.Property(e => e.Caritip).HasColumnName("caritip");

                entity.Property(e => e.Caritipadi)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("caritipadi");

                entity.Property(e => e.Faks)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("faks");

                entity.Property(e => e.Il)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("il");

                entity.Property(e => e.Ilce)
                    .HasMaxLength(51)
                    .IsUnicode(false)
                    .HasColumnName("ilce");

                entity.Property(e => e.Kodu)
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("kodu");

                entity.Property(e => e.Logref).HasColumnName("logref");

                entity.Property(e => e.Mail)
                    .HasMaxLength(251)
                    .IsUnicode(false)
                    .HasColumnName("mail");

                entity.Property(e => e.Ozelkod)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("ozelkod");

                entity.Property(e => e.Ozelkod2)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("ozelkod2");

                entity.Property(e => e.Ozelkod3)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("ozelkod3");

                entity.Property(e => e.Ozelkod4)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("ozelkod4");

                entity.Property(e => e.Ozelkod5)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("ozelkod5");

                entity.Property(e => e.Postakodu)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("postakodu");

                entity.Property(e => e.Semt)
                    .HasMaxLength(51)
                    .IsUnicode(false)
                    .HasColumnName("semt");

                entity.Property(e => e.Tel1)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("tel1");

                entity.Property(e => e.Tel2)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("tel2");

                entity.Property(e => e.Ulke)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("ulke");

                entity.Property(e => e.Vdadi)
                    .HasMaxLength(31)
                    .IsUnicode(false)
                    .HasColumnName("vdadi");

                entity.Property(e => e.Vdno)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("vdno");

                entity.Property(e => e.Web)
                    .HasMaxLength(101)
                    .IsUnicode(false)
                    .HasColumnName("web");
            });

            modelBuilder.Entity<V001CariKart2>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("v001_cari_kart2");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Adi)
                    .HasMaxLength(201)
                    .IsUnicode(false)
                    .HasColumnName("adi");

                entity.Property(e => e.Adres1)
                    .HasMaxLength(201)
                    .IsUnicode(false)
                    .HasColumnName("adres1");

                entity.Property(e => e.Kodu)
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("kodu");

                entity.Property(e => e.Logref).HasColumnName("logref");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Vdno)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("vdno");
            });

            modelBuilder.Entity<V002Malzemeler>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("v002_malzemeler");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Adi)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("adi");

                entity.Property(e => e.Adi3)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("adi3");

                entity.Property(e => e.Birimsetiref).HasColumnName("birimsetiref");

                entity.Property(e => e.Definition)
                    .HasMaxLength(41)
                    .IsUnicode(false)
                    .HasColumnName("DEFINITION_");

                entity.Property(e => e.Descr)
                    .HasMaxLength(51)
                    .IsUnicode(false)
                    .HasColumnName("DESCR");

                entity.Property(e => e.Ebatt)
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("EBATT");

                entity.Property(e => e.Grupkodu)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("grupkodu");

                entity.Property(e => e.Height).HasColumnName("HEIGHT");

                entity.Property(e => e.Karttipi).HasColumnName("karttipi");

                entity.Property(e => e.Kdvyuz).HasColumnName("kdvyuz");

                entity.Property(e => e.Kodu)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("kodu");

                entity.Property(e => e.Length).HasColumnName("LENGTH");

                entity.Property(e => e.Logref).HasColumnName("logref");

                entity.Property(e => e.Ozelkod)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("ozelkod");

                entity.Property(e => e.Ozelkod2)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("ozelkod2");

                entity.Property(e => e.Ozelkod3)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("ozelkod3");

                entity.Property(e => e.Ozelkod4)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("ozelkod4");

                entity.Property(e => e.Ozelkod5)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("ozelkod5");

                entity.Property(e => e.Width).HasColumnName("WIDTH");
            });

            modelBuilder.Entity<V004Sevkadre>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("v004_sevkadres");

                entity.Property(e => e.Clientref).HasColumnName("CLIENTREF");

                entity.Property(e => e.Durumu).HasColumnName("durumu");

                entity.Property(e => e.Faks)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("faks");

                entity.Property(e => e.Il)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("il");

                entity.Property(e => e.Ilce)
                    .HasMaxLength(51)
                    .IsUnicode(false)
                    .HasColumnName("ilce");

                entity.Property(e => e.Logref)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("logref");

                entity.Property(e => e.Mail)
                    .HasMaxLength(51)
                    .IsUnicode(false)
                    .HasColumnName("mail");

                entity.Property(e => e.Postakodu)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("postakodu");

                entity.Property(e => e.Semt)
                    .HasMaxLength(51)
                    .IsUnicode(false)
                    .HasColumnName("semt");

                entity.Property(e => e.SevkEdilecekBayiAdi)
                    .HasMaxLength(51)
                    .IsUnicode(false)
                    .HasColumnName("sevk_edilecek_bayi_adi");

                entity.Property(e => e.SevkIlgilisi)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("sevk_ilgilisi");

                entity.Property(e => e.Sevkadres1)
                    .HasMaxLength(201)
                    .IsUnicode(false)
                    .HasColumnName("sevkadres1");

                entity.Property(e => e.Sevkadres2)
                    .HasMaxLength(201)
                    .IsUnicode(false)
                    .HasColumnName("sevkadres2");

                entity.Property(e => e.Sevkkodu)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("sevkkodu");

                entity.Property(e => e.Tel1)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("tel1");

                entity.Property(e => e.Tel2)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("tel2");

                entity.Property(e => e.Ulke)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("ulke");

                entity.Property(e => e.Vdadi)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("vdadi");

                entity.Property(e => e.Vdno)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("vdno");
            });

            modelBuilder.Entity<V009Teklif>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("v009_teklif");

                entity.Property(e => e.Aciklama1)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("aciklama1");

                entity.Property(e => e.Aciklama2)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("aciklama2");

                entity.Property(e => e.Aciklama3)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("aciklama3");

                entity.Property(e => e.Aciklama4)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("aciklama4");

                entity.Property(e => e.Cariadi)
                    .HasMaxLength(201)
                    .IsUnicode(false)
                    .HasColumnName("cariadi");

                entity.Property(e => e.Carikodu)
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("carikodu");

                entity.Property(e => e.Cariref).HasColumnName("cariref");

                entity.Property(e => e.Carisevkadrref).HasColumnName("carisevkadrref");

                entity.Property(e => e.Caritip).HasColumnName("caritip");

                entity.Property(e => e.Dovizdoku)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("dovizdoku");

                entity.Property(e => e.Dovizdokuid)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("dovizdokuid");

                entity.Property(e => e.Dovizkuru).HasColumnName("dovizkuru");

                entity.Property(e => e.Dovizkuruid).HasColumnName("dovizkuruid");

                entity.Property(e => e.Dovizref).HasColumnName("dovizref");

                entity.Property(e => e.Dovizrefid).HasColumnName("dovizrefid");

                entity.Property(e => e.Duruminfo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("duruminfo");

                entity.Property(e => e.Faks)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("faks");

                entity.Property(e => e.Gniskoran).HasColumnName("gniskoran");

                entity.Property(e => e.Gnisktutar).HasColumnName("gnisktutar");

                entity.Property(e => e.Gnistip).HasColumnName("gnistip");

                entity.Property(e => e.Il)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("il");

                entity.Property(e => e.Ilce)
                    .HasMaxLength(51)
                    .IsUnicode(false)
                    .HasColumnName("ilce");

                entity.Property(e => e.IlgiliAdi)
                    .HasMaxLength(51)
                    .IsUnicode(false)
                    .HasColumnName("ilgili_adi");

                entity.Property(e => e.Insdate)
                    .HasColumnType("datetime")
                    .HasColumnName("insdate");

                entity.Property(e => e.Insuser)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("insuser");

                entity.Property(e => e.LcariAdi)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("lcari_adi");

                entity.Property(e => e.LcariKodu)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("lcari_kodu");

                entity.Property(e => e.LcariSevkadrKodu)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("lcari_sevkadr_kodu");

                entity.Property(e => e.Ldonem)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("ldonem")
                    .IsFixedLength(true);

                entity.Property(e => e.Lfirma)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("lfirma")
                    .IsFixedLength(true);

                entity.Property(e => e.LodemePlani).HasColumnName("lodeme_plani");

                entity.Property(e => e.LodemePlaniKodu)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("lodeme_plani_kodu");

                entity.Property(e => e.Logoentegre)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("logoentegre");

                entity.Property(e => e.Logosipref).HasColumnName("logosipref");

                entity.Property(e => e.Logotar)
                    .HasColumnType("datetime")
                    .HasColumnName("logotar");

                entity.Property(e => e.Logref).HasColumnName("logref");

                entity.Property(e => e.Lpersoneladi)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("lpersoneladi");

                entity.Property(e => e.Lpersonelref).HasColumnName("lpersonelref");

                entity.Property(e => e.Mail)
                    .HasMaxLength(51)
                    .IsUnicode(false)
                    .HasColumnName("mail");

                entity.Property(e => e.Notlar)
                    .HasColumnType("text")
                    .HasColumnName("notlar");

                entity.Property(e => e.Odemeplaniadi)
                    .HasMaxLength(201)
                    .IsUnicode(false)
                    .HasColumnName("odemeplaniadi");

                entity.Property(e => e.Odemeplanikodu)
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("odemeplanikodu");

                entity.Property(e => e.Proje)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("proje");

                entity.Property(e => e.Revizyon).HasColumnName("revizyon");

                entity.Property(e => e.Revzno)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("revzno");

                entity.Property(e => e.Saat)
                    .HasColumnType("datetime")
                    .HasColumnName("saat");

                entity.Property(e => e.SevkEdilecekBayiAdi)
                    .HasMaxLength(51)
                    .IsUnicode(false)
                    .HasColumnName("sevk_edilecek_bayi_adi");

                entity.Property(e => e.SevkIlgilisi)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("sevk_ilgilisi");

                entity.Property(e => e.Sevkadres1)
                    .HasMaxLength(201)
                    .IsUnicode(false)
                    .HasColumnName("sevkadres1");

                entity.Property(e => e.Sevkadres2)
                    .HasMaxLength(201)
                    .IsUnicode(false)
                    .HasColumnName("sevkadres2");

                entity.Property(e => e.Sevkkodu)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("sevkkodu");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Tarih)
                    .HasColumnType("datetime")
                    .HasColumnName("tarih");

                entity.Property(e => e.Tbelgeno)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("tbelgeno");

                entity.Property(e => e.Teklifno)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("teklifno");

                entity.Property(e => e.Tel1)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("tel1");

                entity.Property(e => e.Tel2)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("tel2");

                entity.Property(e => e.Temsilciadi)
                    .HasMaxLength(51)
                    .IsUnicode(false)
                    .HasColumnName("temsilciadi");

                entity.Property(e => e.Temsilcikodu)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("temsilcikodu");

                entity.Property(e => e.TeslimSekli)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("teslim_sekli");

                entity.Property(e => e.TeslimTarihi)
                    .HasColumnType("datetime")
                    .HasColumnName("teslim_tarihi");

                entity.Property(e => e.Trcode).HasColumnName("trcode");

                entity.Property(e => e.Tutar).HasColumnName("tutar");

                entity.Property(e => e.Tutarmatrah).HasColumnName("tutarmatrah");

                entity.Property(e => e.Tutarmatrahrd).HasColumnName("tutarmatrahrd");

                entity.Property(e => e.Tutarmatrahtl).HasColumnName("tutarmatrahtl");

                entity.Property(e => e.Tutarrd).HasColumnName("tutarrd");

                entity.Property(e => e.Tutartl).HasColumnName("tutartl");

                entity.Property(e => e.Upddate)
                    .HasColumnType("datetime")
                    .HasColumnName("upddate");

                entity.Property(e => e.Upduser)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("upduser");
            });

            modelBuilder.Entity<V009Teklif2>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("v009_teklif2");

                entity.Property(e => e.Aciklama1)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("aciklama1");

                entity.Property(e => e.Aciklama2)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("aciklama2");

                entity.Property(e => e.Aciklama3)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("aciklama3");

                entity.Property(e => e.Aciklama4)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("aciklama4");

                entity.Property(e => e.Cariadi)
                    .HasMaxLength(201)
                    .IsUnicode(false)
                    .HasColumnName("cariadi");

                entity.Property(e => e.Carikodu)
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("carikodu");

                entity.Property(e => e.Cariref).HasColumnName("cariref");

                entity.Property(e => e.Carisevkadrref).HasColumnName("carisevkadrref");

                entity.Property(e => e.Caritip).HasColumnName("caritip");

                entity.Property(e => e.Dovizdoku)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("dovizdoku");

                entity.Property(e => e.Dovizdokuid)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("dovizdokuid");

                entity.Property(e => e.Dovizkuru).HasColumnName("dovizkuru");

                entity.Property(e => e.Dovizkuruid).HasColumnName("dovizkuruid");

                entity.Property(e => e.Dovizref).HasColumnName("dovizref");

                entity.Property(e => e.Dovizrefid).HasColumnName("dovizrefid");

                entity.Property(e => e.Duruminfo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("duruminfo");

                entity.Property(e => e.Faks)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("faks");

                entity.Property(e => e.Gniskoran).HasColumnName("gniskoran");

                entity.Property(e => e.Gnisktutar).HasColumnName("gnisktutar");

                entity.Property(e => e.Gnistip).HasColumnName("gnistip");

                entity.Property(e => e.Il)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("il");

                entity.Property(e => e.Ilce)
                    .HasMaxLength(51)
                    .IsUnicode(false)
                    .HasColumnName("ilce");

                entity.Property(e => e.IlgiliAdi)
                    .HasMaxLength(51)
                    .IsUnicode(false)
                    .HasColumnName("ilgili_adi");

                entity.Property(e => e.Insdate)
                    .HasColumnType("datetime")
                    .HasColumnName("insdate");

                entity.Property(e => e.Insuser)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("insuser");

                entity.Property(e => e.LcariAdi)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("lcari_adi");

                entity.Property(e => e.LcariKodu)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("lcari_kodu");

                entity.Property(e => e.LcariSevkadrKodu)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("lcari_sevkadr_kodu");

                entity.Property(e => e.Ldonem)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("ldonem")
                    .IsFixedLength(true);

                entity.Property(e => e.Lfirma)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("lfirma")
                    .IsFixedLength(true);

                entity.Property(e => e.LodemePlani).HasColumnName("lodeme_plani");

                entity.Property(e => e.LodemePlaniKodu)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("lodeme_plani_kodu");

                entity.Property(e => e.Logoentegre)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("logoentegre");

                entity.Property(e => e.Logosipref).HasColumnName("logosipref");

                entity.Property(e => e.Logotar)
                    .HasColumnType("datetime")
                    .HasColumnName("logotar");

                entity.Property(e => e.Logref).HasColumnName("logref");

                entity.Property(e => e.Lpersoneladi)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("lpersoneladi");

                entity.Property(e => e.Lpersonelref).HasColumnName("lpersonelref");

                entity.Property(e => e.Mail)
                    .HasMaxLength(51)
                    .IsUnicode(false)
                    .HasColumnName("mail");

                entity.Property(e => e.Notlar)
                    .HasColumnType("text")
                    .HasColumnName("notlar");

                entity.Property(e => e.Odemeplaniadi)
                    .HasMaxLength(201)
                    .IsUnicode(false)
                    .HasColumnName("odemeplaniadi");

                entity.Property(e => e.Odemeplanikodu)
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("odemeplanikodu");

                entity.Property(e => e.Proje)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("proje");

                entity.Property(e => e.Revizyon).HasColumnName("revizyon");

                entity.Property(e => e.Revzno)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("revzno");

                entity.Property(e => e.Saat)
                    .HasColumnType("datetime")
                    .HasColumnName("saat");

                entity.Property(e => e.SevkEdilecekBayiAdi)
                    .HasMaxLength(51)
                    .IsUnicode(false)
                    .HasColumnName("sevk_edilecek_bayi_adi");

                entity.Property(e => e.SevkIlgilisi)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("sevk_ilgilisi");

                entity.Property(e => e.Sevkadres1)
                    .HasMaxLength(201)
                    .IsUnicode(false)
                    .HasColumnName("sevkadres1");

                entity.Property(e => e.Sevkadres2)
                    .HasMaxLength(201)
                    .IsUnicode(false)
                    .HasColumnName("sevkadres2");

                entity.Property(e => e.Sevkkodu)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("sevkkodu");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Tarih)
                    .HasColumnType("datetime")
                    .HasColumnName("tarih");

                entity.Property(e => e.Tbelgeno)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("tbelgeno");

                entity.Property(e => e.Teklifno)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("teklifno");

                entity.Property(e => e.Tel1)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("tel1");

                entity.Property(e => e.Tel2)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("tel2");

                entity.Property(e => e.Temsilciadi)
                    .HasMaxLength(51)
                    .IsUnicode(false)
                    .HasColumnName("temsilciadi");

                entity.Property(e => e.Temsilcikodu)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("temsilcikodu");

                entity.Property(e => e.TeslimSekli)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("teslim_sekli");

                entity.Property(e => e.TeslimTarihi)
                    .HasColumnType("datetime")
                    .HasColumnName("teslim_tarihi");

                entity.Property(e => e.Trcode).HasColumnName("trcode");

                entity.Property(e => e.Tutar).HasColumnName("tutar");

                entity.Property(e => e.Tutarmatrah).HasColumnName("tutarmatrah");

                entity.Property(e => e.Tutarmatrahrd).HasColumnName("tutarmatrahrd");

                entity.Property(e => e.Tutarmatrahtl).HasColumnName("tutarmatrahtl");

                entity.Property(e => e.Tutarrd).HasColumnName("tutarrd");

                entity.Property(e => e.Tutartl).HasColumnName("tutartl");

                entity.Property(e => e.Upddate)
                    .HasColumnType("datetime")
                    .HasColumnName("upddate");

                entity.Property(e => e.Upduser)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("upduser");
            });

            modelBuilder.Entity<V010Teklifdetay>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("v010_teklifdetay");

                entity.Property(e => e.Aciklama)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("aciklama");

                entity.Property(e => e.Birimkodu)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("birimkodu");

                entity.Property(e => e.Cizimkodu)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("cizimkodu");

                entity.Property(e => e.Dovizdoku)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("dovizdoku");

                entity.Property(e => e.Dovizkuru).HasColumnName("dovizkuru");

                entity.Property(e => e.Dovizref).HasColumnName("dovizref");

                entity.Property(e => e.Duruminfo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("duruminfo");

                entity.Property(e => e.Ebat)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ebat");

                entity.Property(e => e.FiltreHarRef).HasColumnName("filtre_har_ref");

                entity.Property(e => e.Fiyat).HasColumnName("fiyat");

                entity.Property(e => e.Fiyattl).HasColumnName("fiyattl");

                entity.Property(e => e.Insdate)
                    .HasColumnType("datetime")
                    .HasColumnName("insdate");

                entity.Property(e => e.Insuser)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("insuser");

                entity.Property(e => e.Isktut1).HasColumnName("isktut1");

                entity.Property(e => e.Isktut1id).HasColumnName("isktut1id");

                entity.Property(e => e.Isktut1rd).HasColumnName("isktut1rd");

                entity.Property(e => e.Isktut1tl).HasColumnName("isktut1tl");

                entity.Property(e => e.Isktut2).HasColumnName("isktut2");

                entity.Property(e => e.Isktut2id).HasColumnName("isktut2id");

                entity.Property(e => e.Isktut2rd).HasColumnName("isktut2rd");

                entity.Property(e => e.Isktut2tl).HasColumnName("isktut2tl");

                entity.Property(e => e.Isktut3).HasColumnName("isktut3");

                entity.Property(e => e.Isktut3id).HasColumnName("isktut3id");

                entity.Property(e => e.Isktut3rd).HasColumnName("isktut3rd");

                entity.Property(e => e.Isktut3tl).HasColumnName("isktut3tl");

                entity.Property(e => e.Isktut4).HasColumnName("isktut4");

                entity.Property(e => e.Isktut4id).HasColumnName("isktut4id");

                entity.Property(e => e.Isktut4rd).HasColumnName("isktut4rd");

                entity.Property(e => e.Isktut4tl).HasColumnName("isktut4tl");

                entity.Property(e => e.Iskyuz1).HasColumnName("iskyuz1");

                entity.Property(e => e.Iskyuz2).HasColumnName("iskyuz2");

                entity.Property(e => e.Iskyuz3).HasColumnName("iskyuz3");

                entity.Property(e => e.Iskyuz4).HasColumnName("iskyuz4");

                entity.Property(e => e.Kdvkod).HasColumnName("kdvkod");

                entity.Property(e => e.Kdvmatrah).HasColumnName("kdvmatrah");

                entity.Property(e => e.Kdvmatrahid).HasColumnName("kdvmatrahid");

                entity.Property(e => e.Kdvmatrahrd).HasColumnName("kdvmatrahrd");

                entity.Property(e => e.Kdvmatrahtl).HasColumnName("kdvmatrahtl");

                entity.Property(e => e.Kdvtut).HasColumnName("kdvtut");

                entity.Property(e => e.Kdvtutid).HasColumnName("kdvtutid");

                entity.Property(e => e.Kdvtutrd).HasColumnName("kdvtutrd");

                entity.Property(e => e.Kdvtuttl).HasColumnName("kdvtuttl");

                entity.Property(e => e.Kdvyuz).HasColumnName("kdvyuz");

                entity.Property(e => e.Ldonem)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("ldonem")
                    .IsFixedLength(true);

                entity.Property(e => e.Lfirma)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("lfirma")
                    .IsFixedLength(true);

                entity.Property(e => e.Logref).HasColumnName("logref");

                entity.Property(e => e.LstokAdi)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("lstok_adi");

                entity.Property(e => e.LstokId).HasColumnName("lstok_id");

                entity.Property(e => e.LstokKodu)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("lstok_kodu");

                entity.Property(e => e.Maliyet1).HasColumnName("maliyet1");

                entity.Property(e => e.Maliyet1id).HasColumnName("maliyet1id");

                entity.Property(e => e.Maliyet2).HasColumnName("maliyet2");

                entity.Property(e => e.Maliyet2id).HasColumnName("maliyet2id");

                entity.Property(e => e.Malzadi)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("malzadi");

                entity.Property(e => e.Malzkodu)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("malzkodu");

                entity.Property(e => e.Marka)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("marka");

                entity.Property(e => e.Mensei)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("mensei");

                entity.Property(e => e.Miktar).HasColumnName("miktar");

                entity.Property(e => e.MontajYeri)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("montaj_yeri");

                entity.Property(e => e.Nettutar).HasColumnName("nettutar");

                entity.Property(e => e.Nettutarid).HasColumnName("nettutarid");

                entity.Property(e => e.Nettutarrd).HasColumnName("nettutarrd");

                entity.Property(e => e.Nettutartl).HasColumnName("nettutartl");

                entity.Property(e => e.Ozelkod5)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("ozelkod5");

                entity.Property(e => e.Satmalzlogref).HasColumnName("satmalzlogref");

                entity.Property(e => e.Satsipno)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("satsipno");

                entity.Property(e => e.Siplogref).HasColumnName("siplogref");

                entity.Property(e => e.Sipnosira)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("sipnosira");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Teklifref).HasColumnName("teklifref");

                entity.Property(e => e.TeslimTarihi)
                    .HasColumnType("datetime")
                    .HasColumnName("teslim_tarihi");

                entity.Property(e => e.Tutar).HasColumnName("tutar");

                entity.Property(e => e.Tutarid).HasColumnName("tutarid");

                entity.Property(e => e.Tutarrd).HasColumnName("tutarrd");

                entity.Property(e => e.Tutartl).HasColumnName("tutartl");

                entity.Property(e => e.Unitsetllogref).HasColumnName("unitsetllogref");

                entity.Property(e => e.Unitsetref).HasColumnName("unitsetref");

                entity.Property(e => e.Upddate)
                    .HasColumnType("datetime")
                    .HasColumnName("upddate");

                entity.Property(e => e.Upduser)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("upduser");

                entity.Property(e => e.Mahal).HasColumnName("mahal");
            });

            modelBuilder.Entity<V011TeklifRotum>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("v011_teklif_rota");

                entity.Property(e => e.Durum).HasColumnName("durum");

                entity.Property(e => e.DurumTanimiTeklifrota)
                    .IsRequired()
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("durum_tanimi_teklifrota");

                entity.Property(e => e.Insdate)
                    .HasColumnType("datetime")
                    .HasColumnName("insdate");

                entity.Property(e => e.Insuser)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("insuser");

                entity.Property(e => e.Irsref).HasColumnName("irsref");

                entity.Property(e => e.IsinAdi)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("isin_adi");

                entity.Property(e => e.Istekler)
                    .HasColumnType("text")
                    .HasColumnName("istekler");

                entity.Property(e => e.Kisiler)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("kisiler");

                entity.Property(e => e.Logref).HasColumnName("logref");

                entity.Property(e => e.OncelikSirasi).HasColumnName("oncelik_sirasi");

                entity.Property(e => e.Opadi)
                    .IsRequired()
                    .HasMaxLength(51)
                    .IsUnicode(false)
                    .HasColumnName("opadi");

                entity.Property(e => e.Opbitistarihi)
                    .HasColumnType("datetime")
                    .HasColumnName("opbitistarihi");

                entity.Property(e => e.Operasyonref).HasColumnName("operasyonref");

                entity.Property(e => e.Opfason).HasColumnName("opfason");

                entity.Property(e => e.Opharturref).HasColumnName("opharturref");

                entity.Property(e => e.Opkodu)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("opkodu");

                entity.Property(e => e.Opozelkod)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("opozelkod");

                entity.Property(e => e.Opsira).HasColumnName("opsira");

                entity.Property(e => e.Optanim)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("optanim");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.TalepTarihi)
                    .HasColumnType("datetime")
                    .HasColumnName("talep_tarihi");

                entity.Property(e => e.TasarimGordu).HasColumnName("tasarim_gordu");

                entity.Property(e => e.Teklifref).HasColumnName("teklifref");

                entity.Property(e => e.Upddate)
                    .HasColumnType("datetime")
                    .HasColumnName("upddate");

                entity.Property(e => e.Upduser)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("upduser");

                entity.Property(e => e.Yapilanlar)
                    .HasColumnType("text")
                    .HasColumnName("yapilanlar");
            });

            modelBuilder.Entity<V012Servi>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("v012_servis");

                entity.Property(e => e.Bastarih)
                    .HasColumnType("datetime")
                    .HasColumnName("bastarih");

                entity.Property(e => e.BayiIlgiliKisi)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("bayi_ilgili_kisi");

                entity.Property(e => e.BayiIlgiliTel)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("bayi_ilgili_tel");

                entity.Property(e => e.Bayiadi)
                    .HasMaxLength(201)
                    .IsUnicode(false)
                    .HasColumnName("bayiadi")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

                entity.Property(e => e.Bayikodu)
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("bayikodu")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

                entity.Property(e => e.Bayiref).HasColumnName("bayiref");

                entity.Property(e => e.BildirimTarihi)
                    .HasColumnType("datetime")
                    .HasColumnName("bildirim_tarihi");

                entity.Property(e => e.Bittarih)
                    .HasColumnType("datetime")
                    .HasColumnName("bittarih");

                entity.Property(e => e.Cariadi)
                    .HasMaxLength(201)
                    .IsUnicode(false)
                    .HasColumnName("cariadi")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

                entity.Property(e => e.Carikodu)
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("carikodu")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

                entity.Property(e => e.Cariref).HasColumnName("cariref");

                entity.Property(e => e.Durum)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("durum");

                entity.Property(e => e.Evrakno)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("evrakno");

                entity.Property(e => e.Fisno)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("fisno");

                entity.Property(e => e.Garanti).HasColumnName("garanti");

                entity.Property(e => e.Il)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("il")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

                entity.Property(e => e.IlgiliKisi)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ilgili_kisi");

                entity.Property(e => e.IlgiliTel)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ilgili_tel");

                entity.Property(e => e.Insdate)
                    .HasColumnType("datetime")
                    .HasColumnName("insdate");

                entity.Property(e => e.Insuser)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("insuser");

                entity.Property(e => e.IsTanimi)
                    .HasColumnType("text")
                    .HasColumnName("is_tanimi");

                entity.Property(e => e.IslemAdresi)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("islem_adresi");

                entity.Property(e => e.IslemBolge)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("islem_bolge");

                entity.Property(e => e.IslemIlce)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("islem_ilce");

                entity.Property(e => e.IslemSehir)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("islem_sehir");

                entity.Property(e => e.IslemSehirRef).HasColumnName("islem_sehir_ref");

                entity.Property(e => e.Istipi)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("istipi");

                entity.Property(e => e.Karaliste).HasColumnName("karaliste");

                entity.Property(e => e.KimYonlendirdi)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("kim_yonlendirdi");

                entity.Property(e => e.LbayiAdi)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("lbayi_adi");

                entity.Property(e => e.LbayiKodu)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("lbayi_kodu");

                entity.Property(e => e.LcariAdi)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("lcari_adi");

                entity.Property(e => e.LcariKodu)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("lcari_kodu");

                entity.Property(e => e.Logref).HasColumnName("logref");

                entity.Property(e => e.LtservisAdi)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("ltservis_adi");

                entity.Property(e => e.LtservisKodu)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("ltservis_kodu");

                entity.Property(e => e.Mailbayi).HasColumnName("mailbayi");

                entity.Property(e => e.Mailbayitar).HasColumnName("mailbayitar");

                entity.Property(e => e.Mailmusteri).HasColumnName("mailmusteri");

                entity.Property(e => e.Mailmusteritar)
                    .HasColumnType("datetime")
                    .HasColumnName("mailmusteritar");

                entity.Property(e => e.Mailservis).HasColumnName("mailservis");

                entity.Property(e => e.Mailservistar)
                    .HasColumnType("datetime")
                    .HasColumnName("mailservistar");

                entity.Property(e => e.Not1)
                    .HasColumnType("text")
                    .HasColumnName("not1");

                entity.Property(e => e.Orderref)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("orderref");

                entity.Property(e => e.Serinovar).HasColumnName("serinovar");

                entity.Property(e => e.ServisIlgiliKisi)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("servis_ilgili_kisi");

                entity.Property(e => e.ServisIlgiliTel)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("servis_ilgili_tel");

                entity.Property(e => e.Servisadi)
                    .HasMaxLength(201)
                    .IsUnicode(false)
                    .HasColumnName("servisadi")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

                entity.Property(e => e.Serviskodu)
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("serviskodu")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Tarih)
                    .HasColumnType("datetime")
                    .HasColumnName("tarih");

                entity.Property(e => e.Toptutar).HasColumnName("toptutar");

                entity.Property(e => e.Tservisref).HasColumnName("tservisref");

                entity.Property(e => e.Upddate)
                    .HasColumnType("datetime")
                    .HasColumnName("upddate");

                entity.Property(e => e.Upduser)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("upduser");

                entity.Property(e => e.Yapilanlar)
                    .HasColumnType("text")
                    .HasColumnName("yapilanlar");

                entity.Property(e => e.Yil).HasColumnName("yil");

                entity.Property(e => e.Yonlendirenkisi)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("yonlendirenkisi");

                entity.Property(e => e.MusteriMailAdresi)
                .HasColumnName("MusteriMailAdresi");

                entity.Property(e => e.ServisMailAdresi)
              .HasColumnName("ServisMailAdresi");

                entity.Property(e => e.BayiMailAdresi)
              .HasColumnName("BayiMailAdresi");
            });

            modelBuilder.Entity<V012ServisMalzemeler>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("v012_servis_malzemeler");

                entity.Property(e => e.Aciklama)
                    .HasColumnType("text")
                    .HasColumnName("aciklama");

                entity.Property(e => e.Birim)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("birim");

                entity.Property(e => e.Durum)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("durum");

                entity.Property(e => e.Fiyat).HasColumnName("fiyat");

                entity.Property(e => e.Garanti).HasColumnName("garanti");

                entity.Property(e => e.Insdate)
                    .HasColumnType("datetime")
                    .HasColumnName("insdate");

                entity.Property(e => e.Insuser)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("insuser");

                entity.Property(e => e.Logref).HasColumnName("logref");

                entity.Property(e => e.LstokAdi)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("lstok_adi");

                entity.Property(e => e.LstokKodu)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("lstok_kodu");

                entity.Property(e => e.Malzadi)
                    .HasMaxLength(51)
                    .IsUnicode(false)
                    .HasColumnName("malzadi")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

                entity.Property(e => e.Malzkodu)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("malzkodu")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

                entity.Property(e => e.Miktar).HasColumnName("miktar");

                entity.Property(e => e.Serino)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("serino");

                entity.Property(e => e.Servisref).HasColumnName("servisref");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Stokref).HasColumnName("stokref");

                entity.Property(e => e.Tur)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("tur");

                entity.Property(e => e.Tutar).HasColumnName("tutar");

                entity.Property(e => e.Upddate)
                    .HasColumnType("datetime")
                    .HasColumnName("upddate");

                entity.Property(e => e.Upduser)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("upduser");
            });

            modelBuilder.Entity<V013ServisHakedi>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("v013_servis_hakedis");

                entity.Property(e => e.Bastarih)
                    .HasColumnType("datetime")
                    .HasColumnName("bastarih");

                entity.Property(e => e.BayiIlgiliKisi)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("bayi_ilgili_kisi");

                entity.Property(e => e.BayiIlgiliTel)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("bayi_ilgili_tel");

                entity.Property(e => e.Bayiadi)
                    .HasMaxLength(201)
                    .IsUnicode(false)
                    .HasColumnName("bayiadi")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

                entity.Property(e => e.Bayikodu)
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("bayikodu")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

                entity.Property(e => e.Bayiref).HasColumnName("bayiref");

                entity.Property(e => e.BildirimTarihi)
                    .HasColumnType("datetime")
                    .HasColumnName("bildirim_tarihi");

                entity.Property(e => e.Bittarih)
                    .HasColumnType("datetime")
                    .HasColumnName("bittarih");

                entity.Property(e => e.Cariadi)
                    .HasMaxLength(201)
                    .IsUnicode(false)
                    .HasColumnName("cariadi")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

                entity.Property(e => e.Carikodu)
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("carikodu")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

                entity.Property(e => e.Cariref).HasColumnName("cariref");

                entity.Property(e => e.Durum)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("durum");

                entity.Property(e => e.Evrakno)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("evrakno");

                entity.Property(e => e.Fatno)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("fatno");

                entity.Property(e => e.Fattar)
                    .HasColumnType("datetime")
                    .HasColumnName("fattar");

                entity.Property(e => e.Fisno)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("fisno");

                entity.Property(e => e.Garanti).HasColumnName("garanti");

                entity.Property(e => e.Hinsdate)
                    .HasColumnType("datetime")
                    .HasColumnName("hinsdate");

                entity.Property(e => e.Hinsuser)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("hinsuser");

                entity.Property(e => e.Hlogref).HasColumnName("hlogref");

                entity.Property(e => e.Hmailgittimi).HasColumnName("hmailgittimi");

                entity.Property(e => e.Hmailtar)
                    .HasColumnType("datetime")
                    .HasColumnName("hmailtar");

                entity.Property(e => e.Hno)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("hno");

                entity.Property(e => e.Hstatus).HasColumnName("hstatus");

                entity.Property(e => e.Htarih)
                    .HasColumnType("datetime")
                    .HasColumnName("htarih");

                entity.Property(e => e.Htutar).HasColumnName("htutar");

                entity.Property(e => e.Hupddate)
                    .HasColumnType("datetime")
                    .HasColumnName("hupddate");

                entity.Property(e => e.Hupduser)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("hupduser");

                entity.Property(e => e.Il)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("il")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

                entity.Property(e => e.IlgiliKisi)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ilgili_kisi");

                entity.Property(e => e.IlgiliTel)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ilgili_tel");

                entity.Property(e => e.Insdate)
                    .HasColumnType("datetime")
                    .HasColumnName("insdate");

                entity.Property(e => e.Insuser)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("insuser");

                entity.Property(e => e.IsTanimi)
                    .HasColumnType("text")
                    .HasColumnName("is_tanimi");

                entity.Property(e => e.IslemAdresi)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("islem_adresi");

                entity.Property(e => e.IslemBolge)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("islem_bolge");

                entity.Property(e => e.IslemIlce)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("islem_ilce");

                entity.Property(e => e.IslemSehir)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("islem_sehir");

                entity.Property(e => e.IslemSehirRef).HasColumnName("islem_sehir_ref");

                entity.Property(e => e.Istipi)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("istipi");

                entity.Property(e => e.Karaliste).HasColumnName("karaliste");

                entity.Property(e => e.KimYonlendirdi)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("kim_yonlendirdi");

                entity.Property(e => e.LbayiAdi)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("lbayi_adi");

                entity.Property(e => e.LbayiKodu)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("lbayi_kodu");

                entity.Property(e => e.LcariAdi)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("lcari_adi");

                entity.Property(e => e.LcariKodu)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("lcari_kodu");

                entity.Property(e => e.Logref).HasColumnName("logref");

                entity.Property(e => e.LtservisAdi)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("ltservis_adi");

                entity.Property(e => e.LtservisKodu)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("ltservis_kodu");

                entity.Property(e => e.Mailbayi).HasColumnName("mailbayi");

                entity.Property(e => e.Mailbayitar).HasColumnName("mailbayitar");

                entity.Property(e => e.Mailmusteri).HasColumnName("mailmusteri");

                entity.Property(e => e.Mailmusteritar)
                    .HasColumnType("datetime")
                    .HasColumnName("mailmusteritar");

                entity.Property(e => e.Mailservis).HasColumnName("mailservis");

                entity.Property(e => e.Mailservistar)
                    .HasColumnType("datetime")
                    .HasColumnName("mailservistar");

                entity.Property(e => e.Not1)
                    .HasColumnType("text")
                    .HasColumnName("not1");

                entity.Property(e => e.Odemedurumu)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("odemedurumu");

                entity.Property(e => e.Orderref)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("orderref");

                entity.Property(e => e.Serinovar).HasColumnName("serinovar");

                entity.Property(e => e.ServisIlgiliKisi)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("servis_ilgili_kisi");

                entity.Property(e => e.ServisIlgiliTel)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("servis_ilgili_tel");

                entity.Property(e => e.Servisadi)
                    .HasMaxLength(201)
                    .IsUnicode(false)
                    .HasColumnName("servisadi")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

                entity.Property(e => e.Serviskodu)
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("serviskodu")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

                entity.Property(e => e.Servisref).HasColumnName("servisref");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Tarih)
                    .HasColumnType("datetime")
                    .HasColumnName("tarih");

                entity.Property(e => e.Toptutar).HasColumnName("toptutar");

                entity.Property(e => e.Tservisref).HasColumnName("tservisref");

                entity.Property(e => e.Upddate)
                    .HasColumnType("datetime")
                    .HasColumnName("upddate");

                entity.Property(e => e.Upduser)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("upduser");

                entity.Property(e => e.Yapilanlar)
                    .HasColumnType("text")
                    .HasColumnName("yapilanlar");

                entity.Property(e => e.Yil).HasColumnName("yil");

                entity.Property(e => e.Yonlendirenkisi)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("yonlendirenkisi");
            });

            modelBuilder.Entity<V015Kisiler>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("v015_kisiler");

                entity.Property(e => e.Aciklama)
                    .HasColumnType("text")
                    .HasColumnName("aciklama");

                entity.Property(e => e.Adi)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("adi");

                entity.Property(e => e.Adres)
                    .HasColumnType("text")
                    .HasColumnName("adres");

                entity.Property(e => e.Bolum)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("bolum");

                entity.Property(e => e.Cariadi)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cariadi");

                entity.Property(e => e.Carikarttipi).HasColumnName("carikarttipi");

                entity.Property(e => e.Carikarttipiadi)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("carikarttipiadi");

                entity.Property(e => e.Carikodu)
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("carikodu")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

                entity.Property(e => e.Cariref).HasColumnName("cariref");

                entity.Property(e => e.Ceptel)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("ceptel");

                entity.Property(e => e.Digtel)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("digtel");

                entity.Property(e => e.DogumTarihi)
                    .HasColumnType("datetime")
                    .HasColumnName("dogum_tarihi");

                entity.Property(e => e.Evtel)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("evtel");

                entity.Property(e => e.Faks)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("faks");

                entity.Property(e => e.Insdate)
                    .HasColumnType("datetime")
                    .HasColumnName("insdate");

                entity.Property(e => e.Insuser)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("insuser");

                entity.Property(e => e.Istel)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("istel");

                entity.Property(e => e.Logref).HasColumnName("logref");

                entity.Property(e => e.Mail)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("mail");

                entity.Property(e => e.Pozisyon)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("pozisyon");

                entity.Property(e => e.Soyadi)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("soyadi");

                entity.Property(e => e.Tamadi)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("tamadi");

                entity.Property(e => e.Upddate)
                    .HasColumnType("datetime")
                    .HasColumnName("upddate");

                entity.Property(e => e.Upduser)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("upduser");

                entity.Property(e => e.Varsayilan).HasColumnName("varsayilan");
            });

            modelBuilder.Entity<V020Faaliyet>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("v020_faaliyet");

                entity.Property(e => e.Adi2)
                    .HasMaxLength(201)
                    .IsUnicode(false)
                    .HasColumnName("adi2");

                entity.Property(e => e.Cariadi)
                    .HasMaxLength(201)
                    .IsUnicode(false)
                    .HasColumnName("cariadi");

                entity.Property(e => e.Carikodu)
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("carikodu");

                entity.Property(e => e.Carimail)
                    .HasMaxLength(251)
                    .IsUnicode(false)
                    .HasColumnName("carimail");

                entity.Property(e => e.Cariref).HasColumnName("cariref");

                entity.Property(e => e.Giren)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("giren");

                entity.Property(e => e.Grup1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("grup1");

                entity.Property(e => e.Grup2)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("grup2");

                entity.Property(e => e.Grup3)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("grup3");

                entity.Property(e => e.Grup4)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("grup4");

                entity.Property(e => e.Grup5)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("grup5");

                entity.Property(e => e.Il)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("il");

                entity.Property(e => e.Ilce)
                    .HasMaxLength(51)
                    .IsUnicode(false)
                    .HasColumnName("ilce");

                entity.Property(e => e.Insdate)
                    .HasColumnType("datetime")
                    .HasColumnName("insdate");

                entity.Property(e => e.Insuser)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("insuser");

                entity.Property(e => e.IslemSayisi).HasColumnName("islem_sayisi");

                entity.Property(e => e.Islemturu).HasColumnName("islemturu");

                entity.Property(e => e.Kisiadi)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("kisiadi");

                entity.Property(e => e.Kisiadi2)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("kisiadi2");

                entity.Property(e => e.Kisiadi3)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("kisiadi3");

                entity.Property(e => e.Kisiadi4)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("kisiadi4");

                entity.Property(e => e.Kisiadi5)
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("kisiadi5");

                entity.Property(e => e.Kisiceptel)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("kisiceptel");

                entity.Property(e => e.Kisiceptel2)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("kisiceptel2");

                entity.Property(e => e.Kisiceptel3)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("kisiceptel3");

                entity.Property(e => e.Kisiceptel4)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("kisiceptel4");

                entity.Property(e => e.Kisiceptel5)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("kisiceptel5");

                entity.Property(e => e.Kisievtel)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("kisievtel");

                entity.Property(e => e.Kisievtel2)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("kisievtel2");

                entity.Property(e => e.Kisievtel3)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("kisievtel3");

                entity.Property(e => e.Kisievtel4)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("kisievtel4");

                entity.Property(e => e.Kisievtel5)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("kisievtel5");

                entity.Property(e => e.Kisiistel)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("kisiistel");

                entity.Property(e => e.Kisiistel2)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("kisiistel2");

                entity.Property(e => e.Kisiistel3)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("kisiistel3");

                entity.Property(e => e.Kisiistel4)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("kisiistel4");

                entity.Property(e => e.Kisiistel5)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("kisiistel5");

                entity.Property(e => e.Kisimail)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("kisimail");

                entity.Property(e => e.Kisimail2)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("kisimail2");

                entity.Property(e => e.Kisimail3)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("kisimail3");

                entity.Property(e => e.Kisimail4)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("kisimail4");

                entity.Property(e => e.Kisimail5)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("kisimail5");

                entity.Property(e => e.Kisiref).HasColumnName("kisiref");

                entity.Property(e => e.Kisiref2).HasColumnName("kisiref2");

                entity.Property(e => e.Kisiref3).HasColumnName("kisiref3");

                entity.Property(e => e.Kisiref4).HasColumnName("kisiref4");

                entity.Property(e => e.Kisiref5).HasColumnName("kisiref5");

                entity.Property(e => e.Konu)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("konu");

                entity.Property(e => e.Logref).HasColumnName("logref");

                entity.Property(e => e.Malzemeadi)
                    .HasMaxLength(51)
                    .IsUnicode(false)
                    .HasColumnName("malzemeadi");

                entity.Property(e => e.Malzemekodu)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("malzemekodu");

                entity.Property(e => e.Malzemeref).HasColumnName("malzemeref");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Tarih)
                    .HasColumnType("datetime")
                    .HasColumnName("tarih");

                entity.Property(e => e.Ulke)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("ulke");

                entity.Property(e => e.Upddate)
                    .HasColumnType("datetime")
                    .HasColumnName("upddate");

                entity.Property(e => e.Upduser)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("upduser");

                entity.Property(e => e.Yapilanlar)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("yapilanlar");
            });

            modelBuilder.Entity<V029Teklif>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("v029_teklif");

                entity.Property(e => e.Aciklama1)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("aciklama1");

                entity.Property(e => e.Aciklama2)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("aciklama2");

                entity.Property(e => e.Aciklama3)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("aciklama3");

                entity.Property(e => e.Aciklama4)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("aciklama4");

                entity.Property(e => e.Cariadi)
                    .HasMaxLength(201)
                    .IsUnicode(false)
                    .HasColumnName("cariadi");

                entity.Property(e => e.Carikodu)
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("carikodu");

                entity.Property(e => e.Cariref).HasColumnName("cariref");

                entity.Property(e => e.Carisevkadrref).HasColumnName("carisevkadrref");

                entity.Property(e => e.Caritip).HasColumnName("caritip");

                entity.Property(e => e.Dovizdoku)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("dovizdoku");

                entity.Property(e => e.Dovizdokuid)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("dovizdokuid");

                entity.Property(e => e.Dovizkuru).HasColumnName("dovizkuru");

                entity.Property(e => e.Dovizkuruid).HasColumnName("dovizkuruid");

                entity.Property(e => e.Dovizref).HasColumnName("dovizref");

                entity.Property(e => e.Dovizrefid).HasColumnName("dovizrefid");

                entity.Property(e => e.Duruminfo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("duruminfo");

                entity.Property(e => e.Faks)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("faks");

                entity.Property(e => e.Gniskoran).HasColumnName("gniskoran");

                entity.Property(e => e.Gnisktutar).HasColumnName("gnisktutar");

                entity.Property(e => e.Gnistip).HasColumnName("gnistip");

                entity.Property(e => e.Il)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("il");

                entity.Property(e => e.Ilce)
                    .HasMaxLength(51)
                    .IsUnicode(false)
                    .HasColumnName("ilce");

                entity.Property(e => e.IlgiliAdi)
                    .HasMaxLength(51)
                    .IsUnicode(false)
                    .HasColumnName("ilgili_adi");

                entity.Property(e => e.Insdate)
                    .HasColumnType("datetime")
                    .HasColumnName("insdate");

                entity.Property(e => e.Insuser)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("insuser");

                entity.Property(e => e.LcariAdi)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("lcari_adi");

                entity.Property(e => e.LcariKodu)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("lcari_kodu");

                entity.Property(e => e.LcariSevkadrKodu)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("lcari_sevkadr_kodu");

                entity.Property(e => e.Ldonem)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("ldonem")
                    .IsFixedLength(true);

                entity.Property(e => e.Lfirma)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("lfirma")
                    .IsFixedLength(true);

                entity.Property(e => e.LodemePlani).HasColumnName("lodeme_plani");

                entity.Property(e => e.LodemePlaniKodu)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("lodeme_plani_kodu");

                entity.Property(e => e.Logoentegre)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("logoentegre");

                entity.Property(e => e.Logosipref).HasColumnName("logosipref");

                entity.Property(e => e.Logotar)
                    .HasColumnType("datetime")
                    .HasColumnName("logotar");

                entity.Property(e => e.Logref).HasColumnName("logref");

                entity.Property(e => e.Lpersoneladi)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("lpersoneladi");

                entity.Property(e => e.Lpersonelref).HasColumnName("lpersonelref");

                entity.Property(e => e.Mail)
                    .HasMaxLength(51)
                    .IsUnicode(false)
                    .HasColumnName("mail");

                entity.Property(e => e.Notlar)
                    .HasColumnType("text")
                    .HasColumnName("notlar");

                entity.Property(e => e.Odemeplaniadi)
                    .HasMaxLength(201)
                    .IsUnicode(false)
                    .HasColumnName("odemeplaniadi");

                entity.Property(e => e.Odemeplanikodu)
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("odemeplanikodu");

                entity.Property(e => e.Proje)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("proje");

                entity.Property(e => e.Revizyon).HasColumnName("revizyon");

                entity.Property(e => e.Revzno)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("revzno");

                entity.Property(e => e.Saat)
                    .HasColumnType("datetime")
                    .HasColumnName("saat");

                entity.Property(e => e.SevkEdilecekBayiAdi)
                    .HasMaxLength(51)
                    .IsUnicode(false)
                    .HasColumnName("sevk_edilecek_bayi_adi");

                entity.Property(e => e.SevkIlgilisi)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("sevk_ilgilisi");

                entity.Property(e => e.Sevkadres1)
                    .HasMaxLength(201)
                    .IsUnicode(false)
                    .HasColumnName("sevkadres1");

                entity.Property(e => e.Sevkadres2)
                    .HasMaxLength(201)
                    .IsUnicode(false)
                    .HasColumnName("sevkadres2");

                entity.Property(e => e.Sevkkodu)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("sevkkodu");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Tarih)
                    .HasColumnType("datetime")
                    .HasColumnName("tarih");

                entity.Property(e => e.Tbelgeno)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("tbelgeno");

                entity.Property(e => e.Teklifno)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("teklifno");

                entity.Property(e => e.Tel1)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("tel1");

                entity.Property(e => e.Tel2)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("tel2");

                entity.Property(e => e.Temsilciadi)
                    .HasMaxLength(51)
                    .IsUnicode(false)
                    .HasColumnName("temsilciadi");

                entity.Property(e => e.Temsilcikodu)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("temsilcikodu");

                entity.Property(e => e.TeslimSekli)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("teslim_sekli");

                entity.Property(e => e.TeslimTarihi)
                    .HasColumnType("datetime")
                    .HasColumnName("teslim_tarihi");

                entity.Property(e => e.Trcode).HasColumnName("trcode");

                entity.Property(e => e.Tutar).HasColumnName("tutar");

                entity.Property(e => e.Tutarmatrah).HasColumnName("tutarmatrah");

                entity.Property(e => e.Tutarmatrahrd).HasColumnName("tutarmatrahrd");

                entity.Property(e => e.Tutarmatrahtl).HasColumnName("tutarmatrahtl");

                entity.Property(e => e.Tutarrd).HasColumnName("tutarrd");

                entity.Property(e => e.Tutartl).HasColumnName("tutartl");

                entity.Property(e => e.Upddate)
                    .HasColumnType("datetime")
                    .HasColumnName("upddate");

                entity.Property(e => e.Upduser)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("upduser");
            });

            modelBuilder.Entity<V029Teklif2>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("v029_teklif2");

                entity.Property(e => e.Aciklama1)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("aciklama1");

                entity.Property(e => e.Aciklama2)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("aciklama2");

                entity.Property(e => e.Aciklama3)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("aciklama3");

                entity.Property(e => e.Aciklama4)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("aciklama4");

                entity.Property(e => e.Cariadi)
                    .HasMaxLength(201)
                    .IsUnicode(false)
                    .HasColumnName("cariadi");

                entity.Property(e => e.Carikodu)
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("carikodu");

                entity.Property(e => e.Cariref).HasColumnName("cariref");

                entity.Property(e => e.Carisevkadrref).HasColumnName("carisevkadrref");

                entity.Property(e => e.Caritip).HasColumnName("caritip");

                entity.Property(e => e.Dovizdoku)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("dovizdoku");

                entity.Property(e => e.Dovizdokuid)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasColumnName("dovizdokuid");

                entity.Property(e => e.Dovizkuru).HasColumnName("dovizkuru");

                entity.Property(e => e.Dovizkuruid).HasColumnName("dovizkuruid");

                entity.Property(e => e.Dovizref).HasColumnName("dovizref");

                entity.Property(e => e.Dovizrefid).HasColumnName("dovizrefid");

                entity.Property(e => e.Duruminfo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("duruminfo");

                entity.Property(e => e.Faks)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("faks");

                entity.Property(e => e.Gniskoran).HasColumnName("gniskoran");

                entity.Property(e => e.Gnisktutar).HasColumnName("gnisktutar");

                entity.Property(e => e.Gnistip).HasColumnName("gnistip");

                entity.Property(e => e.Il)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("il");

                entity.Property(e => e.Ilce)
                    .HasMaxLength(51)
                    .IsUnicode(false)
                    .HasColumnName("ilce");

                entity.Property(e => e.IlgiliAdi)
                    .HasMaxLength(51)
                    .IsUnicode(false)
                    .HasColumnName("ilgili_adi");

                entity.Property(e => e.Insdate)
                    .HasColumnType("datetime")
                    .HasColumnName("insdate");

                entity.Property(e => e.Insuser)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("insuser");

                entity.Property(e => e.LcariAdi)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("lcari_adi");

                entity.Property(e => e.LcariKodu)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("lcari_kodu");

                entity.Property(e => e.LcariSevkadrKodu)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("lcari_sevkadr_kodu");

                entity.Property(e => e.Ldonem)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("ldonem")
                    .IsFixedLength(true);

                entity.Property(e => e.Lfirma)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("lfirma")
                    .IsFixedLength(true);

                entity.Property(e => e.LodemePlani).HasColumnName("lodeme_plani");

                entity.Property(e => e.LodemePlaniKodu)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("lodeme_plani_kodu");

                entity.Property(e => e.Logoentegre)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("logoentegre");

                entity.Property(e => e.Logosipref).HasColumnName("logosipref");

                entity.Property(e => e.Logotar)
                    .HasColumnType("datetime")
                    .HasColumnName("logotar");

                entity.Property(e => e.Logref).HasColumnName("logref");

                entity.Property(e => e.Lpersoneladi)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("lpersoneladi");

                entity.Property(e => e.Lpersonelref).HasColumnName("lpersonelref");

                entity.Property(e => e.Mail)
                    .HasMaxLength(51)
                    .IsUnicode(false)
                    .HasColumnName("mail");

                entity.Property(e => e.Notlar)
                    .HasColumnType("text")
                    .HasColumnName("notlar");

                entity.Property(e => e.Odemeplaniadi)
                    .HasMaxLength(201)
                    .IsUnicode(false)
                    .HasColumnName("odemeplaniadi");

                entity.Property(e => e.Odemeplanikodu)
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("odemeplanikodu");

                entity.Property(e => e.Proje)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("proje");

                entity.Property(e => e.Revizyon).HasColumnName("revizyon");

                entity.Property(e => e.Revzno)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("revzno");

                entity.Property(e => e.Saat)
                    .HasColumnType("datetime")
                    .HasColumnName("saat");

                entity.Property(e => e.SevkEdilecekBayiAdi)
                    .HasMaxLength(51)
                    .IsUnicode(false)
                    .HasColumnName("sevk_edilecek_bayi_adi");

                entity.Property(e => e.SevkIlgilisi)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("sevk_ilgilisi");

                entity.Property(e => e.Sevkadres1)
                    .HasMaxLength(201)
                    .IsUnicode(false)
                    .HasColumnName("sevkadres1");

                entity.Property(e => e.Sevkadres2)
                    .HasMaxLength(201)
                    .IsUnicode(false)
                    .HasColumnName("sevkadres2");

                entity.Property(e => e.Sevkkodu)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("sevkkodu");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Tarih)
                    .HasColumnType("datetime")
                    .HasColumnName("tarih");

                entity.Property(e => e.Tbelgeno)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("tbelgeno");

                entity.Property(e => e.Teklifno)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("teklifno");

                entity.Property(e => e.Tel1)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("tel1");

                entity.Property(e => e.Tel2)
                    .HasMaxLength(16)
                    .IsUnicode(false)
                    .HasColumnName("tel2");

                entity.Property(e => e.Temsilciadi)
                    .HasMaxLength(51)
                    .IsUnicode(false)
                    .HasColumnName("temsilciadi");

                entity.Property(e => e.Temsilcikodu)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("temsilcikodu");

                entity.Property(e => e.TeslimSekli)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("teslim_sekli");

                entity.Property(e => e.TeslimTarihi)
                    .HasColumnType("datetime")
                    .HasColumnName("teslim_tarihi");

                entity.Property(e => e.Trcode).HasColumnName("trcode");

                entity.Property(e => e.Tutar).HasColumnName("tutar");

                entity.Property(e => e.Tutarmatrah).HasColumnName("tutarmatrah");

                entity.Property(e => e.Tutarmatrahrd).HasColumnName("tutarmatrahrd");

                entity.Property(e => e.Tutarmatrahtl).HasColumnName("tutarmatrahtl");

                entity.Property(e => e.Tutarrd).HasColumnName("tutarrd");

                entity.Property(e => e.Tutartl).HasColumnName("tutartl");

                entity.Property(e => e.Upddate)
                    .HasColumnType("datetime")
                    .HasColumnName("upddate");

                entity.Property(e => e.Upduser)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("upduser");
            });

            modelBuilder.Entity<V040FiltreSure>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("v040_filtre_sure");

                entity.Property(e => e.Aciklama)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("aciklama");

                entity.Property(e => e.Insdate)
                    .HasColumnType("datetime")
                    .HasColumnName("insdate");

                entity.Property(e => e.Insuser)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("insuser");

                entity.Property(e => e.Logref).HasColumnName("logref");

                entity.Property(e => e.LstokAdi)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("lstok_adi");

                entity.Property(e => e.LstokId).HasColumnName("lstok_id");

                entity.Property(e => e.LstokKodu)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("lstok_kodu");

                entity.Property(e => e.Malzadi)
                    .HasMaxLength(51)
                    .IsUnicode(false)
                    .HasColumnName("malzadi")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

                entity.Property(e => e.Malzkodu)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("malzkodu")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.TekrarlamaSekli)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("tekrarlama_sekli");

                entity.Property(e => e.TekrarlamaSuresi).HasColumnName("tekrarlama_suresi");

                entity.Property(e => e.Upddate)
                    .HasColumnType("datetime")
                    .HasColumnName("upddate");

                entity.Property(e => e.Upduser)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("upduser");
            });

            modelBuilder.Entity<V041FiltreMontaj>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("v041_filtre_montaj");

                entity.Property(e => e.Aciklama)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("aciklama");

                entity.Property(e => e.Cariadi)
                    .HasMaxLength(201)
                    .IsUnicode(false)
                    .HasColumnName("cariadi");

                entity.Property(e => e.Carikodu)
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("carikodu");

                entity.Property(e => e.Durum).HasColumnName("durum");

                entity.Property(e => e.Insdate)
                    .HasColumnType("datetime")
                    .HasColumnName("insdate");

                entity.Property(e => e.Insuser)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("insuser");

                entity.Property(e => e.Logref).HasColumnName("logref");

                entity.Property(e => e.LstokFiltreAdi)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("lstok_filtre_adi");

                entity.Property(e => e.LstokFiltreId).HasColumnName("lstok_filtre_id");

                entity.Property(e => e.LstokFiltreKodu)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("lstok_filtre_kodu");

                entity.Property(e => e.LstokMainAdi)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("lstok_main_adi");

                entity.Property(e => e.LstokMainId).HasColumnName("lstok_main_id");

                entity.Property(e => e.LstokMainKodu)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("lstok_main_kodu");

                entity.Property(e => e.Malzadi)
                    .HasMaxLength(51)
                    .IsUnicode(false)
                    .HasColumnName("malzadi");

                entity.Property(e => e.Malzkodu)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("malzkodu");

                entity.Property(e => e.MontajTarihi)
                    .HasColumnType("datetime")
                    .HasColumnName("montaj_tarihi");

                entity.Property(e => e.MontajYeri)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("montaj_yeri");

                entity.Property(e => e.Neden)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("neden");

                entity.Property(e => e.Proje)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("proje");

                entity.Property(e => e.SetMalzadi)
                    .HasMaxLength(51)
                    .IsUnicode(false)
                    .HasColumnName("set_malzadi");

                entity.Property(e => e.SetMalzkodu)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("set_malzkodu");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Tarih)
                    .HasColumnType("datetime")
                    .HasColumnName("tarih");

                entity.Property(e => e.Teklifdetayref).HasColumnName("teklifdetayref");

                entity.Property(e => e.Teklifno)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("teklifno");

                entity.Property(e => e.Teklifref).HasColumnName("teklifref");

                entity.Property(e => e.TekrarlamaSekli)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("tekrarlama_sekli");

                entity.Property(e => e.TekrarlamaSuresi).HasColumnName("tekrarlama_suresi");

                entity.Property(e => e.Upddate)
                    .HasColumnType("datetime")
                    .HasColumnName("upddate");

                entity.Property(e => e.Upduser)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("upduser");
            });

            modelBuilder.Entity<V042FiltreMontaj>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("v042_filtre_montaj");

                entity.Property(e => e.Aciklama)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("aciklama");

                entity.Property(e => e.Cariadi)
                    .HasMaxLength(201)
                    .IsUnicode(false)
                    .HasColumnName("cariadi");

                entity.Property(e => e.Carikodu)
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("carikodu");

                entity.Property(e => e.Durum).HasColumnName("durum");

                entity.Property(e => e.FiltreHarRef).HasColumnName("filtre_har_ref");

                entity.Property(e => e.Filtreharref1).HasColumnName("filtreharref");

                entity.Property(e => e.Insdate)
                    .HasColumnType("datetime")
                    .HasColumnName("insdate");

                entity.Property(e => e.Insuser)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("insuser");

                entity.Property(e => e.Logref).HasColumnName("logref");

                entity.Property(e => e.LstokFiltreAdi)
                    .HasMaxLength(80)
                    .IsUnicode(false)
                    .HasColumnName("lstok_filtre_adi");

                entity.Property(e => e.LstokFiltreId).HasColumnName("lstok_filtre_id");

                entity.Property(e => e.LstokFiltreKodu)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("lstok_filtre_kodu");

                entity.Property(e => e.Malzadi)
                    .HasMaxLength(51)
                    .IsUnicode(false)
                    .HasColumnName("malzadi");

                entity.Property(e => e.Malzkodu)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("malzkodu");

                entity.Property(e => e.MontajYeri)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("montaj_yeri");

                entity.Property(e => e.Proje)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("proje");

                entity.Property(e => e.SetMalzadi)
                    .HasMaxLength(51)
                    .IsUnicode(false)
                    .HasColumnName("set_malzadi");

                entity.Property(e => e.SetMalzkodu)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("set_malzkodu");

                entity.Property(e => e.SevkTarihi)
                    .HasColumnType("datetime")
                    .HasColumnName("sevk_tarihi");

                entity.Property(e => e.Tarih)
                    .HasColumnType("datetime")
                    .HasColumnName("tarih");

                entity.Property(e => e.Teklifdetayref).HasColumnName("teklifdetayref");

                entity.Property(e => e.Teklifno)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("teklifno");

                entity.Property(e => e.Teklifref).HasColumnName("teklifref");

                entity.Property(e => e.Upddate)
                    .HasColumnType("datetime")
                    .HasColumnName("upddate");

                entity.Property(e => e.Upduser)
                    .HasMaxLength(21)
                    .IsUnicode(false)
                    .HasColumnName("upduser");

                entity.Property(e => e.YenilemeTarihi)
                    .HasColumnType("datetime")
                    .HasColumnName("yenileme_tarihi");
            });

            modelBuilder.Entity<V050MalzKalite>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("v050_malz_kalite");

                entity.Property(e => e.Acik)
                    .HasColumnType("text")
                    .HasColumnName("acik");

                entity.Property(e => e.AcikIng)
                    .HasColumnType("text")
                    .HasColumnName("acik_ing");

                entity.Property(e => e.Aciklama)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("aciklama");

                entity.Property(e => e.Grupkodu)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("grupkodu")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

                entity.Property(e => e.Insdate)
                    .HasColumnType("datetime")
                    .HasColumnName("insdate");

                entity.Property(e => e.Insuser)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("insuser");

                entity.Property(e => e.Logref).HasColumnName("logref");

                entity.Property(e => e.Malzemeadi)
                    .HasMaxLength(51)
                    .IsUnicode(false)
                    .HasColumnName("malzemeadi")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

                entity.Property(e => e.Malzemeebat)
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("malzemeebat");

                entity.Property(e => e.Malzemekodu)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("malzemekodu")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

                entity.Property(e => e.Malzememarkaadi)
                    .HasMaxLength(51)
                    .IsUnicode(false)
                    .HasColumnName("malzememarkaadi")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

                entity.Property(e => e.Malzememensei)
                    .HasMaxLength(41)
                    .IsUnicode(false)
                    .HasColumnName("malzememensei")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

                entity.Property(e => e.Malzemeref).HasColumnName("malzemeref");

                entity.Property(e => e.Metin)
                    .HasColumnType("text")
                    .HasColumnName("metin");

                entity.Property(e => e.Ozelkod2)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("ozelkod2")
                    .UseCollation("SQL_Latin1_General_CP1254_CI_AS");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Teknik)
                    .HasColumnType("text")
                    .HasColumnName("teknik");

                entity.Property(e => e.TeknikIng)
                    .HasColumnType("text")
                    .HasColumnName("teknik_ing");

                entity.Property(e => e.Tip)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("tip");

                entity.Property(e => e.Upddate)
                    .HasColumnType("datetime")
                    .HasColumnName("upddate");

                entity.Property(e => e.Upduser)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("upduser");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
